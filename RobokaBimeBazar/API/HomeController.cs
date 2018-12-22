using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using RobokaBimeBazar.API.Json.Input;
using RobokaBimeBazar.API.Json.Output;
using RobokaBimeBazar.DAL;
using RobokaBimeBazar.Domain.Entity;
using RobokaBimeBazar.Domain.Enum;
using RobokaBimeBazar.Domain.Model;
using RobokaBimeBazar.Service.Interface;
using RobokaBimeBazar.Utility;

namespace RobokaBimeBazar.API
{
    [RoutePrefix("api")]
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfigService _configService;
        private readonly IUserDataService _userDataService;
        private readonly IButtonService _buttonService;
        private readonly IProvinceService _provinceService;
        private readonly IExceptionLogService _exceptionLogService;

        private static bool _isSendingMessage;

        private const string DoneImageUrl = "https://bimehbot.iranlms.ir/Images/check.png";
        private const string BotApi = "https://testmessenger.iranlms.ir/bot.ashx";

        private const string DownloadAddress = "~/Downloads/";

        private readonly string BimeToken =
            "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwYXJ0bmVyX25hbWUiOiJydWJpa2EifQ._ICijq_3RmZIQcCsWE8zkS3_IcmcVPB8mLQh_1YhEI4;";// Mr.Hek
        //"Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYXJ0bmVyX25hbWUiOiJydWJpa2EifQ.NYAva6Yb0_mSknyKadPCX64QIU4En0nHudIgK-o2LE0;";// Mr.Deh
        private const string BimeApi = "http://sandbox.bimebazar.ir/";
        //"https://bimebazar.com/";

        //private const string UserMobile = "09196368126";

        //testBot:
        //CB0JDVMONOKUFTTRDYKPOWEKKJBGSYIZXUHWIWBZBRFSARFQLNJJKDMZMCLPEIWZ

        //Server:
        //CC0YWAWVLWIGJQEYRPIJELMYUJIZOUXHZQTREUXLXHOCGAOZUEHMALPAMOMKOLKJ
        private readonly Dictionary<string, string> _botHeader = new Dictionary<string, string> { { "bot_key", "CB0JDVMONOKUFTTRDYKPOWEKKJBGSYIZXUHWIWBZBRFSARFQLNJJKDMZMCLPEIWZ" } };



        public HomeController(ApplicationDbContext context,
            IConfigService configService,
            IUserDataService userDataService,
            IButtonService buttonService,
            IProvinceService provinceService,
            IExceptionLogService exceptionLogService)
        {
            _context = context;
            _configService = configService;
            _userDataService = userDataService;
            _buttonService = buttonService;
            _provinceService = provinceService;
            _exceptionLogService = exceptionLogService;
        }


        #region API

        [HttpGet, Route("getMessage")]
        public async Task<IHttpActionResult> GetMessages()
        {
            try
            {

                if (_isSendingMessage) return CustomResult();

                var config = await _configService.GetConfig();
                var result = await Api.PostAsync<GetMessageOutput>(BotApi,
                    new
                    {
                        method = "getMessages",
                        data = new
                        {
                            start_message_id = int.Parse(config.LastMessageId) + 1,
                            limit = 10
                        }
                    }, _botHeader);

                if (result != null && result.Data.MessageList.Count > 0)
                {
                    _isSendingMessage = true;

                    var listOfMessageList = result.Data.MessageList.GroupBy(x => x.ChatId).Select(x => x.ToList()).ToList();

                    foreach (var messageList in listOfMessageList)
                    {

                        var myMessage = messageList.OrderByDescending(x => x.MessageId).FirstOrDefault();

                        if (myMessage?.ChatId == null /*|| myMessage.ChatId != "b_7149751_7"*/) continue;

                        await _configService.UpdateLastMessageId(myMessage.MessageId);

                        var tuple = await Command(myMessage);
                        await SendMessage(tuple.model);

                    }

                    _isSendingMessage = false;
                }
            }
            catch (Exception e)
            {
                _isSendingMessage = false;
                return CustomError(e);
            }
            return CustomResult();
        }

        [HttpPost, Route("receiveMessage")]
        public async Task<IHttpActionResult> ReceiveMessage([FromBody] GetMessagesInput json)
        {
            try
            {
                await _configService.UpdateLastMessageId(json.Mesage.MessageId);
                var tuple = await Command(json.Mesage);

                if (json.Type == MessageBehaviourTypeEnum.API)
                {

                    if (!tuple.toast) await SendMessage(tuple.model);
                    return Ok(new { bot_keypad = tuple.model.Keypad, text_message = tuple.toast ? tuple.model.Text : "" });

                }

                await SendMessage(tuple.model);

                return CustomResult();
            }
            catch (Exception exception)
            {
                return CustomError(exception);
            }
        }

        [HttpPost, Route("searchSelection")]
        public async Task<IHttpActionResult> SearchSelection([FromBody] SearchSelectionInput json)
        {
            try
            {
                if (json.SelectionId == "province") // استان
                {
                    var provinceList = await _provinceService.SearchProvince(json.SearchText, json.Limit);

                    var buttonSimpleList = new List<ButtonSimpleModel>();
                    foreach (var province in provinceList)
                    {
                        buttonSimpleList.Add(new ButtonSimpleModel
                        {
                            Type = ButtonSimpleTypeEnum.TextOnly,
                            Text = province.ProvinceNameFa,
                            ImageUrl = null
                        });
                    }

                    return Ok(new { items = buttonSimpleList });
                }
                
                return CustomResult();
            }
            catch (Exception exception)
            {
                return CustomError(exception);
            }
        }

        [HttpPost, Route("getSelection")]
        public async Task<IHttpActionResult> GetSelection([FromBody] GetSelectionInput json)
        {
            json.FirstIndex = json.FirstIndex - 1;

            try
            {


                if (json.SelectionId == "province") // استان
                {
                    var count = await _provinceService.GetProvinceCount();

                    if (json.FirstIndex > count) return Ok(new { items = new List<ButtonSimpleModel>() });
                    if (json.LastIndex > count) json.LastIndex = count;

                    var provinceList = await _provinceService.GetProvinceList(json.FirstIndex, json.LastIndex);

                    var buttonSimpleList = new List<ButtonSimpleModel>();
                    foreach (var province in provinceList)
                    {
                        buttonSimpleList.Add(new ButtonSimpleModel
                        {
                            Type = ButtonSimpleTypeEnum.TextOnly,
                            Text = province.ProvinceNameFa,
                            ImageUrl = null
                        });
                    }

                    return Ok(new { items = buttonSimpleList });
                }               

                return CustomResult();
            }
            catch (Exception exception)
            {
                return CustomError(exception);
            }
        }

        #endregion

        #region Methods
        private async Task<(SendMessageInput model, bool toast)> Command(MessageModel myMessage)
        {
            var buttonId = myMessage.AuxData == null ? "" : myMessage.AuxData.ButtonId;
            var chatId = myMessage.ChatId;
            var messageText = myMessage.Text;

            var button = new ButtonEntity();

            var buttonFound = await _buttonService.GetButton(buttonId);
            if (buttonFound != null) button = buttonFound;


            var tuple = await _userDataService.Update(chatId, messageText, button.Id, button.StateId);

            var model = new SendMessageInput
            {
                Keypad = new KeypadModel
                {
                    Rows = new List<KeypadRowModel>()
                },
                ReplyTimeout = Variables.ReplyTimeout,
                ChatId = chatId
            };

            // start
            if (tuple.isNew)
            {
                model.Keypad = await GetKeypad(2);
                model.Text = "عملیات مورد نظر را انتخاب کنید.";

                return (model, false);
            }


            //Extend
            else if (buttonId == "2-1")
            {
                model.Text = "لطفا گزینه ی مورد نظر را انتخاب کنید.";
                //var userInfo = await _userInfoService.SetSocialSecurityServiceType(chatId, SocialSecurityServiceTypeEnum.Extend);
                model.Keypad = await GetKeypad(3);
                return (model, false);
            }
            
            // دستور نامعتبر

            var stateId = tuple.userData.StateId;
            //var userInformation = await _userInfoService.GetUserInfo(model.ChatId);

            //await FixButton(userInformation, model, stateId);
            if (!model.Keypad.Rows.Any())
                model.Keypad = await GetKeypad(2);

            return (model, false);
        }

        private async Task LogException(Exception exception, string chatId = null, string buttonId = null)
        {
            var json = "";
            if (exception is WebException webException)
            {
                using (var stream = webException.Response.GetResponseStream())
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
                {
                    json = await reader.ReadToEndAsync();

                }
            }

            var exceptionLog = new ExceptionLogEntity
            {
                ChatId = chatId,
                Title = buttonId,
                Exception = exception.ToString(),
                WebException = json,

            };

            await _exceptionLogService.Add(exceptionLog);
        }

        private async Task<SendMessagesOutput> SendMessage(SendMessageInput model)
        {
            try
            {
                return await Api.PostAsync<SendMessagesOutput>(BotApi, new { method = "sendMessage", data = model }, _botHeader);
            }
            catch (Exception e)
            {
                await LogException(e, model.ChatId, "SendMessage");
                return null;
            }
        }

        private void SetImage(SendMessageInput model, string buttonCode)
        {
            var button = model.Keypad.Rows.SelectMany(x => x.Buttons).ToList().FirstOrDefault(x => x.Id == buttonCode);
            if (button != null)
            {
                button.ButtonView.ImageUrl = DoneImageUrl;
                button.ButtonView.Type = ButtonSimpleTypeEnum.TextImgThu;
            }
        }

        private void SetDefaultValue(SendMessageInput model, string buttonCode, string input)
        {
            var button = model.Keypad.Rows.SelectMany(x => x.Buttons).ToList().FirstOrDefault(x => x.Id == buttonCode);
            if (button != null)
            {
                if (button.Type == ButtonTypeEnum.Calendar)
                    button.ButtonCalendar.DefaultValue = input;

                else if (button.Type == ButtonTypeEnum.Calendar)
                    button.ButtonCalendar.DefaultValue = input;
                else if (button.Type == ButtonTypeEnum.StringPicker)
                    button.ButtonStringPicker.DefaultValue = input;
                else if (button.Type == ButtonTypeEnum.NumberPicker)
                    button.ButtonNumberPicker.DefaultValue = input;
            }
        }

        private void SetAlert(SendMessageInput model, string buttonCode, string text = null)
        {
            var submitButton = model.Keypad.Rows.SelectMany(x => x.Buttons).ToList().FirstOrDefault(x => x.Id == buttonCode);
            if (submitButton != null)
            {
                submitButton.Type = ButtonTypeEnum.Alert;
                submitButton.ButtonAlert = new ButtonAlertModel { Message = text ?? "لطفا تمامی موارد را تکمیل نمایید." };
            }
        }

        private async Task<KeypadModel> GetKeypadWithoutSpecialButtons(int stateId, string buttonId)
        {
            var buttonList = await _buttonService.GetButtonList(stateId);

            //var newButtonList = buttonList.Where(x => !buttonIds.Contains(x.Code));
            var removedButton = buttonList.FirstOrDefault(x => x.Code == buttonId);
            buttonList = buttonList.Where(x => x.Code != buttonId).ToList();

            if (removedButton != null)
            {
                var newButtonList = new List<ButtonEntity>();
                foreach (var item in buttonList)
                {
                    if (item.Row > removedButton.Row)
                    {
                        item.Row -= 1;
                    }
                    newButtonList.Add(item);
                }
                buttonList = newButtonList;
            }


            buttonList = buttonList.OrderBy(x => x.Row).ThenBy(x => x.Order).ToList();

            var keypad = new KeypadModel() { Rows = new List<KeypadRowModel>() };
            foreach (var button in buttonList)
            {
                if (keypad.Rows.Count < button.Row)
                {

                    keypad.Rows.Add(new KeypadRowModel());
                    keypad.Rows[button.Row - 1].Buttons = new List<ButtonModel>();
                }

                var newButton = new ButtonModel
                {
                    Id = button.Code,
                    Type = button.Type,
                    ButtonView = new ButtonSimpleModel
                    {
                        Type = button.ViewType,
                        Text = button.Text,
                        ImageUrl = button.ImageUrl
                    },
                    BehaviourType = button.BehaviourType
                };


                if (button.Type == ButtonTypeEnum.Selection)
                {
                    newButton.ButtonSelection = JsonConvert.DeserializeObject<ButtonSelectionModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Calendar)
                {
                    newButton.ButtonCalendar = JsonConvert.DeserializeObject<ButtonCalendarModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.NumberPicker)
                {
                    newButton.ButtonNumberPicker = JsonConvert.DeserializeObject<ButtonNumberPickerModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.StringPicker)
                {
                    newButton.ButtonStringPicker = JsonConvert.DeserializeObject<ButtonStringPickerModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Location)
                {
                    newButton.ButtonLocation = JsonConvert.DeserializeObject<ButtonLocationModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Alert)
                {
                    newButton.ButtonAlert = JsonConvert.DeserializeObject<ButtonAlertModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Textbox)
                {
                    newButton.ButtonTextBox = JsonConvert.DeserializeObject<ButtonTextBoxModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Payment)
                {
                    // handled in another method 
                }
                else if (button.Type == ButtonTypeEnum.Call)
                {
                    newButton.ButtonCall = JsonConvert.DeserializeObject<ButtonCallModel>(button.Data);
                }

                keypad.Rows[button.Row - 1].Buttons.Add(newButton);
            }

            return keypad;
        }

        private async Task<KeypadModel> GetKeypad(int stateId)
        {
            var buttonList = await _buttonService.GetButtonList(stateId);
            buttonList = buttonList.OrderBy(x => x.Row).ThenBy(x => x.Order).ToList();

            var keypad = new KeypadModel() { Rows = new List<KeypadRowModel>() };
            foreach (var button in buttonList)
            {
                if (keypad.Rows.Count < button.Row)
                {
                    keypad.Rows.Add(new KeypadRowModel());
                    keypad.Rows[button.Row - 1].Buttons = new List<ButtonModel>();
                }

                var newButton = new ButtonModel
                {
                    Id = button.Code,
                    Type = button.Type,
                    ButtonView = new ButtonSimpleModel
                    {
                        Type = button.ViewType,
                        Text = button.Text,
                        ImageUrl = button.ImageUrl
                    },
                    BehaviourType = button.BehaviourType
                };

                if (button.Type == ButtonTypeEnum.Selection)
                {
                    newButton.ButtonSelection = JsonConvert.DeserializeObject<ButtonSelectionModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Calendar)
                {
                    newButton.ButtonCalendar = JsonConvert.DeserializeObject<ButtonCalendarModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.NumberPicker)
                {
                    newButton.ButtonNumberPicker = JsonConvert.DeserializeObject<ButtonNumberPickerModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.StringPicker)
                {
                    newButton.ButtonStringPicker = JsonConvert.DeserializeObject<ButtonStringPickerModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Location)
                {
                    newButton.ButtonLocation = JsonConvert.DeserializeObject<ButtonLocationModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Alert)
                {
                    newButton.ButtonAlert = JsonConvert.DeserializeObject<ButtonAlertModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Textbox)
                {
                    newButton.ButtonTextBox = JsonConvert.DeserializeObject<ButtonTextBoxModel>(button.Data);
                }
                else if (button.Type == ButtonTypeEnum.Payment)
                {
                    // handled in another method 
                }
                else if (button.Type == ButtonTypeEnum.Call)
                {
                    newButton.ButtonCall = JsonConvert.DeserializeObject<ButtonCallModel>(button.Data);
                }

                keypad.Rows[button.Row - 1].Buttons.Add(newButton);
            }

            return keypad;
        }

        #endregion
        
        #region change Button

        //private async Task FixButton(UserInfoEntity userInfo, SendMessageInput model, int state)
        //{
        //    if (state == 4)
        //        await FixButtons4(userInfo, model);
        //    else if (state == 5)
        //        await FixButtons5(userInfo, model);
        //    else if (state == 6)
        //        await FixButtons6(userInfo, model);
        //    else if (state == 7)
        //        await FixButtons7(userInfo, model);
        //    else if (state == 8)
        //        await FixButtons8(userInfo, model);
        //    else if (state == 13)
        //        await FixButtons13(userInfo, model);
        //    else if (state == 13)
        //        await FixButtons13(userInfo, model);
        //    else if (state == 14)
        //        await FixButtons14(userInfo, model);
        //    else if (state == 15)
        //        await FixButtons15(userInfo, model);
        //    else if (state == 16)
        //        await FixButtons16(userInfo, model);
        //    else if (state == 17)
        //        await FixButtons17(userInfo, model);
        //    else if (state == 18)
        //        await FixButtons18(userInfo, model);
        //    else
        //    {
        //        await GetKeypad(state);
        //    }

        //}

        //private async Task FixButtons4(UserInfoEntity userInfo, SendMessageInput model)
        //{
        //    model.Keypad = await GetKeypad(4);
        //    bool isCompleted = true;
        //    if (userInfo != null)
        //    {
        //        if (!string.IsNullOrEmpty(userInfo.FirstName)) SetImage(model, "4-1"); else isCompleted = false;
        //        if (!string.IsNullOrEmpty(userInfo.LastName)) SetImage(model, "4-2"); else isCompleted = false;
        //        if (!string.IsNullOrEmpty(userInfo.FatherName)) SetImage(model, "4-3"); else isCompleted = false;
        //        if (!string.IsNullOrEmpty(userInfo.NationalCode)) SetImage(model, "4-4"); else isCompleted = false;
        //        if (!string.IsNullOrEmpty(userInfo.PolicyId)) SetImage(model, "4-5"); else isCompleted = false;
        //        if (userInfo.SocialSecurityBranchId.HasValue) SetImage(model, "4-6"); else isCompleted = false;
        //        if (!string.IsNullOrEmpty(userInfo.BirthDate))
        //        {
        //            SetImage(model, "4-7");
        //            SetDefaultValue(model, "4-7", userInfo.BirthDate);
        //        }
        //        else
        //        {
        //            var time = DateTime.Now;
        //            string now = "" + time.Year + time.Month + time.Day;
        //            isCompleted = false;
        //            SetDefaultValue(model, "4-7", now);
        //        }
        //        if (userInfo.Gender.HasValue)
        //        {
        //            SetImage(model, "4-8");
        //            SetDefaultValue(model, "4-8", GetEnumValue(userInfo.Gender.Value));
        //        }
        //        else isCompleted = false;

        //        if (!string.IsNullOrEmpty(userInfo.Mobile)) SetImage(model, "4-9"); else isCompleted = false;

        //        if (!isCompleted) SetAlert(model, "4-10", "تمام مشخصات را تکمیل کنید");
        //    }
        //}

        

        #endregion change Button


    }
}
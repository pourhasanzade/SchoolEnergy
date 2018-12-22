using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RobokaBimeBazar.DAL;
using RobokaBimeBazar.Domain.Entity;
using RobokaBimeBazar.Service.Interface;

namespace RobokaBimeBazar.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly ApplicationDbContext _context;

        public UserDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDataEntity> GetUserData(string chatId)
        {
            return await _context.UserData.Where(x => x.ChatId == chatId).FirstOrDefaultAsync();
        }
        
        public async Task<(UserDataEntity userData, bool isNew)> Update(string chatId, string input, int buttonId, int stateId)
        {
            var userDataInDb = await _context.UserData.Where(x => x.ChatId == chatId).FirstOrDefaultAsync();
            if (userDataInDb == null)
            {
                var userData = new UserDataEntity
                {
                    ChatId = chatId,
                    ButtonId = 0,
                    Input = input,
                    StateId = 2
                };
                _context.UserData.Add(userData);
                await _context.SaveChangesAsync();
                return (userData, true);
            }
            else
            {
                userDataInDb.ButtonId = buttonId;
                userDataInDb.Input = input;
                if(stateId != 0) userDataInDb.StateId = stateId;
                await _context.SaveChangesAsync();
                return (userDataInDb,false);
            }

        }
    }
}
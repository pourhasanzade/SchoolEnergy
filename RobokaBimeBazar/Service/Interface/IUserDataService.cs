using System.Threading.Tasks;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.Service.Interface
{
    public interface IUserDataService
    {
        //Task<UserInformationEntity> GetLastUserInformation(string chatId);
        //Task<UserInformationEntity> Add(UserInformationEntity entity);

        Task<UserDataEntity> GetUserData(string chatId);
        Task<(UserDataEntity userData, bool isNew)> Update(string chatId, string input, int buttonId, int stateId);
    }
}
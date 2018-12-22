using System.Collections.Generic;
using System.Threading.Tasks;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.Service.Interface
{
    public interface IButtonService
    {
        Task<ButtonEntity> GetButton(string code);
        Task<List<ButtonEntity>> GetButtonList(int stateId);
    }
}
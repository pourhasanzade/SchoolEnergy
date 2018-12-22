using System.Threading.Tasks;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.Service.Interface
{
    public interface IConfigService
    {
        Task UpdateLastMessageId(string messageId);
        Task<ConfigEntity> GetConfig();
    }
}
using System.Threading.Tasks;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.Service.Interface
{
    public interface IExceptionLogService
    {
        Task<ExceptionLogEntity> Add(ExceptionLogEntity exceptionLog);
    }
}

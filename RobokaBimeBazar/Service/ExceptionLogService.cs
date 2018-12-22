using System.Threading.Tasks;
using RobokaBimeBazar.DAL;
using RobokaBimeBazar.Domain.Entity;
using RobokaBimeBazar.Service.Interface;

namespace RobokaBimeBazar.Service
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly ApplicationDbContext _context;

        public ExceptionLogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ExceptionLogEntity> Add(ExceptionLogEntity exceptionLog)
        {
            _context.ExceptionLogs.Add(exceptionLog);
            await _context.SaveChangesAsync();

            return exceptionLog;
        }
    }
}
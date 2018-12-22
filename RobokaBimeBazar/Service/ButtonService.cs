using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using RobokaBimeBazar.DAL;
using RobokaBimeBazar.Domain.Entity;
using RobokaBimeBazar.Service.Interface;

namespace RobokaBimeBazar.Service
{
    public class ButtonService : IButtonService
    {
        private readonly ApplicationDbContext _context;

        public ButtonService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<List<ButtonEntity>> GetButtonList()
        {
            if (MemoryCache.Default.Get("ButtonList") is List<ButtonEntity> result)
            {
                // do nothing
            }
            else
            {
                result = await _context.Buttons.ToListAsync();
                if (result.Count > 0)
                    MemoryCache.Default.Add("ButtonList", result, new CacheItemPolicy
                    {
                        AbsoluteExpiration = DateTime.Now.AddSeconds(1800)
                    });
            }

            return result;
        }

        public async Task<ButtonEntity> GetButton(string code)
        {
            var buttonList = await GetButtonList();
            return buttonList.FirstOrDefault(x => x.Code == code);
        }

        public async Task<List<ButtonEntity>> GetButtonList(int stateId)
        {
            var buttonList = await GetButtonList();
            return buttonList.Where(x => x.StateId == stateId).ToList();
        }







    }
}
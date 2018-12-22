﻿using System.Data.Entity;
using System.Threading.Tasks;
using RobokaBimeBazar.DAL;
using RobokaBimeBazar.Domain.Entity;
using RobokaBimeBazar.Service.Interface;

namespace RobokaBimeBazar.Service
{
    public class ConfigService : IConfigService
    {
        private readonly ApplicationDbContext _context;

        public ConfigService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateLastMessageId(string messageId)
        {
            var config = await _context.Configs.FirstOrDefaultAsync();
            config.LastMessageId = messageId;
            await _context.SaveChangesAsync();
        }

        public async Task<ConfigEntity> GetConfig()
        {
            return await _context.Configs.FirstOrDefaultAsync();
        }
    }
}
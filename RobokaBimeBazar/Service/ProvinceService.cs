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
    public class ProvinceService : IProvinceService
    {
        private readonly ApplicationDbContext _context;

        public ProvinceService(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public async Task<List<ProvinceEntity>> LoadProvinces()
        {

        }*/


        private async Task<List<ProvinceEntity>> GetProvincesList()
        {
            if (MemoryCache.Default.Get("ProvinceList") is List<ProvinceEntity> result)
            {
                // do nothing
            }
            else
            {
                result = await _context.Provinces.ToListAsync();
                if (result.Count > 0)
                    MemoryCache.Default.Add("ProvinceList", result, new CacheItemPolicy
                    {
                        AbsoluteExpiration = DateTime.Now.AddSeconds(1800)
                    });
            }

            return result;
        }

        private async Task<List<CityEntity>> GetCitiesList()
        {
            if (MemoryCache.Default.Get("CityList") is List<CityEntity> result)
            {
                // do nothing
            }
            else
            {
                result = await _context.Cities.ToListAsync();
                if (result.Count > 0)
                    MemoryCache.Default.Add("CityList", result, new CacheItemPolicy
                    {
                        AbsoluteExpiration = DateTime.Now.AddSeconds(1800)
                    });
            }

            return result;
        }


        public async Task<int> GetProvinceCount()
        {
            var list =  await GetProvincesList();
            return list.Count();
        }

        public async Task<List<ProvinceEntity>> GetProvinceList(int first, int last)
        {
            var list = await GetProvincesList();
            return list.OrderBy(x => x.ProvinceNameFa).Skip(first).Take(last - first).ToList();
        }

        public async Task<ProvinceEntity> GetProvinceByNameFa(string province)
        {
            var list = await GetProvincesList();
            return list.FirstOrDefault(x => x.ProvinceNameFa == province);
        }

        public async Task<ProvinceEntity> GetProvinceById(int id)
        {
            var list = await GetProvincesList();
            return list.FirstOrDefault(x => x.Id == id);
        }

        public async Task<ProvinceEntity> GetProvinceByName(string input)
        {
            var list = await GetProvincesList();
            return list.FirstOrDefault(x => x.ProvinceName == input);
        }


        public async Task<int> GetCityCount(int provinceId)
        {
            var list = await GetCitiesList();
            return list.Count();
        }

        public async Task<CityEntity> GetCityByNameFa(string city)
        {
            var list = await GetCitiesList();
            return list.FirstOrDefault(x => x.NameFa == city);
        }

        public async Task<CityEntity> GetCityByName(string city)
        {
            var list = await GetCitiesList();
            return list.FirstOrDefault(x => x.Name == city);
        }

        public async Task<CityEntity> GetCityById(int id)
        {
            var list = await GetCitiesList();
            return list.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<CityEntity>> GetCityList(int provinceId, int first, int last)
        {
            var list = await GetCitiesList();
            return list.OrderBy(x => x.NameFa).Where(x => x.ProvinceId == provinceId).Skip(first).Take(last - first).ToList();
        }

        public async Task<List<ProvinceEntity>> SearchProvince(string searchText, int limit)
        {
            var list = await GetProvincesList();
            return list.Where(x => x.ProvinceNameFa.Contains(searchText)).Take(limit).ToList();
        }

        public async Task<List<CityEntity>> SearchCity(int provinceId, string searchText, int limit)
        {
            var list = await GetCitiesList();
            return list.Where(x => x.ProvinceId == provinceId && x.NameFa.Contains(searchText)).Take(limit).ToList();
        }
    }
}
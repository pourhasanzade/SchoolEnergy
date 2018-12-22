using System.Collections.Generic;
using System.Threading.Tasks;
using RobokaBimeBazar.Domain.Entity;

namespace RobokaBimeBazar.Service.Interface
{
    public interface IProvinceService
    {
        #region Province
        Task<int> GetProvinceCount();
        Task<List<ProvinceEntity>> GetProvinceList(int first, int last);
        Task<ProvinceEntity> GetProvinceByNameFa(string province);
        Task<ProvinceEntity> GetProvinceByName(string province);
        Task<ProvinceEntity> GetProvinceById(int id);

        Task<List<ProvinceEntity>> SearchProvince(string searchText, int limit);
        #endregion

        #region City
        Task<int> GetCityCount(int provinceId);
        Task<List<CityEntity>> GetCityList(int provinceId, int first, int last);
        Task<CityEntity> GetCityByNameFa(string city);
        Task<CityEntity> GetCityByName(string city);
        Task<CityEntity> GetCityById(int id);
        Task<List<CityEntity>> SearchCity(int provinceId, string searchText, int limit);
        #endregion
    }
}
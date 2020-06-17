using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IBikeService
    {
        void CreateBike(CreateBikeDTO bike);
        List<BikeResultDTO> GetBikes();
        List<BikeResultDTO> GetBikesByFilter(int minPrice, int maxPrice, int personId, int minDiameter, int maxDiameter, int brandId, List<int> typeIds);
        BikeResultDTO GetBikeById(int id);
    }
}

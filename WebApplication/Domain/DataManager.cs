using WebApplication.Domain.Repositories.Abstract;

namespace WebApplication.Domain
{
    public class DataManager
    {
        public IDistrictRepository Districts { get; set; }
        public IShawarmaPlaceRepository ShawarmaPlaces { get; set; }

        public DataManager(IDistrictRepository districts, IShawarmaPlaceRepository shawarmaPlaces)
        {
            Districts = districts;
            ShawarmaPlaces = shawarmaPlaces;
        }
    }
}
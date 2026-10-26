using WebApplication.Domain.Repositories.Abstract;

namespace WebApplication.Domain
{
    public class DataManager
    {
        public IDistrictRepository Districts { get; set; }
        public IShawarmaPlaceRepository ShawarmaPlaces { get; set; }
        public IReviewRepository Reviews { get; set; }


        public DataManager(IDistrictRepository districts, IShawarmaPlaceRepository shawarmaPlaces, IReviewRepository reviews)
        {
            Districts = districts;
            ShawarmaPlaces = shawarmaPlaces;
            Reviews = reviews;
        }
    }
}
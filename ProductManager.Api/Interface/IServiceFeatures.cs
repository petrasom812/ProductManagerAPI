using ProductManger.Api.Dtos;

namespace ProductManager.Api.Interface
{
    public interface IServiceFeatures
    {
        Task<List<FeatureDto>> GetFeaturesAsync();
        Task<FeatureDto> AddFeatureAsync(string title, string description, string priority);
        Task<bool> UpdateFeatureAsync(int id, string title, string description, string priority, bool isComleted);
        Task<bool> DeleteFeatureAsync(int id);
    }
}
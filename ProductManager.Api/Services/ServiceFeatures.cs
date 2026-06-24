using ProductManger.Api.Models;

namespace ProductManger.Api.Services
{
    public class ServiceFeatures
    {
        private List<FeatureModel> features = new();

        // View all features
        public List<FeatureModel> GetFeatures()
        {
            return features.ToList();
        }
        // Create a feature
        public FeatureModel AddFeature(string title, string description, string priority)
        {
            var feature = new FeatureModel
            {
                Id = features.Count + 1,
                Title = title,
                Description = description,
                Priority = priority,
                IsCompleted = false
            };
            features.Add(feature);
            return feature;
        }
        // Update feature details and completion status
        public bool UpdateFeature(int id, string title, string description, string priority, bool isComleted) 
        {
            var feature = features.FirstOrDefault(f => f.Id == id);
            
            if(feature == null)
                return false;
            feature.Title = title;
            feature.Description = description;
            feature.Priority = priority;
            feature.IsCompleted = isComleted;
            return true;
        }
        // Delete feature
        public bool DeleteFeature(int id)
        {
            var feature = features.FirstOrDefault(f => f.Id == id);
            if(feature == null)
                return false;
            features.Remove(feature);
            return true;
        }
    }
}
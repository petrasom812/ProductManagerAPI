namespace ProductManger.Api.Models
{
    public class FeatureModel
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Priority {get; set;} = string.Empty;
        public bool IsCompleted {get; set;}
    }
}
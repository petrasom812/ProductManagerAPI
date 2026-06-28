using Microsoft.EntityFrameworkCore;
using ProductManger.Api.Models;
using ProductManger.Api.Data;
using ProductManger.Api.Dtos;
using ProductManager.Api.Interface;

namespace ProductManger.Api.Services
{
    public class ServiceFeatures : IServiceFeatures
    {
        private readonly AppDbContext _context;

        public ServiceFeatures(AppDbContext context)
        {
            _context = context;
        }

        // View all features
        public async Task<List<FeatureDto>> GetFeaturesAsync()
        {
            var features = await _context.Features.ToListAsync();

            return features.Select(f => new FeatureDto
            {
                Id = f.Id,
                Title = f.Title,
                Description = f.Description,
                Priority = f.Priority,
                IsCompleted = f.IsCompleted
            }).ToList();
        }
        // Create a feature
        public async Task<FeatureDto> AddFeatureAsync(string title, string description, string priority)
        {
            var feature = new FeatureModel
            {
                Title = stringValidation(title),
                Description = stringValidation(description),
                Priority = stringValidation(priority),
                IsCompleted = false
            };
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return new FeatureDto
            {
                Id = feature.Id,
                Title = feature.Title,
                Description = feature.Description,
                Priority = feature.Priority,
                IsCompleted = feature.IsCompleted
            };
        }
        // Update feature details and completion status
        public async Task<bool> UpdateFeatureAsync(int id, string title, string description, string priority, bool isComleted) 
        {
            var feature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id);
            
            if(feature == null)
                return false;
            feature.Title = stringValidation(title);
            feature.Description = stringValidation(description);
            feature.Priority = stringValidation(priority);
            feature.IsCompleted = isComleted;

            await _context.SaveChangesAsync();
            return true;
        }
        // Delete feature
        public async Task<bool> DeleteFeatureAsync(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            if(feature == null)
                return false;
            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return true;
        }
        public string stringValidation(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value can not be null or whitespace.");
            return value;
        }
    }
}
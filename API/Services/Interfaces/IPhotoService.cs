using CloudinaryDotNet.Actions;

namespace API.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file, int height, int width);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
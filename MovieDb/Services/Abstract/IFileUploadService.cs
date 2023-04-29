namespace MovieDb.Services.Abstract
{
    public interface IFileUploadService
    {
        public string UploadFile(IFormFile file);
    }
}

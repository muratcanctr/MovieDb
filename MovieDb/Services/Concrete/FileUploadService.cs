using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
    public class FileUploadService : IFileUploadService
    {
        [HttpPost]
        public  string UploadFile(IFormFile file)
        {
           

            // Dosya adını al
            var fileName = Path.GetFileName(file.FileName);

            // Yeni bir dosya adı oluştur
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

            // Dosyayı kaydetmek için tam dosya yolu
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

            // Dosyayı diske kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Movie modelindeki ImagePath özelliğine dosya yolu kaydet
            var path = "/uploads/" + newFileName;

            

            return path;
        }
    }
}

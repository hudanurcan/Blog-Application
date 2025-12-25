using BlogApp.Application.Exceptions.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Exceptions.Concrete
{
    public class ErrorHandler : IErrorHandler
    {
        // Delegate ile çalışan bir metodun hata yönetimi (değer döndüren)
        public async Task<T> ExecuteWithErrorHandling<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (DbUpdateException ex)
            {
                // Veritabanı hatalarını yakala ve anlamlı mesaj ver
                var userFriendlyMessage = GetUserFriendlyMessage(ex);
                Console.WriteLine($"Database Error: {ex.Message}");
                throw new CustomException(userFriendlyMessage, 400); // 400 BadRequest
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new CustomException("Bir hata oluştu: " + ex.Message, 500); // 500 Internal Server Error
            }
        }

        // Değer döndürmeyen bir metodun hata yönetimi
        public async Task ExecuteWithErrorHandling(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (DbUpdateException ex)
            {
                var userFriendlyMessage = GetUserFriendlyMessage(ex);
                Console.WriteLine($"Database Error: {ex.Message}");
                throw new CustomException(userFriendlyMessage, 400); // 400 BadRequest
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new CustomException("Bir hata oluştu: " + ex.Message, 500); // 500 Internal Server Error
            }
        }

        // PRIVATE METOTS
        private string GetUserFriendlyMessage(DbUpdateException ex)
        {
            string errorMessage = ex.InnerException?.Message ?? ex.Message;

            // Handle unique constraint violations
            if (errorMessage.Contains("duplicate") || errorMessage.Contains("unique"))
            {
                return "Bu data zaten mevcut!";
            }

            // General database error
            return "Veritabanı işlemi sırasında bir hata oluştu.";
        }
    }
}

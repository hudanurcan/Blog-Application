using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Exceptions.Abstract
{
    public interface IErrorHandler
    {
        Task ExecuteWithErrorHandling(Func<Task> action);
        Task<TResult> ExecuteWithErrorHandling<TResult>(Func<Task<TResult>> action); // hazır func delegate
    }
}

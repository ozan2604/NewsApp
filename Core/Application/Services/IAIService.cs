using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAIService
    {
        Task<string> GetResponseAsync(string prompt, string sourceModel);
    }
}

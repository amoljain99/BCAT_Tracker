using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBcatService
    {
        void GetaData<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);
    }
}

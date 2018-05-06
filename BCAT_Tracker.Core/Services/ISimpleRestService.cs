using System;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface ISimpleRestService
    {
        void GetAsync<T>(Action<T> successAction, Action<Exception> errorAction);
        void PostAsync<T>(object obj, Action<T> successAction, Action<Exception> errorAction);
        void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);
    }
}
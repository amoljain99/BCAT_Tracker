using BCAT_Tracker.Core;
using BCAT_Tracker.Core.Services;
using System;

namespace Books.Core.Services
{
    public interface IBooksService
    {
        void StartSearchAsync(string whatFor, Action<BookSearchResult> success, Action<Exception> error);
    }
}
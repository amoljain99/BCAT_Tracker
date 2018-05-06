using BCAT_Tracker.Core;
using BCAT_Tracker.Core.Services;
using System;
using System.Collections.Generic;

namespace Books.Core.Services
{
    public class BooksService
        : IBooksService
    {
        private readonly ISimpleRestService _simpleRestService;

        public BooksService(ISimpleRestService simpleRestService)
        {
            _simpleRestService = simpleRestService;
        }

         public async  void StartSearchAsync(string whatFor, Action<BookSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}",
                                             Uri.EscapeDataString(whatFor));

            //BookSearchResult res = await _simpleRestService.GetAsync<BookSearchResult>(); 
            List<int> ob = new List<int>();
            ob.Add(133);
              _simpleRestService.PostAsync<BookSearchResult>(new GetSafetyNote() { apptype = 1, patientid = ob, token = "sdfsdfsdf", username ="appstore" }, success, error);

            //_simpleRestService.callmethod("https://www.googleapis.com", address, System.Threading.CancellationToken.None);


            //_simpleRestService.MakeRequest<BookSearchResult>(address,
            //    "GET", success, error);
        } 
    } 
}

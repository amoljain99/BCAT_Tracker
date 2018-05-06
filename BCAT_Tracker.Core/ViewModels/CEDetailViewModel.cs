using BCAT_Tracker.Core.Services;
using Books.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace BCAT_Tracker.Core 
{
    public class CEDetailViewModel : MvxViewModel
    {
        public CEDetailViewModel(IBooksService books)
        {
            _books = books;
        }
        private readonly IBooksService _books; 
       
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value; RaisePropertyChanged(() => SearchTerm);  
            }
        }

        public MvxCommand ServiceCall
        {
            get
            {
                return new MvxCommand(Update);
            }
        }

        private List<BookSearchItem> _results;
        public List<BookSearchItem> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
        }

        private void Update()
        {
            _books.StartSearchAsync("s",  
                        result => Results = result.items,
                       error => { });
        }
        
        public void call()
        {

        }
    } 
  
}

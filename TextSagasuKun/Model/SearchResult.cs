using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;

namespace TextSagasuKun.Model
{
    public class SearchResult : BindableBase
    {
        private string pattern = string.Empty;
        private List<string> results = new List<string>();

        public string Pattern { get => pattern; set => SetProperty(ref pattern, value); }

        public List<string> Results
        {
            get => results;
            set
            {
                if (SetProperty(ref results, value))
                {
                    RaisePropertyChanged(nameof(FirstResult));
                }
            }
        }

        public string FirstResult => Results.FirstOrDefault() != null ? Results.First() : string.Empty;
    }
}
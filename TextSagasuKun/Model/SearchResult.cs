using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;

namespace TextSagasuKun.Model
{
    public class SearchResult : BindableBase
    {
        private string pattern = string.Empty;
        private List<string> results = new List<string>();
        private int index;

        public string Pattern { get => pattern; set => SetProperty(ref pattern, value); }

        public List<string> Results
        {
            get => results;
            set
            {
                if (SetProperty(ref results, value))
                {
                    RaisePropertyChanged(nameof(FirstResult));
                    RaisePropertyChanged(nameof(MultiMatching));
                }
            }
        }

        public string FirstResult => Results.FirstOrDefault() != null ? Results.First() : string.Empty;

        public bool MultiMatching => Results.Count > 1;

        public int Index { get => index; set => SetProperty(ref index, value); }
    }
}
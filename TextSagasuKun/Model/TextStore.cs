using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Mvvm;

namespace TextSagasuKun.Model
{
    public class TextStore : BindableBase
    {
        public List<string> Texts { get; set; } = new List<string>();

        public SearchResult Search(string pattern)
        {
            return new SearchResult()
            {
                Results = Texts.Where(text => Regex.IsMatch(text, pattern)).ToList(),
            };
        }
    }
}
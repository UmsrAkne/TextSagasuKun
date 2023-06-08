using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Mvvm;

namespace TextSagasuKun.Model
{
    public class TextStore : BindableBase
    {
        private List<string> texts = new List<string>();

        public List<string> Texts { get => texts; set => SetProperty(ref texts, value); }

        public List<string> Search(string pattern)
        {
            return Texts.Where(text => Regex.IsMatch(text, pattern)).ToList();
        }
    }
}
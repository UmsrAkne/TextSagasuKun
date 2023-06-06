using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Mvvm;

namespace TextSagasuKun.Model
{
    public class TextStore : BindableBase
    {
        public List<string> Texts { get; set; } = new List<string>();

        public List<string> Search(string pattern)
        {
            return Texts.Where(text => Regex.IsMatch(text, pattern)).ToList();
        }
    }
}
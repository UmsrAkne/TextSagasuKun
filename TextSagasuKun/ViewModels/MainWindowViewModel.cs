using System.Collections.ObjectModel;
using Prism.Mvvm;
using TextSagasuKun.Model;

namespace TextSagasuKun.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public TextStore TextStore { get; } = new TextStore();

        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>()
        {
            new SearchResult(),
        };

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
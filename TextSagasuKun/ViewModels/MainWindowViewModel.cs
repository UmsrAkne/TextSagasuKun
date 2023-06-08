using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using TextSagasuKun.Model;

namespace TextSagasuKun.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private int selectedIndex;

        public TextStore TextStore { get; } = new TextStore();

        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>()
        {
            new SearchResult(),
        };

        public string Title { get => title; set => SetProperty(ref title, value); }

        public int SelectedIndex { get => selectedIndex; set => SetProperty(ref selectedIndex, value); }

        public DelegateCommand<SearchResult> SearchCommand => new DelegateCommand<SearchResult>(searchResult =>
        {
            if (searchResult == null || string.IsNullOrWhiteSpace(searchResult.Pattern))
            {
                return;
            }

            searchResult.Results = TextStore.Search(searchResult.Pattern);
        });

        public DelegateCommand<ListView> AddResultLineCommand => new DelegateCommand<ListView>(listView =>
        {
            if (SelectedIndex < 0)
            {
                return;
            }

            SearchResults.Insert(SelectedIndex + 1, new SearchResult());
            listView.UpdateLayout();
            listView.ItemContainerGenerator.ContainerFromIndex(SelectedIndex + 1).FindDescendant<TextBox>().Focus();
        });

        public void LoadBaseText(string text)
        {
            TextStore.Texts = Regex.Split(text, "\n|\r\n|\r").ToList();
        }
    }
}
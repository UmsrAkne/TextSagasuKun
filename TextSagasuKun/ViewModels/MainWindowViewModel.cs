using Prism.Mvvm;

namespace TextSagasuKun.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
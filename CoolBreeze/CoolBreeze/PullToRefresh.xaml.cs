using CoolBreeze.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoolBreeze
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PullToRefresh : ContentPage
    {
        public PullToRefresh()
        {
            InitializeComponent();
            this.BindingContext = new PullToRefreshViewModel();

        }
    }

    public class PullToRefreshViewModel : ObservableBase
    {
        public ICommand SearchCommand { get; set; }
        public PullToRefreshViewModel()
        {
            SearchCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await Task.Delay(500);
                Results = new ObservableCollection<string>();
                for (int i = 0; i < 10; i++)
                {
                    Results.Add($"Test{i}");
                }
                IsRefreshing = false;
            });
            IsRefreshing = false;
        }

        private ObservableCollection<string> results;

        public ObservableCollection<string> Results
        {
            get { return results; }
            set { this.SetProperty(ref this.results, value); }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { this.SetProperty(ref this.isRefreshing, value); }
        }


    }

}

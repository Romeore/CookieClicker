using CookieClicker.Model;
using CookieClicker.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CookieClicker.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private double _cookies;
        private double _cookiesPerSecond;
        private ObservableCollection<ItemModel> _items;
        private ItemModel _multiplyItem;

        public ObservableCollection<ItemModel> Items
        {
            get { return _items; }
            set { Set(ref _items, value); }
        }

        public double Cookies
        {
            get
            {
                return _cookies;
            }
            set
            {
                UserSettings.Cookies = value;
                Set(ref _cookies, value);
            }
        }

        public double CookiesPerSecond
        {
            get
            {
                return _cookiesPerSecond;
            }
            set
            {
                Set(ref _cookiesPerSecond, value);
            }
        }

        public ICommand CookieCommand { get; set; }

        public ICommand PurchaseCommand { get; set; }

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadSettings();
            PurchaseCommand = new RelayCommand<ItemModel>(Purchase);
            CookieCommand = new RelayCommand(Cookie);
            Task.Factory.StartNew(CookiesInterval);
        }

        private void LoadSettings()
        {
            Cookies = UserSettings.Cookies;
            Items = new ObservableCollection<ItemModel>(_dataService.GetItems());
            foreach (var item in Items)
            {
                CookiesPerSecond += item.CookieReward * item.Amount;
            }
            _multiplyItem = Items[Items.Count - 1];
        }

        private async void CookiesInterval()
        {
            while (true)
            {
                await Task.Delay(1000);
                Cookies += CookiesPerSecond;
            }
        }

        public void Purchase(ItemModel selectedItem)
        {
            if (Cookies >= selectedItem.StartingPrice)
            {
                Cookies -= selectedItem.StartingPrice;
                selectedItem.Amount++;
                CookiesPerSecond += selectedItem.CookieReward;
            }
            else
            {
                MessageBox.Show("Not enough cookies !");
            }
        }

        private void Cookie()
        {
            Cookies += _multiplyItem.Amount;
        }
    }
}

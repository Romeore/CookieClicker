using CookieClicker.Model;
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

        private ObservableCollection<ItemModel> _items;
        private double _cookies;
        private double _cookiesPerSecond;
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
                UserSettings.CookiesPerSecond = value;
                Set(ref _cookiesPerSecond, value);
            }
        }

        public ICommand CookieCommand { get; set; }

        public ICommand PurchaseCommand { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemModel>();
            Items.Add(new ItemModel() { Name = "Cursor", StartingPrice = 15, Amount = 0, CookieReward = 0.1 });
            Items.Add(new ItemModel() { Name = "Grandma", StartingPrice = 100, Amount = 0, CookieReward = 0.5 });
            Items.Add(new ItemModel() { Name = "Farm", StartingPrice = 200, Amount = 0, CookieReward = 1 });
            Items.Add(new ItemModel() { Name = "Mine", StartingPrice = 500, Amount = 0, CookieReward = 2 });
            Items.Add(new ItemModel() { Name = "Factory", StartingPrice = 1000, Amount = 0, CookieReward = 5 });
            Items.Add(new ItemModel() { Name = "Bank", StartingPrice = 2000, Amount = 0, CookieReward = 8 });
            Items.Add(new ItemModel() { Name = "Temple", StartingPrice = 5000, Amount = 0, CookieReward = 10 });
            Items.Add(new ItemModel() { Name = "Wizard tower", StartingPrice = 10000, Amount = 0, CookieReward = 15 });
            Items.Add(new ItemModel() { Name = "Shipment", StartingPrice = 25000, Amount = 0, CookieReward = 25 });
            Items.Add(new ItemModel() { Name = "Alchemy lab", StartingPrice = 50000, Amount = 0, CookieReward = 50 });
            _multiplyItem = new ItemModel() { Name = "Multiply", StartingPrice = 100, Amount = 1 };
            Items.Add(_multiplyItem);
            PurchaseCommand = new RelayCommand<ItemModel>(Purchase);
            CookieCommand = new RelayCommand(Cookie);
            Cookies = UserSettings.Cookies;
            CookiesPerSecond = UserSettings.CookiesPerSecond;
            Task.Factory.StartNew(CookiesInterval);
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
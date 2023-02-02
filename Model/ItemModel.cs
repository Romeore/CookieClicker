using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.Model
{
    public class ItemModel : ObservableObject
    {
        private string _name;
        private int _startingPrice;
        private int _amount;
        private double _cookieReward;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(ref _name, value);
            }
        }

        public int StartingPrice
        {
            get
            {
                return _startingPrice;
            }
            set
            {
                Set(ref _startingPrice, value);
            }
        }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                Set(ref _amount, value);
                RaisePropertyChanged(nameof(Price));
            }
        }

        public int Price
        {
            get
            {
                return _startingPrice * (Amount + 1);
            }
        }

        public double CookieReward
        {
            get
            {
                return _cookieReward;
            }

            set
            {
                Set(ref _cookieReward, value);
            }
        }
    }
}

using CommonServiceLocator;
using CookieClicker.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace CookieClicker.ViewModel
{
    public class ViewModelLocator
    {
        private bool _testMode = false;

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (_testMode)
            {
                SimpleIoc.Default.Register<IDataService, TestDataService>();
            }
            else 
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            
        }
    }
}

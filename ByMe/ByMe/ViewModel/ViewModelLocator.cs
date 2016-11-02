/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ByMe"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/


using ByMe.ViewModel.AdminViewModel;
using ByMe.ViewModel.UserViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ByMe.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}


            SimpleIoc.Default.Register<CarousalViewModel>();
            SimpleIoc.Default.Register<SignUpPageViewModel>();
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<LoginWithGmailViewModel>();
            SimpleIoc.Default.Register<UserSearchViewModel>();

            SimpleIoc.Default.Register<AddItemViewModel>();
            SimpleIoc.Default.Register<MenuItemViewModel>();
            SimpleIoc.Default.Register<LaptopsViewModel>();
            SimpleIoc.Default.Register<DesktopsViewModel>();
            SimpleIoc.Default.Register<KidsViewModel>();
            SimpleIoc.Default.Register<PenDrivesViewModel>();
            SimpleIoc.Default.Register<WomensViewModel>();
            SimpleIoc.Default.Register<MensViewModel>();
            SimpleIoc.Default.Register<ProductDescriptionViewModel>();
            SimpleIoc.Default.Register<EditProductViewModel>();
       

            SimpleIoc.Default.Register<UserKidsViewModel>();
            SimpleIoc.Default.Register<UserLaptopsViewModel>();
            SimpleIoc.Default.Register<UserWomensViewModel>();
            SimpleIoc.Default.Register<UserPenDrivesViewModel>();
            SimpleIoc.Default.Register<UserMensViewModel>();
            SimpleIoc.Default.Register<UserDesktopsViewModel>();
            SimpleIoc.Default.Register<UserProductDescriptionViewModel>();
            SimpleIoc.Default.Register<UserProfileViewModel>();
            SimpleIoc.Default.Register<UserEditProfileViewModel>();
            SimpleIoc.Default.Register<ProceedToCheckoutViewModel>();
            SimpleIoc.Default.Register<UserClothingPageViewModel>();
            SimpleIoc.Default.Register<UserComputerViewModel>();
            SimpleIoc.Default.Register<OrderPlacedViewModel>();
            SimpleIoc.Default.Register<UserMenuItemViewModel>();
            SimpleIoc.Default.Register<UserCartViewModel>();
            SimpleIoc.Default.Register<UserHomeViewModel>();

        }

        public UserSearchViewModel UserSearch
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserSearchViewModel>();
            }
        }


        public UserProductDescriptionViewModel ProductDesc
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserProductDescriptionViewModel>();
            }
        }

        public LoginWithGmailViewModel LoginWithGmail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginWithGmailViewModel>();
            }
        }

        public CarousalViewModel Carousal
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CarousalViewModel>();
            }
        }

        public LoginPageViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            }
        }


        public SignUpPageViewModel SignUp
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SignUpPageViewModel>();
            }
        }

        #region adminviewmodel
        public EditProductViewModel AdminEditProduct
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditProductViewModel>();
            }

        }

        public ProductDescriptionViewModel AdminProduct
{
            get
            {
                return ServiceLocator.Current.GetInstance<ProductDescriptionViewModel>();
            }
        }
        public LaptopsViewModel AdminLaptop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LaptopsViewModel>();
            }
        }

        public DesktopsViewModel AdminDesktop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DesktopsViewModel>();
            }
        }
        public PenDrivesViewModel AdminPenDrives
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PenDrivesViewModel>();
            }
        }
        public KidsViewModel AdminKids
        {
            get
            {
                return ServiceLocator.Current.GetInstance<KidsViewModel>();
            }
        }
        public WomensViewModel AdminWomens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WomensViewModel>();
            }
        }
        public MensViewModel AdminMen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MensViewModel>();
            }
        }
        public AddItemViewModel AddItem
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddItemViewModel>();
            }
        }

        public MenuItemViewModel Menu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuItemViewModel>();
            }
        }
        #endregion

        #region userviewmodel
        public UserHomeViewModel UserHome
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserHomeViewModel>();
            }
        }
        public OrderPlacedViewModel OrderPlaced
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderPlacedViewModel>();
            }
        }

        public UserClothingPageViewModel ClothingTab
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserClothingPageViewModel>();
            }
        }
        public UserComputerViewModel ComputerTab
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserComputerViewModel>();
            }
        }
        public ProceedToCheckoutViewModel Checkout
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProceedToCheckoutViewModel>();
            }
        }
        public UserEditProfileViewModel UserEditProfile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserEditProfileViewModel>();
            }
        }
        public UserProfileViewModel UserProfile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserProfileViewModel>();
            }
        }
        public UserMenuItemViewModel UserMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserMenuItemViewModel>();
            }
        }

        public UserCartViewModel Cart
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserCartViewModel>();
            }
        }
        public UserLaptopsViewModel UserLaptop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserLaptopsViewModel>();
            }
        }
        public UserDesktopsViewModel UserDesktop
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserDesktopsViewModel>();
            }
        }
        public UserPenDrivesViewModel UserPenDrives
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserPenDrivesViewModel>();
            }
        }
        public UserKidsViewModel UserKids
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserKidsViewModel>();
            }
        }
        public UserWomensViewModel UserWomens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserWomensViewModel>();
            }
        }
        public UserMensViewModel UserMen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserMensViewModel>();
            }
        }

        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
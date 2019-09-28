using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public List<CarouselData> MyDataSource { get; set; }
        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public WelcomePage()
        {
            InitializeComponent();

            logoLayout.BackgroundColor = new Color(0, 0, 0, 0.7);

            MyDataSource = new List<CarouselData>() { new CarouselData() { Title = "Welcome", Detail="Sign Up to see the content" },
                                                        new CarouselData() { Title = "Explore", Detail="Explore our library" },
                                                        new CarouselData() { Title = "Win", Detail="Win prizes" }};

            BindingContext = this;

        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            if (width > height)
            {
                videoPlayer.WidthRequest = App.ScreenWidth;
                videoPlayer.HeightRequest = App.ScreenHeight;
            }
            else if (width < height)
            {
                videoPlayer.WidthRequest = App.ScreenWidth / 2;
                videoPlayer.HeightRequest = App.ScreenHeight / 2;
            }

            base.LayoutChildren(x, y, width, height);
        }
    }
}
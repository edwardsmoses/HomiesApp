using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Pages.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryCardView : Frame
    {
        public CategoryCardView()
        {
            InitializeComponent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DevExpress.XamarinForms.Charts;

namespace DXChartsGettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

namespace ChartsExample
{
    public class App : Application
    {
        public App()
        {
            ChartView chart = new ChartView();
            MainPage = new ContentPage
            {
                Content = chart,
            };
        }
    }
}
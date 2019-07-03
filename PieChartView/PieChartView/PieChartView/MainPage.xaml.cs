using DevExpress.XamarinForms.Charts;
using PieChartView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PieChartView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            chart.HorizontalOptions = LayoutOptions.FillAndExpand;
            chart.VerticalOptions = LayoutOptions.FillAndExpand;
            chart.Series.Add(new DonutSeries());
            chart.Series[0].Data = new LandAreaDataAdapter() { ItemsSource = new ViewModel().LandAreas };
        }
    }



    
}
using DevExpress.XamarinForms.Charts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PieChartView
{
    class ViewModel
    {
        public IReadOnlyList<LandAreaItem> LandAreas { get; }

        public ViewModel()
        {
            LandAreas = new List<LandAreaItem>() {
            new LandAreaItem("Russia", 17.098),
            new LandAreaItem("Canada", 9.985),
            new LandAreaItem("People's Republic of China", 9.597),
            new LandAreaItem("United States of America", 9.834),
            new LandAreaItem("Brazil", 8.516),
            new LandAreaItem("Australia", 7.692),
            new LandAreaItem("India", 3.287),
            new LandAreaItem("Others", 81.2)
        };
        }
    }

    class LandAreaItem
    {
        public string CountryName { get; }
        public double Area { get; }

        public LandAreaItem(string countryName, double area)
        {
            this.CountryName = countryName;
            this.Area = area;
        }
    }


    class LandAreaDataAdapter : BindableObject, IPieSeriesData, IChangeableSeriesData
    {
        public const string ItemsSourcePropertyName = "ItemsSource";
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: ItemsSourcePropertyName,
            returnType: typeof(IReadOnlyList<LandAreaItem>),
            declaringType: typeof(LandAreaDataAdapter),
            propertyChanged: OnItemsSourcePropertyChanged
        );

        public event DataChangedEventHandler DataChanged;
        public IReadOnlyList<LandAreaItem> ItemsSource
        {
            get => (IReadOnlyList<LandAreaItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public int GetDataCount() => (ItemsSource == null) ? 0 : ItemsSource.Count;
        public object GetKey(int index) => ItemsSource[index];
        public string GetLabel(int index) => ItemsSource[index].CountryName;
        public double GetValue(int index) => ItemsSource[index].Area;

        static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is LandAreaDataAdapter adapter)) return;
            DataChangedEventHandler handler = adapter.DataChanged;
            if (handler != null)
            {
                handler.Invoke(adapter, DataChangedEventArgs.Reset());
            }
        }
    }


    //class ViewModel
    //{
    //    // ...
    //    readonly Color[] palette;
    //    public Color[] Palette => palette;

    //    public ViewModel()
    //    {
    //        // ...
    //        palette = PaletteLoader.LoadPalette("#9c63ff", "#64c064", "#eead51", "#d2504b", "#4b6bbf", "#2da7b0", "#ce95ff", "#4ba74b");
    //    }
    //}

    static class PaletteLoader
    {
        public static Color[] LoadPalette(params string[] values)
        {
            Color[] colors = new Color[values.Length];
            for (int i = 0; i < values.Length; i++)
                colors[i] = Color.FromHex(values[i]);
            return colors;
        }
    }
}

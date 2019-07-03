using DevExpress.XamarinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GridToData
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        int count;
        // ...

        void OnCalculateCustomSummary(object sender, CustomSummaryEventArgs e)
        {
            if (e.FieldName.ToString() == "Shipped")
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        count = 0;
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        if (!(bool)e.FieldValue)
                            count++;
                        e.TotalValue = count;
                    }
                }

            grid.SortMode = GridSortMode.Multiple;

            grid.Columns["Product.Name"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            grid.Columns["Product.Name"].SortIndex = 0;

            grid.Columns["Quantity"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            grid.Columns["Quantity"].SortIndex = 1;

            grid.Columns["Shipped"].AllowSort = DevExpress.Utils.DefaultBoolean.False;
        }
    }


}

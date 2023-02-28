using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Decor.Data;

namespace Decor.Pages
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private int _page = 0;
        private int _count = 10;
        public List<Product> Products { get; set; }
        public List<Product> ClientsForFilters { get; set; }
        public Dictionary<string, Func<Product, object>> Sortings { get; set; }
        public ProductListPage()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();
            Sortings = new Dictionary<string, Func<Product, object>>
            {
                {"Наименование по убыванию", x => x.Name },
                {"Наименование по возрастанию", x => x.Name },
                {"Стоимость по убыванию", x => x.Coust },
                {"Стоимость по возрастанию", x => x.Coust },
            };

            DataContext = this;

        }
        private void Filter(bool FilterChanged)
        {
            if (FilterChanged)
                _page = 0;


            var searchText = tbSearch.Text.ToLower();
            var sort = cbSort.SelectedItem as string;



            if (sort != null)
            {


                ClientsForFilters = DataAccess.connection.Product.Where(p => p.Name.ToLower().Contains(searchText)).ToList();
                if (sort.Contains("убыванию"))
                    ClientsForFilters.Reverse();



                lvProducts.ItemsSource = ClientsForFilters.Skip(_page * _count).Take(_count);
                lvProducts.Items.Refresh();
                
            }
        }
            private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter(true);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter(true);
        }
    }
}

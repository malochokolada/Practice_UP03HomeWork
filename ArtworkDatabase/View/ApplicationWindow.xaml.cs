using ArtworkDatabase.DbEntity;
using ArtworkDatabase.ViewModel;
using System;
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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace ArtworkDatabase.View
{
    /// <summary>
    /// Логика взаимодействия для ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
       

        public ApplicationWindow(Paint paint)
        {
            InitializeComponent();

            this.DataContext = new AppVM(paint);
        }

        

        public void RefreshData()
        {
            (DataContext as AppVM).LoadData();
        }

        private void btnAddNewInfo_Click(object sender, RoutedEventArgs e)
        {
            var addNewUser = new AddNewInfoWindow();
            addNewUser.Show();
        }

        private void btnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            var editInfoWindow = new AddNewInfoWindow((DataContext as AppVM).SelectedPaint);
            editInfoWindow.Show();
        }

        private void btnDeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AppVM).DeleteSelectedInfo();
        }
    }
}

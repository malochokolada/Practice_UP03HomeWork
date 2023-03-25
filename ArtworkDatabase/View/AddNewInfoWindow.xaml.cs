using ArtworkDatabase.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ArtworkDatabase.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewInfoWindow.xaml
    /// </summary>
    public partial class AddNewInfoWindow : Window
    {

        private Paint _paint;

        public AddNewInfoWindow()
        {
        }

        public AddNewInfoWindow(Paint paint)
        {
          InitializeComponent();

            foreach (var info in App.Current.Windows)
            {
                if (info is ApplicationWindow)
                {
                    this.Owner = info as Window;
                }
            }

            if (paint != null)
            {
                _paint = paint = new Paint();

            }
            else
            {
                _paint = paint;
            }

            this.DataContext = _paint;

        }

        

        private void btnCreate_Click(object sender, RoutedEventArgs e)
         {
            /* using (var db = new Art_GalleryEntities())
             {
                 try
                 {
                     var validateRes = 
                 }
             }*/
         }
    }
}

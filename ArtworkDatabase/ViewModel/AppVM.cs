using ArtworkDatabase.DbEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArtworkDatabase.ViewModel
{
    public class AppVM : BaseVM
    {
        private Paint _selectedpaint;

        private string _paintingTitle;
        private int _years;
        private string _artistName;
        private string _direction;
private ObservableCollection<Paint> _paint;
        public Paint SelectedPaint
        {
            get => _selectedpaint;
            set
            {
                _selectedpaint = value;
                OnPropertyChanged(nameof(SelectedPaint));
            }
        }
       
         public string PaintingTitle
        {
             get => _paintingTitle;

             set
             {
                _paintingTitle = value;
                 OnPropertyChanged(nameof(PaintingTitle));
             }
         }


         public int Years
        {
             get => _years;

             set
             {
                _years = value;
                 OnPropertyChanged(nameof(Years));
             }
         }


         public string ArtistName
        {
             get => _artistName;

             set
             {
                _artistName = value;
                 OnPropertyChanged(nameof(ArtistName));
             }
         }

        public string Direction
        {
            get => _direction;

            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }


        

        public ObservableCollection<Paint> Paint
        {
            get => _paint;
            set
            {
                _paint = value;
                OnPropertyChanged(nameof(Paint));
            }
        }


        public AppVM(Paint paint)
         {
            /*PaintingTitle = paint.UserInfo.PaintingTitle;
            Years = (int)paint.UserInfo.Years;
            ArtistName = paint.UserInfo.ArtistName;
            Direction = paint.UserInfo.Direction;*/
            Paint = new ObservableCollection<Paint>();
            LoadData();

        }
        public void LoadData()
        {

            if(Paint.Count > 0)
            {
                Paint.Clear();
            }

            var paintResult = DbStorage.DB_s.Paint.ToList();

            paintResult.ForEach(elem => Paint?.Add(elem));
            
        }

        public void DeleteSelectedInfo()
        {
            if (!(Paint is null))
            {
                using (var db = new Art_GalleryEntities())
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить выбранный элемент?", "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var infoForDelete = db.Paint.Where(elem => elem.ID == SelectedPaint.ID).FirstOrDefault();
                            db.Paint.Remove(infoForDelete);
                            db.SaveChanges();
                            LoadData();
                            MessageBox.Show("Данные успешно удалены!","Удаление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Удаление", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }



        
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace CinemaOffice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CinemaContainer _cinema = new CinemaContainer();
        public MainWindow()
        {
            InitializeComponent();
            DataCinema.Items.Clear();
            DataTikets.Items.Clear();
            DataContext = _cinema;
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _cinema.MoviesSet.Load();
            _cinema.TiketsSet.Load();
        }

        private void ButtonBase_OnClick_Add(object sender, RoutedEventArgs e)
        {
            var cinema = new Movies()
            {
                Name = NameCinema.Text,
                StartTime = DateStart.DisplayDate
            };

            _cinema.MoviesSet.Add(cinema);
            _cinema.SaveChanges();
        }

        private void ButtonBase_OnClick_Del(object sender, RoutedEventArgs e)
        {
            _cinema.MoviesSet.RemoveRange(DataCinema.SelectedCells.Select(x => (Movies)x.Item));
            _cinema.SaveChanges();
        }

        private void DataCinema_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(e.Column.DisplayIndex != 0)
                _cinema.SaveChanges();
        }

        private void ButtonBase_OnClick_TiketsAdd(object sender, RoutedEventArgs e)
        {
            var tikets = new Tikets()
            {
                Count = int.Parse(CountTikets.Text),
                MoviesID = ((Movies)CinemaCombo.SelectionBoxItem).MovieId,
                Time = DateStart_Tikets.DisplayDate

            };

            _cinema.TiketsSet.Add(tikets);
            _cinema.SaveChanges();
        }

        private void ButtonBase_OnClick_TiketsDel(object sender, RoutedEventArgs e)
        {
            _cinema.TiketsSet.RemoveRange(DataTikets.SelectedCells.Select(x => (Tikets)x.Item));
            _cinema.SaveChanges();
        }
    }
}

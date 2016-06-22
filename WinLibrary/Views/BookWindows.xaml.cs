using System;
using System.ComponentModel;
using System.Windows;
using WinLibrary.DAL;
using WinLibrary.Entity;

namespace WinLibrary.Views
{
    /// <summary>
    /// Interaction logic for BookWindows.xaml
    /// </summary>
    public partial class BookWindows : Window
    {
        public string TitleToShowBeforeFocus = "toto";
        public BookWindows()
        {
            InitializeComponent();
            // Binding sur la VueModele
            this.SaveBookGrid.DataContext = new BookViewModel();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var bookToSave = new Book
            {
                Title = TitleBox.Text,
                Author = AuthorBox.Text,
                Editor = EditorBox.Text,
                PublishedYear = YearBox.Text,
                PagesNumber = FromStringToInt(PagesNumberBox.Text)
            };
            BookDAL.SaveBook(bookToSave);
            this.Close();
        }

        private int FromStringToInt(string inputString)
        {
            int result;
            var intParse = int.TryParse(inputString, out result);
            if (!intParse)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Le nombre de pages doit être un nombre");
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            return result;
        }

        #region TextBoxEvent region
        private void TitleBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TitleBox.Text = String.Empty;
        }

        private void AuthorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            AuthorBox.Text = String.Empty;
        }

        private void EditorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            EditorBox.Text = String.Empty;
        }

        private void YearBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            YearBox.Text = String.Empty;
        }

        private void PagesNumberBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PagesNumberBox.Text = String.Empty;
        }

        //private void TitleBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void AuthorBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void EditorBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void YearBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void PagesNumberBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion TextBoxEvent region
    }

    public class BookViewModel : INotifyPropertyChanged
    {

        public string _bookTitle = "Entrez un titre";

        public string BookTitle
        {
            get { return _bookTitle; }
            set { _bookTitle = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

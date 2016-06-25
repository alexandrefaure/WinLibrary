using System;
using System.Windows;
using WinLibrary.ViewModel;

namespace WinLibrary.Views
{
    /// <summary>
    /// Interaction logic for SaveBookWindow.xaml
    /// </summary>
    public partial class SaveBookWindow : Window
    {
        public BookViewModel BookViewModel = new BookViewModel();
        public bool IsBookNeedToSave = false;
        public SaveBookWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            IsBookNeedToSave = false;
            this.Close();
        }

        private string _bookToSaveTitle;
        public string BookToSaveTitle
        {
            get
            {
                _bookToSaveTitle = TitleBox.Text;
                return _bookToSaveTitle;
            }
            set { _bookToSaveTitle = value; }
        }

        //public string BookToSaveAuthor { get; set; }

        //public string BookToSaveEditor { get; set; }

        //public string BookToSaveYear { get; set; }

        //public string BookToSavePages { get; set; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IsBookNeedToSave = true;
            this.Close();
        }
        //private int FromStringToInt(string inputString)
        //{
        //    int result;
        //    var intParse = int.TryParse(inputString, out result);
        //    if (!intParse)
        //    {
        //        var messageBoxResult = MessageBox.Show("Le nombre de pages doit être un nombre");
        //        if (messageBoxResult == MessageBoxResult.Yes)
        //        {
        //            Application.Current.Shutdown();
        //        }
        //    }
        //    return result;
        //}

        #region TextBoxEvent region
        private void TitleBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            //TitleToShowBeforeFocus = String.Empty;
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
        #endregion TextBoxEvent region
    }
}

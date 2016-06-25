using System;
using System.Windows;
using System.Windows.Controls;
using WinLibrary.ViewModel;

namespace WinLibrary.Views
{
    /// <summary>
    /// Interaction logic for SaveBookWindow.xaml
    /// </summary>
    public partial class SaveBookWindow : Window
    {
        private readonly string _titleBoxDefaultText = "Titre";
        private readonly string _authorBoxDefaultText = "Auteur";
        private readonly string _editorBoxDefaultText = "Editeur";
        private readonly string _yearBoxDefaultText = "Année de parution";
        private readonly string _pagesNumberBoxDefaultText = "Nombre de pages";

        public BookViewModel BookViewModel = new BookViewModel();
        public bool IsBookNeedToSave = false;
        public SaveBookWindow()
        {
            InitializeComponent();
            InitializeBoxFields();
        }

        private void InitializeBoxFields()
        {
            TitleBox.Text = _titleBoxDefaultText;
            AuthorBox.Text = _authorBoxDefaultText;
            EditorBox.Text = _editorBoxDefaultText;
            YearBox.Text = _yearBoxDefaultText;
            PagesNumberBox.Text = _pagesNumberBoxDefaultText;
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

        private string _bookToSaveAuthor;
        public string BookToSaveAuthor
        {
            get
            {
                _bookToSaveAuthor = AuthorBox.Text;
                return _bookToSaveAuthor;
            }
            set { _bookToSaveAuthor = value; }
        }

        private string _bookToSaveEditor;
        public string BookToSaveEditor
        {
            get
            {
                _bookToSaveEditor = EditorBox.Text;
                return _bookToSaveEditor;
            }
            set { _bookToSaveEditor = value; }
        }

        private string _bookToSaveYear;
        public string BookToSaveYear
        {
            get
            {
                _bookToSaveYear = YearBox.Text;
                return _bookToSaveYear;
            }
            set { _bookToSaveYear = value; }
        }

        private int _bookToSavePages;
        public long? BookToSavePages
        {
            get
            {
                _bookToSavePages = FromStringToInt(PagesNumberBox.Text);
                return _bookToSavePages;
            }
            set { _bookToSavePages = (int) value; }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IsBookNeedToSave = true;
            this.Close();
        }
        private int FromStringToInt(string inputString)
        {
            int result;
            var intParse = int.TryParse(inputString, out result);
            if (!intParse)
            {
                var messageBoxResult = MessageBox.Show("Le nombre de pages doit être un nombre");
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            return result;
        }

        #region TextBoxEvent region

        private void ReturnValueWhenGotFocus(TextBox boxToUpdate, string defaultViewValue)
        {
            if (boxToUpdate.Text == string.Empty)
            {
                boxToUpdate.Text = defaultViewValue;
            }
            else if (boxToUpdate.Text == defaultViewValue)
            {
                boxToUpdate.Text = string.Empty;
            }
        }

        private void ReturnValueWhenLostFocus(TextBox boxToUpdate, string defaultViewValue)
        {
            if (boxToUpdate.Text == defaultViewValue || boxToUpdate.Text == string.Empty)
            {
                boxToUpdate.Text = defaultViewValue;
            }
        }

        private void TitleBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenGotFocus(TitleBox, _titleBoxDefaultText);
        }

        private void AuthorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenGotFocus(AuthorBox, _authorBoxDefaultText);
        }

        private void EditorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenGotFocus(EditorBox, _editorBoxDefaultText);
        }

        private void YearBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenGotFocus(YearBox, _yearBoxDefaultText);
        }

        private void PagesNumberBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenGotFocus(PagesNumberBox, _pagesNumberBoxDefaultText);
        }

        private void TitleBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenLostFocus(TitleBox, _titleBoxDefaultText);
        }

        private void AuthorBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenLostFocus(AuthorBox, _authorBoxDefaultText);
        }

        private void EditorBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenLostFocus(EditorBox, _editorBoxDefaultText);
        }

        private void YearBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenLostFocus(YearBox, _yearBoxDefaultText);
        }

        private void PagesNumberBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ReturnValueWhenLostFocus(PagesNumberBox, _pagesNumberBoxDefaultText);
        }
        #endregion TextBoxEvent region
    }
}

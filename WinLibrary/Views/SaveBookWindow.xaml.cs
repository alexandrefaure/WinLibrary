using MahApps.Metro.Controls;
using WinLibrary.ViewModel;

namespace WinLibrary.Views
{
    /// <summary>
    /// Interaction logic for SaveBookWindow.xaml
    /// </summary>
    public partial class SaveBookWindow : MetroWindow, IView
    {
        private readonly string _titleBoxDefaultText = "Titre";
        private readonly string _authorBoxDefaultText = "Auteur";
        private readonly string _editorBoxDefaultText = "Editeur";
        private readonly string _yearBoxDefaultText = "Année de parution";
        private readonly string _pagesNumberBoxDefaultText = "Nombre de pages";
        private readonly string _isbnBoxDefaultText = "9782100738748";

        //public bool IsBookNeedToSave = false;
        public SaveBookWindow()
        {
            InitializeComponent();
            //InitializeBoxFields();
            DataContext = new SaveBookViewModel(this);
        }

        //private void InitializeBoxFields()
        //{
        //    TitleBox.Text = _titleBoxDefaultText;
        //    AuthorBox.Text = _authorBoxDefaultText;
        //    EditorBox.Text = _editorBoxDefaultText;
        //    YearBox.Text = _yearBoxDefaultText;
        //    PagesNumberBox.Text = _pagesNumberBoxDefaultText;
        //    IsbnBox.Text = _isbnBoxDefaultText;
        //}

        //private void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    IsBookNeedToSave = false;
        //    Close();
        //}

        //#region TextBoxEvent region

        //private void ReturnValueWhenGotFocus(TextBox boxToUpdate, string defaultViewValue)
        //{
        //    if (boxToUpdate.Text == string.Empty)
        //    {
        //        boxToUpdate.Text = defaultViewValue;
        //    }
        //    else if (boxToUpdate.Text == defaultViewValue)
        //    {
        //        boxToUpdate.Text = string.Empty;
        //    }
        //}

        //private void ReturnValueWhenLostFocus(TextBox boxToUpdate, string defaultViewValue)
        //{
        //    if (boxToUpdate.Text == defaultViewValue || boxToUpdate.Text == string.Empty)
        //    {
        //        boxToUpdate.Text = defaultViewValue;
        //    }
        //}

        //private void TitleBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(TitleBox, _titleBoxDefaultText);
        //}

        //private void AuthorBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(AuthorBox, _authorBoxDefaultText);
        //}

        //private void EditorBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(EditorBox, _editorBoxDefaultText);
        //}

        //private void YearBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(YearBox, _yearBoxDefaultText);
        //}

        //private void PagesNumberBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(PagesNumberBox, _pagesNumberBoxDefaultText);
        //}

        //private void TitleBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(TitleBox, _titleBoxDefaultText);
        //}

        //private void AuthorBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(AuthorBox, _authorBoxDefaultText);
        //}

        //private void EditorBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(EditorBox, _editorBoxDefaultText);
        //}

        //private void YearBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(YearBox, _yearBoxDefaultText);
        //}

        //private void PagesNumberBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(PagesNumberBox, _pagesNumberBoxDefaultText);
        //}
        //private void IsbnBox_OnGotFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenGotFocus(IsbnBox, _isbnBoxDefaultText);
        //}

        //private void IsbnBox_OnLostFocus(object sender, RoutedEventArgs e)
        //{
        //    ReturnValueWhenLostFocus(IsbnBox, _isbnBoxDefaultText);
        //}
        //#endregion TextBoxEvent region
    }
}

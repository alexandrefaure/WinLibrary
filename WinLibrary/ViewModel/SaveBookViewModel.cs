using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WinLibrary.AmazonAPI;

namespace WinLibrary.ViewModel
{
    public class SaveBookViewModel : ViewModelBase
    {
        public RelayCommand GetBookFromAmazonCommand { get; }
        private GoogleApi googleApi;

        public SaveBookViewModel()
        {
            googleApi = new GoogleApi();
            GetBookFromAmazonCommand = new RelayCommand(GetBookFromAmazon, CanGetBookInformation);
        }

        private void GetBookFromAmazon()
        {
            if (Isbn != string.Empty)
            {
                var book = googleApi.GetBook(Isbn);
                //canvas.TitleBox.Text = book.Title;
                //canvas.AuthorBox.Text = book.Author;
                //canvas.EditorBox.Text = book.Editor;
                ////canvas.YearBox.Text = book.PublishedYear;
                //canvas.PagesNumberBox.Text = book.PagesNumber.ToString();

                //var bitmap = ReturnImageFromUrl(book.CoverImage);
                //canvas.CoverImage.Source = bitmap;
                //canvas.BookToSaveCoverImageUrl = book.CoverImage;
            }
        }

        private bool CanGetBookInformation()
        {
            return true;
        }

        private string _isbn;
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                RaisePropertyChanged(nameof(_isbn));
            }
        }

        private string _bookToSaveTitle;
        public string BookToSaveTitle
        {
            get { return _bookToSaveTitle; }
            set
            {
                _bookToSaveTitle = value;
                RaisePropertyChanged(nameof(_bookToSaveTitle));
            }
        }

        private string _bookToSaveAuthor;
        public string BookToSaveAuthor
        {
            get { return _bookToSaveAuthor; }
            set
            {
                _bookToSaveAuthor = value;
                RaisePropertyChanged(nameof(_bookToSaveAuthor));
            }
        }

        private string _bookToSaveEditor;
        public string BookToSaveEditor
        {
            get { return _bookToSaveEditor; }
            set
            {
                _bookToSaveEditor = value;
                RaisePropertyChanged(nameof(_bookToSaveEditor));
            }
        }

        private string _bookToSaveYear;
        public string BookToSaveYear
        {
            get { return _bookToSaveYear; }
            set
            {
                _bookToSaveYear = value;
                RaisePropertyChanged(nameof(_bookToSaveYear));
            }
        }

        private int _bookToSavePages;
        public int BookToSavePages
        {
            get { return _bookToSavePages; }
            set
            {
                _bookToSavePages = value;
                RaisePropertyChanged(nameof(_bookToSavePages));
            }
        }

        private Image _coverImage;
        public Image CoverImage
        {
            get { return _coverImage; }
            set
            {
                _coverImage = value;
                RaisePropertyChanged(nameof(_coverImage));
            }
        }

        private string _bookToSaveCoverImageUrl;
        public string BookToSaveCoverImageUrl
        {
            get { return _bookToSaveCoverImageUrl; }
            set
            {
                _bookToSaveCoverImageUrl = value;
                RaisePropertyChanged(nameof(_bookToSaveCoverImageUrl));
            }
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

    }
}

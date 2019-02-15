using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WinLibrary.AmazonAPI;

namespace WinLibrary.ViewModel
{
    public class SaveBookViewModel : ViewModelBase
    {
        public RelayCommand GetBookFromAmazonCommand { get; }

        public SaveBookViewModel()
        {
            GetBookFromAmazonCommand = new RelayCommand(GetBookFromAmazon, CanGetBookInformation);
        }

        private void GetBookFromAmazon()
        {
            //var canvas = (SaveBookWindow)param;
            if (Isbn != string.Empty)
            {
                var book = GoogleApi.GetBook(Isbn);
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
    }
}

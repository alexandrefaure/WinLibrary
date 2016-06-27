using System.Windows;
using System.Windows.Controls;
using WinLibrary.ViewModel;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows
    {
        public BookViewModel bookViewModel = new BookViewModel();
        public MainWindows()
        {
            InitializeComponent();
            this.DataContext = bookViewModel;
        }

        private void BooksGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var currentBook = bookViewModel.GetBook(selectedIsbnBox.Text);
            if (currentBook != null)
            {
                this.selectedBookImage.Source = BookViewModel.ReturnImageFromUrl(currentBook.CoverImage);
            }
        }
    }
}

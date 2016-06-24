using System.Windows;
using WinLibrary.Entity;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows
    {
        public BookViewModel BookViewModel = new BookViewModel();
        public MainWindows()
        {
            InitializeComponent();
            InitializeDatabase();
            this.DataContext = BookViewModel;
        }

        public void InitializeDatabase()
        {
            if (BookViewModel.IsBooksDatabaseEmpty())
            {
                var testBook = new Book { Title = "MDRInit" };
                BookViewModel.SaveBook(testBook);
            }
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            //var wnd = new Views.SaveBookWindow();
            ////wnd.Show(); //Separate thread
            //wnd.ShowDialog(); //Same thread
            //var testBook = new Book { Title = wnd.TitleBox.Text };

            var testBook = new Book { Title = "MDRTEstADD" };
            BookViewModel.SaveBook(testBook);
        }

        private void QuitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

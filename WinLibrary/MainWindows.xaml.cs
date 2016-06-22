using System.Linq;
using System.Windows;
using WinLibrary.Entity;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public static DatabaseEntities _database;
        public MainWindows()
        {
            InitializeComponent();
            InitializeDatabase();
            FillBooksGrid();
        }

        public void InitializeDatabase()
        {
            _database = new DatabaseEntities();
            var testbook = new Book {Title = "TestBook"};
            _database.Books.Add(testbook);
            _database.SaveChanges();
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            var wnd = new Views.BookWindows();
            //wnd.Show(); //Separate thread
            wnd.ShowDialog(); //Same thread
            RefreshBooksDataGrid();
        }

        private void QuitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RefreshBooksDataGrid()
        {
            BooksGrid.ItemsSource = _database.Books.ToList();
        }

        public void FillBooksGrid()
        {
            BooksGrid.ItemsSource = _database.Books.ToList();
        }
    }
}

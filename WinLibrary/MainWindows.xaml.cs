using System.Linq;
using System.Windows;
using WinLibrary.DAL;
using WinLibrary.Entity;
using WinLibrary.Views;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        //private static BookViewModel context;
        //public static DatabaseEntities _database;
        public MainWindows()
        {
            InitializeComponent();
            //this.BooksGrid.DataContext = this;
            InitializeDatabase();
            FillBooksGrid();
        }

        public void InitializeDatabase()
        {
            //using (var database = new DatabaseEntities())
            //{
                var testbook = new Book { Title = "TestBook" };
                BookDAL.SaveBook(testbook);
            //}
            //var _database = new DatabaseEntities();
            //var testbook = new Book { Title = "TestBook" };
            //BookDAL.SaveBook(new DatabaseEntities(), testbook);
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
            var wnd = new Views.BookWindows();
            //wnd.Show(); //Separate thread
            wnd.ShowDialog(); //Same thread
        }

        private void QuitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FillBooksGrid()
        {
            using (var database = new DatabaseEntities())
            {
                //var source = context.LoadAllBooks();
                BooksGrid.ItemsSource = database.Books.ToList();
            }
        }
    }
}

using System.Windows;
using WinLibrary.Entity;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : Window
    {
        public MainWindows()
        {
            this.DataContext = this;
            InitializeComponent();
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            using (Entity.DatabaseEntities db = new Entity.DatabaseEntities())
            {
                var testbook = new Book { Title = "TestBook" };
                db.Books.Add(testbook);
                db.SaveChanges();
            }
        }
        private void AddBook(object sender, RoutedEventArgs e)
        {
           var wnd = new BookWindows();
            //wnd.Show(); //Separate thread
            wnd.ShowDialog(); //Same thread
        }
    }
}

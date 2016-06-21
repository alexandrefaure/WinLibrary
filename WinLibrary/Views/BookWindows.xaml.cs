using System;
using System.Windows;
using WinLibrary.Entity;

namespace WinLibrary
{
    /// <summary>
    /// Interaction logic for BookWindows.xaml
    /// </summary>
    public partial class BookWindows : Window
    {
        public BookWindows()
        {
            InitializeComponent();
            SaveBookGrid.DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Entity.DatabaseEntities())
            {
                var testbook = new Book
                {
                    Title = "Test"
                };
                db.Books.Add(testbook);
                db.SaveChanges();
            }
        }
    }
}

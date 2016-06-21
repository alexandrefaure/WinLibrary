using System;
using System.Windows;
using WinLibrary.Entity;

namespace WinLibrary.Views
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
            using (var db = new DatabaseEntities())
            {
                var testbook = new Book
                {
                    Title = TitleBox.Text,
                    Author = AuthorBox.Text,
                    Editor = EditorBox.Text,
                    PublishedYear = YearBox.Text,
                    PagesNumber = int.Parse(PagesNumberBox.Text)
                };
                db.Books.Add(testbook);
                db.SaveChanges();
            }
            this.Close();
        }

        private void TitleBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TitleBox.Text = String.Empty;
        }

        private void AuthorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            AuthorBox.Text = String.Empty;
        }

        private void EditorBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            EditorBox.Text = String.Empty;
        }

        private void YearBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            YearBox.Text = String.Empty;
        }

        private void PagesNumberBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PagesNumberBox.Text = String.Empty;
        }

        private void TitleBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AuthorBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditorBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void YearBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PagesNumberBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

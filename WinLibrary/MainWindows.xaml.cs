using System.Windows;
using WinLibrary.ViewModel;

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
            this.DataContext = BookViewModel;
        }

        private void QuitProgram(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

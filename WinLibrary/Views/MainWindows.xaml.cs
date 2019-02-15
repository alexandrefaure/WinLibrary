using MahApps.Metro.Controls;
using WinLibrary.ViewModel;

namespace WinLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindows : MetroWindow
    {
        public BookViewModel BookViewModel = new BookViewModel();
        public MainWindows()
        {
            InitializeComponent();
            DataContext = BookViewModel;
        }
    }
}

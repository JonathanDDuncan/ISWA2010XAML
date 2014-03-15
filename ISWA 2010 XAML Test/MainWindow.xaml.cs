using System.Windows;
using ISWA2010XAML.Model;
using ISWA2010XAML.ViewModel;

namespace ISWA_2010_XAML_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SampleSign.DataContext = SampleDataContexts.SampleSignText;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var signTextViewModel = SignTextViewModel.GetTextViewModel(SignTextModel.GetSigns(FswTextBox.Text));
            SignTextViewModel.Layout(signTextViewModel, SampleSign.ActualHeight);
            SampleSign.DataContext = signTextViewModel;
        }
    }
}

using System.Windows;
using ISWA2010XAML.Model;
using ISWA2010XAML.ViewModel;

namespace ISWA2010XAML.View
{
    /// <summary>
    /// Interaction logic for testWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
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

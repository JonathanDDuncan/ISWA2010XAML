using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using ISWA2010XAML.ViewModel;

namespace ISWA2010XAML.View.Controls
{
    /// <summary>
    /// Interaction logic for symbol.xaml
    /// </summary>
    public partial class SymbolView : UserControl
    {
       
        public SymbolView()
        {
            InitializeComponent();
        }

        private void CreateContent()
        {
            var context = DataContext;
            if (context != null)
            {
                var symbolViewModel = ((SymbolViewModel)context);
                CreateSymbolGraphics(symbolViewModel);
            }
        }

        private void CreateSymbolGraphics(SymbolViewModel symbolViewModel)
        {
            var str = AddNameSpaces(RenameWindowToCanvas(RemoveShared1(symbolViewModel.Definition)));
            var stringReader = new StringReader(str);

            var xmlReader = XmlReader.Create(stringReader);
            var canvas = (Canvas)XamlReader.Load(xmlReader);
            SetPrimaryColor(symbolViewModel.PrimaryBrush , canvas);
            SetSecondaryColor(symbolViewModel.SecondaryBrush, canvas);
            SetSize(symbolViewModel.Size, canvas);
            Content = canvas;
        }

        private void SetSize(double size, Canvas canvas)
        {
            canvas.LayoutTransform = new ScaleTransform(size,size);
        }

        private static void SetPrimaryColor(Brush primaryBrush, Canvas canvas)
        {
            SetBrush(primaryBrush,"Nb",canvas);
        }

        private static void SetSecondaryColor(Brush secondaryBrush, Canvas canvas)
        {
            SetBrush(secondaryBrush, "Nw", canvas);
        }
        private static void SetBrush(Brush brush, string resourseName, Canvas canvas)
        {
            if (brush == null) return;
            if (canvas == null) return;
            var style = new Style
            {
                TargetType = typeof(Shape),
            };
            style.Setters.Add(new Setter(Shape.FillProperty, brush));
            canvas.Resources.Add(resourseName, style);
        }
       

        private string AddNameSpaces(string text)
        {
            const string textToFind = @"<Canvas";
            var svgDocLocation = text.IndexOf(textToFind, StringComparison.Ordinal);
            const string namespaces = @" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" ";

            return text.Insert(svgDocLocation + textToFind.Length, namespaces);
        }

        private string RenameWindowToCanvas(string removeShared1)
        {
            return "<Canvas>" + removeShared1.Replace("Window", "Canvas") + "</Canvas>";
        }

        private string RemoveShared1(string addNameSpaces)
        {
            return addNameSpaces.Replace(@"x:Shared=""False""", "");
        }

        private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            CreateContent();
        }
    }
}

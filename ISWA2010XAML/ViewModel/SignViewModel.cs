using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using ISWA2010XAML.Model;
using SignWritingBasicObjects;
using System.Linq;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ISWA2010XAML.ViewModel
{
    public class SignViewModel
    {
        private static int _top;
        //public IObservable<SymbolViewModel> Symbols{get;set;}
        public ObservableCollection<SymbolViewModel> Symbols { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public Thickness Margin { get; set; }
        public int LefttoEdge { get; set; }
        public int Top { get; set; }
        public Sign Sign { get; set; }


        public static SignViewModel GetSignViewModel(Sign signModel)
        {
            return ConvertSigntoSignViewModel(signModel);
        }

        private static SignViewModel ConvertSigntoSignViewModel(Sign signModel)
        {
            //var size = GetSize(signModel.MinBounding.X, signModel.MinBounding.Y, signModel.MaxBounding.X,
            //                   signModel.MaxBounding.Y, 10);
            var size = GetSize(signModel);
            //var leftPadding = GetLeftPadding(signModel);
            //var margin = new Thickness(leftPadding, 0, 0, 0);
            //_top += size.Height;
            //var top = _top;
            var svm = new SignViewModel
            {
                Sign = signModel,
                Symbols = GetSymbols(signModel),
                Height = size.Height,
                Width = size.Width,
                //Margin = margin,
                //LefttoEdge = leftPadding,
                //Top = top
            };
            return svm;
        }

        private static Size GetSize(Sign signModel)
        {
            int signxMin = int.MaxValue, signyMin = int.MaxValue, signxMax = int.MinValue, signyMax = int.MinValue;
            var firstOrDefault = signModel.Frames.FirstOrDefault();
            if (firstOrDefault != null)
                foreach (var symbol in firstOrDefault.Symbols)
                {
                    int symxMin = symbol.X;
                    int symyMin = symbol.Y;
                    int symxMax = symbol.X + GetSymbolWidth(symbol.Code);
                    int symyMax = symbol.Y + GetSymbolHeight(symbol.Code);

                    if (symxMin < signxMin) signxMin = symxMin;
                    if (symyMin < signyMin) signyMin = symyMin;
                    if (symxMax > signxMax) signxMax = symxMax;
                    if (symyMax > signyMax) signyMax = symyMax;

                }

            return new Size(signxMax - signxMin, signyMax - signyMin);
        }

        private static int GetSymbolHeight(int code)
        {
            return Dal.GetSymbolHeight(code);
        }

        private static int GetSymbolWidth(int code)
        {
            return Dal.GetSymbolWidth(code);
        }

        private static ObservableCollection<SymbolViewModel> GetSymbols(Sign sign)
        {
            var oc = new ObservableCollection<SymbolViewModel>();

            var firstOrDefault = sign.Frames.FirstOrDefault();


            var xOffset = (sign.MaxBounding.X - 500);
            var yOffset = (sign.MaxBounding.Y - 500);

            if (firstOrDefault != null)
            {
                var offsetToNormal = GetOffsetToNormal(firstOrDefault.Symbols);


                foreach (var symbol in firstOrDefault.Symbols)
                {
                    var x = (symbol.X - 500) - offsetToNormal.X;
                    var y = (symbol.Y - 500) - offsetToNormal.Y;
                    oc.Add(new SymbolViewModel
                        {
                            Definition = Dal.GetDefinition(symbol.Code),
                            X = x,
                            Y = y,
                            PrimaryBrush = new SolidColorBrush(BasicColor.GetMediaColor(symbol.PrimaryColor)),
                            SecondaryBrush = new SolidColorBrush(BasicColor.GetMediaColor(symbol.SecondaryColor))
                        });
                }
            }
            return oc;
        }

        private static Point GetOffsetToNormal(IEnumerable<SignWritingBasicObjects.Symbol> symbols)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            var symbolList = symbols as IList<SignWritingBasicObjects.Symbol> ?? symbols.ToList();
            if (symbols != null && symbolList.Any())
            {
                foreach (var symbol in symbolList)
                {
                    var x = symbol.X - 500;
                    var y = symbol.Y - 500;
                    if (x < minX) minX = x;
                    if (y < minY) minY = y;
                }
                return new Point(minX, minY);
            }


            return new Point();
        }
    }
}
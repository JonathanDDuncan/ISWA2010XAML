using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ISWA2010XAML.Model;
using SignWritingBasicObjects;
using Size = System.Drawing.Size;

namespace ISWA2010XAML.ViewModel
{
    public class SignTextViewModel
    {
        private static int _top;
        private static int _leftOfColum;

        public static ObservableCollection<SignViewModel> GetTextViewModel(List<Sign> signs)
        {
            var viewModelSigns = new ObservableCollection<SignViewModel>();

            foreach (var sign in signs)
            {
                viewModelSigns.Add(SignViewModel.GetSignViewModel(sign));
            }
            return viewModelSigns;
        }

        public static void Layout(ObservableCollection<SignViewModel> signTextViewModel, double heightConstraint)
        {
            const int padding = 40;
            var minColumnWidth = 130 + 30; //RightcolumnCenter + 30;
            _top = 0;
            _leftOfColum = 0;
            var accumulatedWidth = 0;
            var currentMaxWidth = 0;
            foreach (var signModel in signTextViewModel)
            {
                var size = GetSize(signModel);
                var leftPadding = GetLeftPadding(signModel);
                var margin = new Thickness(leftPadding, 0, 0, 0);

                if (_top + size.Height > heightConstraint)
                {
                    _top = 0;
                    var thiscolumWidth = Math.Max(currentMaxWidth, minColumnWidth);
                    accumulatedWidth += thiscolumWidth;
                    _leftOfColum += accumulatedWidth;
                    currentMaxWidth = 0;
                }
               
               

                signModel.Height = size.Height;
                signModel.Width = size.Width;
                currentMaxWidth = Math.Max((int) signModel.Width, currentMaxWidth);
                signModel.Margin = margin;
                signModel.LefttoEdge = accumulatedWidth + leftPadding;
                signModel.Top = _top;

                _top += size.Height + padding;
            }
        }

        private static int GetLeftPadding(SignViewModel signViewModel)
        {
            var signModel = signViewModel.Sign;
            var columnCenter = 80;
            if (signModel.Lane == 'L') columnCenter = 30;
            if (signModel.Lane == 'R') columnCenter = 130;

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
            var width = signxMax - signxMin;
            var toLeftofColumnCenter = width - (signxMax - 500);

            return columnCenter - toLeftofColumnCenter;
        }

        private static Size GetSize(SignViewModel signViewModel)
        {
            var signModel = signViewModel.Sign;

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
    }
}
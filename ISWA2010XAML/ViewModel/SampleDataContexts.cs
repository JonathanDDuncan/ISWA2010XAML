using System.Collections.ObjectModel;
using System.Windows.Media;
using ISWA2010XAML.Model;

namespace ISWA2010XAML.ViewModel
{
    public class SampleDataContexts
    {
        public static SymbolViewModel SymbolSample
        {
            get { return GetSymbolSample(); }
        }

        public static SignViewModel SignSample
        {
            get { return GetSignSample(); }
        }

        public static SignViewModel CreatedSign
        {
            get { return GetCreatedSign("AS15451S15459S2880cS28814S1543fS15437M535x530S15451500x471S15459475x471S2880c523x492S15437476x506S1543f501x506S28814465x492"); }
        }
        public static ObservableCollection<SignViewModel> CreatedText
        {
            get { return GetCreatedText("M542x567S30a00482x482S19c01514x496S2970c507x520 M543x578S30e00482x489S34200482x489S15a50516x513S30122482x476S24003515x543S2f710515x571 M523x518S15a37477x486S18020487x500S20500487x507S28801503x482 M523x522S15a1a476x485S15a51484x499S2c600504x478 M528x539S14017504x462S1401f471x475S2ea04513x498S2ea10483x512S2fb05502x527 M528x550S34200482x488S18517504x523S20500515x513S20500518x494S30300482x477 S38700463x496 M523x525S17622477x509S11a20499x495S26500509x484S2f710510x475 M538x577S15001467x530S15009510x530S37600490x554S21800516x516S21800470x519S30a00482x482 S38700463x496 M586x517S30f00482x482S34200482x482S14c10518x482S26506541x498S18510561x496S2f710547x484 S38800464x496 M527x557S30a00482x482S34000482x482S11e32497x517S2ea06501x542 M536x529S15001464x483S15009508x483S37600488x506S21800516x473S21800467x472 M531x564S32a00482x488S30e00482x488S33e00482x488S15a12504x540S15a1a478x552S20500516x527S20500483x539S30104482x477 S38700463x496 M509x534S10020491x466S29a04494x499 S38800464x496 M518x517S30a00482x482S33e00482x482S20600488x471S14c10460x461 M518x528S30a00482x482S33e00482x482S20600489x517S14c10460x495 M541x545S35000482x483S15a20510x518S26507526x519S2f900530x512 M537x570S30a00482x482S34000482x482S15001469x524S15009509x524S37600490x547S21800516x515S21800471x516 M528x531S15d4a471x512S15d41491x504S20e00515x511S2a404503x469 M520x537S33e00482x482S18507501x510S20600482x518 M516x518S1f540501x483S1f548484x482S20500495x507 M522x569S30a00482x482S33e00482x482S15a32490x521S15a36483x537S20500511x538S26626492x553S26622472x548 M536x570S30a00482x482S34000482x482S15001463x524S15009508x525S21800515x515S21800466x514S37600487x547 S38800464x496"); }
        }

        public static ObservableCollection<SignViewModel> SampleSignText
        {
            get
            {
                return new ObservableCollection<SignViewModel>
                    {
                        new SignViewModel
                            {
                                Height = 100,
                                Symbols = new ObservableCollection<SymbolViewModel>
                                    {
                                        GetSymbolSample(20, 15, new SolidColorBrush(Colors.Blue),
                                                        new SolidColorBrush(Colors.Purple), 0.5),
                                        GetSymbolSample(30, 45, new SolidColorBrush(Colors.Green),
                                                        new SolidColorBrush(Colors.Aqua), 0.75),
                                        GetSymbolSample(40, 55, new SolidColorBrush(Colors.Red),
                                                        new SolidColorBrush(Colors.Yellow), 2),
                                        GetSymbolSample(50, 65, null, null)
                                    }
                            },
                        new SignViewModel
                            {
                                Height = 100,
                                Symbols = new ObservableCollection<SymbolViewModel>
                                    {
                                        GetSymbolSample(20, 15, new SolidColorBrush(Colors.Blue),
                                                        new SolidColorBrush(Colors.Purple), 0.5),
                                        GetSymbolSample(30, 45, new SolidColorBrush(Colors.Green),
                                                        new SolidColorBrush(Colors.Aqua), 0.75),
                                        GetSymbolSample(40, 55, new SolidColorBrush(Colors.Red),
                                                        new SolidColorBrush(Colors.Yellow), 2),
                                        GetSymbolSample(50, 65, null, null)
                                    }
                            },
                        new SignViewModel
                            {
                                Height = 100,
                                Symbols = new ObservableCollection<SymbolViewModel>
                                    {
                                        GetSymbolSample(20, 15, new SolidColorBrush(Colors.Blue),
                                                        new SolidColorBrush(Colors.Purple), 0.5),
                                        GetSymbolSample(30, 45, new SolidColorBrush(Colors.Magenta),
                                                        new SolidColorBrush(Colors.Aqua), 0.75),
                                        GetSymbolSample(40, 55, new SolidColorBrush(Colors.Red),
                                                        new SolidColorBrush(Colors.Pink), 2),
                                        GetSymbolSample(50, 65, null, null)
                                    }
                            }
                    };
            }
        }

        public static SignViewModel PunctuationSample
        {
            get { return GetPunctuationSample(); }
        }

        private static SignViewModel GetPunctuationSample()
        {
            return new SignViewModel
                {
                    Height = 8,
                    Width = 72,
                    Symbols = new ObservableCollection<SymbolViewModel>
                        {

                            new SymbolViewModel
                                {
                                    Definition =
                                        @"<Canvas><Canvas><Path Style=""{DynamicResource Nb}""><Path.Data><PathGeometry FillRule=""NonZero"" Figures=""M 0,0 72,0 72,8 0,8 0,0 z""/></Path.Data></Path></Canvas></Canvas>"
                                }
                        }
                };
        }

        private static ObservableCollection<SignViewModel> GetCreatedText(string fsw)
        {
            return SignTextViewModel.GetTextViewModel(SignTextModel.GetSigns(fsw));
        }

        private static SignViewModel GetCreatedSign(string fsw)
        {
            return SignViewModel.GetSignViewModel(SignModel.GetSignModel(fsw));
        }

        private static SignViewModel GetSignSample()
        {
            return new SignViewModel 
            {
                Height = 100,
                Symbols = new  ObservableCollection<SymbolViewModel>
                    {
                        GetSymbolSample(20,15, new SolidColorBrush(Colors.Blue),new SolidColorBrush(Colors.Purple), 0.5),
                        GetSymbolSample(30,45, new SolidColorBrush(Colors.Green),new SolidColorBrush(Colors.Aqua),0.75),
                        GetSymbolSample(40,55, new SolidColorBrush(Colors.Red),new SolidColorBrush(Colors.Yellow),2),
                        GetSymbolSample(50,65, null, null),
                    
                    }
            };
        }
        private static SymbolViewModel GetSymbolSample(double x, double y, Brush primaryBrush, Brush secondaryBrush, double size = 1)
        {
            return new SymbolViewModel
            {
                Definition = @"<Canvas><Canvas><Canvas><Rectangle Style=""{DynamicResource Nb}"" Width=""2"" Height=""15"" Canvas.Left=""13""></Rectangle></Canvas><Canvas><Rectangle Style=""{DynamicResource Nb}"" Width=""15"" Height=""15"" Canvas.Top=""15""></Rectangle></Canvas><Canvas><Rectangle Style=""{DynamicResource Nw}"" Width=""11"" Height=""11"" Canvas.Left=""2"" Canvas.Top=""17""></Rectangle></Canvas></Canvas></Canvas>",
                X = x,
                Y = y,
                Size = size,
               
                PrimaryBrush = primaryBrush,
                SecondaryBrush = secondaryBrush
            };
        }
        private static SymbolViewModel GetSymbolSample()
        {
            return new SymbolViewModel
                {
                    Definition = @"<Canvas><Canvas><Canvas><Rectangle Style=""{DynamicResource Nb}"" Width=""2"" Height=""15"" Canvas.Left=""13""></Rectangle></Canvas><Canvas><Rectangle Style=""{DynamicResource Nb}"" Width=""15"" Height=""15"" Canvas.Top=""15""></Rectangle></Canvas><Canvas><Rectangle Style=""{DynamicResource Nw}"" Width=""11"" Height=""11"" Canvas.Left=""2"" Canvas.Top=""17""></Rectangle></Canvas></Canvas></Canvas>"
                };
        }

        private static SymbolViewModel GetSymbolPlain2Sample()
        {
            return new SymbolViewModel
            {
                Definition = @"<Canvas><Canvas><Canvas><Rectangle Fill=""Black"" Width=""2"" Height=""15"" Canvas.Left=""13""></Rectangle></Canvas><Canvas><Rectangle Fill=""Black""  Width=""15"" Height=""15"" Canvas.Top=""15""></Rectangle></Canvas><Canvas><Rectangle Fill=""White""  Width=""11"" Height=""11"" Canvas.Left=""2"" Canvas.Top=""17""></Rectangle></Canvas></Canvas></Canvas>"
            };
        }
        private static SymbolViewModel GetSymbolPlainSample()
        {
            return new SymbolViewModel
            {
                Definition = @"<Canvas><Rectangle Fill=""Black"" Width=""2"" Height=""15"" Canvas.Left=""13""></Rectangle></Canvas><Canvas><Rectangle Fill=""Black""  Width=""15"" Height=""15"" Canvas.Top=""15""></Rectangle></Canvas><Canvas><Rectangle Fill=""White""  Width=""11"" Height=""11"" Canvas.Left=""2"" Canvas.Top=""17""></Rectangle></Canvas>"
            };
        }

          private static SymbolViewModel GetRectangleSample()
        {
            return new SymbolViewModel
                {
                    Definition = @"<Rectangle Fill=""Black"" Width=""2"" Height=""15"" Canvas.Left=""13""></Rectangle>"
                };
        }
       
          private static SymbolViewModel GetCanvasSample()
          {
              return new SymbolViewModel
              {
                  Definition = @"<Canvas Background=""#FFF0F8FF"" Width=""100"" Height=""50"" />"
              };
          }
          private static SymbolViewModel GetButtonSample1()
          {
              return new SymbolViewModel
              {
                  Definition = @"<Button Background=""#FFF0F8FF"" Width=""100"" Height=""50"">Click Me</Button>"
              };
          }
        
    }
}

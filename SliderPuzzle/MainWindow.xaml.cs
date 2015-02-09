using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SliderPuzzle
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
        string[,] sliderPuzzle = new string[3, 3];
        int puzzleCounter = 1;
        Label puzzlePiece;
        private void GameBoard_Loaded(object sender, RoutedEventArgs e)
        {
            for (int y = 0; y <=2; y++)
            {
                for (int x = 0; x <=2; x++)
                {
                    if (puzzleCounter > 8) sliderPuzzle[x, y] = "";
                    else
                    {
                        sliderPuzzle[x, y] = puzzleCounter.ToString();
                        puzzleCounter += 1;
                    }
                    puzzlePiece = new Label(puzzleCounter.ToString()) { 
                    Width=99,
                    Height=99
                    };
                    puzzlePiece.MouseDown += puzzlePiece_MouseDown;
                    GameBoard.Children.Add(puzzlePiece);
                    Canvas.SetLeft(puzzlePiece, x * puzzlePiece.Width);
                    Canvas.SetTop(puzzlePiece, y * puzzlePiece.Height);
                }
            }
        }

        void puzzlePiece_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
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
        Label empty;
        private void GameBoard_Loaded(object sender, RoutedEventArgs e)
        {
            for (int y = 0; y <=2; y++)
            {
                for (int x = 0; x <=2; x++)
                {
                    if (puzzleCounter > 8)
                    {
                        sliderPuzzle[x, y] = "";
                        puzzlePiece = new Label("", new SolidColorBrush(Colors.LightGray))
                        {
                            XCoOrdinate=x,
                            YCoOrdinate=y,
                            Width = 99,
                            Height = 99,
                            Background=new SolidColorBrush(Colors.LightGray)
                        };
                        puzzlePiece.MouseDown += puzzlePiece_MouseDown;
                        empty = puzzlePiece;
                    }
                    else
                    {
                        sliderPuzzle[x, y] = puzzleCounter.ToString();
                        puzzlePiece = new Label(puzzleCounter.ToString(),new SolidColorBrush(Colors.Red))
                        {
                            Width = 99,
                            Height = 99,
                            XCoOrdinate=x,
                            YCoOrdinate=y
                        };
                        puzzlePiece.MouseDown += puzzlePiece_MouseDown;
                        puzzleCounter += 1;
 
                    }
                   
                    GameBoard.Children.Add(puzzlePiece);
                    Canvas.SetLeft(puzzlePiece, x * puzzlePiece.Width);
                    Canvas.SetTop(puzzlePiece, y * puzzlePiece.Height);
                }
            }
        }
        public Points canMove(int xCoOrdinate, int yCoOrdinate)
        {

            try
            {
                
                if (sliderPuzzle[xCoOrdinate + 1, yCoOrdinate] == "") return new Points(xCoOrdinate + 1, yCoOrdinate);
            }
            catch { };
            try
            {
                if (sliderPuzzle[xCoOrdinate - 1, yCoOrdinate] == "") return new Points(xCoOrdinate - 1, yCoOrdinate);
            }
            catch { };
            try
            {
                if (sliderPuzzle[xCoOrdinate, yCoOrdinate + 1] == "") return new Points(xCoOrdinate, yCoOrdinate + 1);
            }
            catch { };
            try
            {
                if (sliderPuzzle[xCoOrdinate, yCoOrdinate - 1] == "") return new Points(xCoOrdinate, yCoOrdinate - 1);
            }
            catch { };

            return null;
        }
        //public void move()
        //{

        //}
        void puzzlePiece_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label currentLocation = (Label)sender;
            if(canMove(currentLocation.XCoOrdinate,currentLocation.YCoOrdinate)!=null)
            {
                Points emptySpace = new Points(canMove(((Label)sender).XCoOrdinate, ((Label)sender).YCoOrdinate).xCoOrdinate, canMove(((Label)sender).XCoOrdinate, ((Label)sender).YCoOrdinate).yCoOrdinate);
                string temp = sliderPuzzle[emptySpace.xCoOrdinate, emptySpace.yCoOrdinate];
                sliderPuzzle[emptySpace.xCoOrdinate, emptySpace.yCoOrdinate] = sliderPuzzle[currentLocation.XCoOrdinate, currentLocation.YCoOrdinate];
                sliderPuzzle[currentLocation.XCoOrdinate, currentLocation.YCoOrdinate] = temp;
                empty.Number.Background = new SolidColorBrush(Colors.Red);
                empty.Number.Text = currentLocation.Number.Text;
                currentLocation.Number.Background = new SolidColorBrush(Colors.LightGray);
                currentLocation.Number.Text="";
                empty=currentLocation;

                                
          }
            
        }
    }
}

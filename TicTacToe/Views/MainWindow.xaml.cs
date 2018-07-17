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
using TicTacToe.ViewModels;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window constructor. sets up view
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            wl = new WinningLogic((GameViewModel)this.DataContext);
        }

        private WinningLogic wl;

        /// <summary>
        /// Swaps the player's turn based off of who went last. Player 1 always goes first
        /// </summary>
        private void SwapPlayerTurn()
        {
            //getting a copy of the view model
            GameViewModel gvm = this.DataContext as GameViewModel;
            if(gvm.PlayerTurn == 1)
            {
                gvm.PlayerTurn = 2;
            }
            else
            {
                gvm.PlayerTurn = 1;
            }
        }

        /// <summary>
        /// Converting string path to image source that is used to load image
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ImageSource stringToImageSource(string path)
        {
            Uri imageUri = new Uri(path, UriKind.RelativeOrAbsolute);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            return imageBitmap;
        }
        /// <summary>
        /// Update image clicked on to show ownership. check for which player wins or tie. calls swap player turn if no one has won or tied
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image imageClicked = (Image)sender;
            //getting a copy of the view model
            GameViewModel gvm = this.DataContext as GameViewModel;
            //Checks to see if it is player 1's turn, updates the image to an X, and disables the square so it cannot be changed.
            if (gvm.PlayerTurn == 1)
            {
                imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xgreen.png");
                imageClicked.IsEnabled = false;
            }
            //Else, if it is not player 1's turn, updates iamge to an O and siables the square so it cannot be changes
            else
            {
                imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Ogreen.png");
                imageClicked.IsEnabled = false;
            }
            //initializes a variable to keep track of how many images have been clicked
            int numOfImagesClickedSoFar = 0;
            List<Image> clickedImagesList = new List<Image>();
            //Gets list of images that have been clicked so far
            foreach (Border border in GameBoard.Children.OfType<Border>())
            {
                Image img = (Image)border.Child;
                if(!img.IsEnabled)
                {
                    numOfImagesClickedSoFar++;
                    clickedImagesList.Add(img);
                }
            }
            //Use the above generated list. fill up list to determine who owns what square
            foreach (Image image in clickedImagesList)
            {
                int row = (int)((Border)image.Parent).GetValue(Grid.RowProperty);
                int column = (int)((Border)image.Parent).GetValue(Grid.ColumnProperty);
                //checking to see if image contains x or o to determine who owns it
                bool isOwnedByPlayer1 = image.Source.ToString().EndsWith("Xgreen.png");
                bool isOwnedByPlayer2 = image.Source.ToString().EndsWith("Ogreen.png");
                if(isOwnedByPlayer1 == true)
                {
                    gvm.GameBoard[row, column] = 1;
                }
                else if(isOwnedByPlayer2 == true)
                {
                    gvm.GameBoard[row, column] = 2;
                }
                else
                {
                    gvm.GameBoard[row, column] = 0;
                }
               
            }
            //Check for win conditions
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if(gvm.GameBoard[r,c] == gvm.PlayerTurn)
                    {
                        //Setting up switch statements to find winning combinations and the direction of the win
                        WinDirections result = wl.findMatch(r, c, gvm.PlayerTurn);
                        switch (result)
                        {
                            //checks for a win left
                            case WinDirections.Left:
                                if (wl.findMatch(r, c - 1, gvm.PlayerTurn) == WinDirections.Left)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win right
                            case WinDirections.Right:
                                if (wl.findMatch(r, c + 1, gvm.PlayerTurn) == WinDirections.Right)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win up
                            case WinDirections.Up:
                                if (wl.findMatch(r - 1, c, gvm.PlayerTurn) == WinDirections.Up)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win down
                            case WinDirections.Down:
                                if (wl.findMatch(r + 1, c, gvm.PlayerTurn) == WinDirections.Down)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win diagonal up left
                            case WinDirections.DiagonalUpLeft:
                                if (wl.findMatch(r - 1, c - 1, gvm.PlayerTurn) == WinDirections.DiagonalUpLeft)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win diagonal up right
                            case WinDirections.DiagonalUpRight:
                                if (wl.findMatch(r - 1, c + 1, gvm.PlayerTurn) == WinDirections.DiagonalUpRight)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win diagonal down left
                            case WinDirections.DiagonalDownLeft:
                                if (wl.findMatch(r + 1, c - 1, gvm.PlayerTurn) == WinDirections.DiagonalDownLeft)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //Checks for a win diagonal down right
                            case WinDirections.DiagonalDownRight:
                                if (wl.findMatch(r + 1, c + 1, gvm.PlayerTurn) == WinDirections.DiagonalDownRight)
                                {
                                    if (gvm.PlayerTurn == 1)
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Xblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer1Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                    else
                                    {
                                        imageClicked.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Oblue.png");
                                        imageClicked.IsEnabled = false;
                                        wl.GameEndPlayer2Win(GameBoard.Children.OfType<Border>().ToArray());
                                        return;
                                    }
                                }
                                break;
                            //No winning moves
                            case WinDirections.None:
                                break;
                        }
                    }
                }
            }
            //Checks to see if all 9 squares have been clicked or not
            if (numOfImagesClickedSoFar == 9)
            {
                //if all 9 have been clicked, calls the game tie method
                wl.GameEndTie();

                return;
            }
            //calls the swap player turn method
            SwapPlayerTurn();
        }
        /// <summary>
        /// Resets all squares to the initial state and re-enables them after the win. Also changes the player's turn back to player 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            //Re-enables all squares so the user can again click the boxes
            foreach (Border border in GameBoard.Children.OfType<Border>())
            {
                Image img = (Image)border.Child;
                //Resets the images back to a blank
                img.Source = stringToImageSource("pack://application:,,,/TicTacToe;component/Content/Blank.png");
                img.IsEnabled = true;
            }
            GameViewModel clearGame = this.DataContext as GameViewModel;
            //Resets the player's turn back to player 1
            clearGame.PlayerTurn = 1;
            //Clears the array and starts a fresh one so the game board can be used again
            clearGame.GameBoard = new int[3, 3];
        }
    }       
}


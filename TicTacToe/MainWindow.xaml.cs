// Brandon Rolfe
// Project #7 (Tic-Tac-Toe)
// 5/3/21

using System;
using System.Threading;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Player info
        char   playerOneToken;
        char   playerTwoToken;
        string playerOneName;
        string playerTwoName;

        // Scores
        int  playerOneScore = 0;
        int  playerTwoScore = 0;
        int  ties           = 0;

        int currentPlayer = 1;

        Game currentGame;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the gameboard
        /// </summary>
        private void createBoard()
        {
            currentGame = new Game();

            TextBlock tempTextBlock;
            // controls for the grid
            int gridColumnIndex = 0;
            int gridRowIndex = 0;

            // Brush for gameboard symbols
            var customBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x79, 0x53, 0xCA));

            Board.Children.Clear();
            foreach (KeyValuePair<string, Square> kvp in currentGame.Board)
            {
                tempTextBlock = new TextBlock
                {
                    Name = kvp.Value.Name,
                    TextAlignment = TextAlignment.Center,
                    FontFamily = new FontFamily("Courier New"),
                    FontSize = 60,
                    Foreground = customBrush
                };
                Grid.SetRow(tempTextBlock, gridRowIndex);
                Grid.SetColumn(tempTextBlock, gridColumnIndex);
                Board.Children.Add(tempTextBlock);
                gridColumnIndex++;
                if (gridColumnIndex > 2)
                {
                    gridColumnIndex = 0;
                    gridRowIndex++;
                }
            }

            // Sets the current player for a new game
            switch (currentPlayer)
            {
                case 1:
                    TurnBox.Content = (playerOneName + "'s Turn");
                    break;
                case 2:
                    TurnBox.Content = (playerTwoName + "'s Turn");
                    break;
            }
        }

        /// <summary>
        /// Initializes player data and changes the page to show the gameplay fields
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Argument</param>
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // If all input boxes are full
            if (PlayerOneNameBox.Text != string.Empty && PlayerOneSymbolBox.Text != string.Empty && PlayerTwoNameBox.Text != string.Empty && PlayerTwoSymbolBox.Text != string.Empty)
            {
                
                try
                {
                    playerOneToken = Convert.ToChar(PlayerOneSymbolBox.Text);
                    playerTwoToken = Convert.ToChar(PlayerTwoSymbolBox.Text);
                }
                catch (FormatException ex)
                {
                    OutputHolder.Content = ex.Message;
                    return;
                }

                // Hides initial input fields and prompts
                PlayerOneTitle.Visibility = Visibility.Hidden;
                PlayerOneName.Visibility = Visibility.Hidden;
                PlayerOneNameBox.Visibility = Visibility.Hidden;
                PlayerOneSymbol.Visibility = Visibility.Hidden;
                PlayerOneSymbolBox.Visibility = Visibility.Hidden;

                PlayerTwoTitle.Visibility = Visibility.Hidden;
                PlayerTwoName.Visibility = Visibility.Hidden;
                PlayerTwoNameBox.Visibility = Visibility.Hidden;
                PlayerTwoSymbol.Visibility = Visibility.Hidden;
                PlayerTwoSymbolBox.Visibility = Visibility.Hidden;

                StartGame.Visibility = Visibility.Hidden;

                // Shows fields for gameplay
                PlayerOneGameStarted.Visibility = Visibility.Visible;
                playerOneName = (PlayerOneNameBox.Text + " (" + playerOneToken + ")");
                PlayerOneGameStarted.Content = playerOneName + ": ";
                PlayerTwoGameStarted.Visibility = Visibility.Visible;
                playerTwoName = (PlayerTwoNameBox.Text + " (" + playerTwoToken + ")");
                PlayerTwoGameStarted.Content = playerTwoName + ": ";
                Ties.Visibility = Visibility.Visible;
                PlayerOneScore.Visibility = Visibility.Visible;
                PlayerTwoScore.Visibility = Visibility.Visible;
                TieScore.Visibility = Visibility.Visible;

                TurnBox.Visibility = Visibility.Visible;

                SampleGame.Visibility = Visibility.Hidden;

                // Allows the board to be used
                Board.IsEnabled = true;

                // Resets the current player to player one
                currentPlayer = 1;

                // Empties the output box
                OutputHolder.Content = string.Empty;

                // Generates a new board
                createBoard();
            }
            else
            {
                OutputHolder.Content = "All boxes must be filled.";
            }
        }

        /// <summary>
        /// Resets the gameboard
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Argument</param>
        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            // Reset display for new game
            Board.IsEnabled = true;
            RestartGame.Visibility = Visibility.Hidden;
            TurnBox.Visibility = Visibility.Visible;
            OutputHolder.Content = string.Empty;

            // Create new game
            createBoard();
        }

        /// <summary>
        /// Attempts to fill in the selected square with the current players token
        /// </summary>
        /// <param name="sender">Returns a UIElement that should be a TextBlock</param>
        /// <param name="e">Event Argumenet</param>
        private void Board_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Attempts to fill in the selected square
            try
            {
                // This is the one that does not work
                currentGame.Board[((TextBlock)e.Source).Name].Holder = currentPlayer;

                //Square currentSquare = currentGame.Board[((TextBlock)e.Source).Name];
                //currentSquare.Holder = currentPlayer;
                //currentGame.Board[((TextBlock)e.Source).Name] = currentSquare;
                ////throw new Exception("this is a test");
            }
            // If already taken
            catch (Exception ex)
            {
                OutputHolder.Content = ex.Message;
                return;
            }

            // Switches the current player
            switch (currentPlayer)
            {
                case 1:
                    ((TextBlock)e.Source).Text = playerOneToken.ToString();
                    currentPlayer = 2;
                    TurnBox.Content = (playerTwoName + "'s Turn");
                    break;
                case 2:
                    ((TextBlock)e.Source).Text = playerTwoToken.ToString();
                    currentPlayer = 1;
                    TurnBox.Content = (playerOneName + "'s Turn");
                    break;
            }

            // Checks if there is a winner
            switch (currentGame.ifWinner())
            {
                // No Winner
                case 0:
                    break;
                // Player One won
                case 1:
                    OutputHolder.Content = "Player One Wins";
                    playerOneScore++;
                    PlayerOneScore.Content = playerOneScore;
                    RestartGame.Visibility = Visibility.Visible;
                    Board.IsEnabled = false;
                    TurnBox.Visibility = Visibility.Hidden;
                    break;
                // Player Two won
                case 2:
                    OutputHolder.Content = "Player Two Wins";
                    playerTwoScore++;
                    PlayerTwoScore.Content = playerTwoScore;
                    RestartGame.Visibility = Visibility.Visible;
                    Board.IsEnabled = false;
                    TurnBox.Visibility = Visibility.Hidden;
                    break;
                // Tie
                case 3:
                    OutputHolder.Content = "Tie";
                    ties++;
                    TieScore.Content = ties;
                    RestartGame.Visibility = Visibility.Visible;
                    Board.IsEnabled = false;
                    TurnBox.Visibility = Visibility.Hidden;
                    break;
            }
        }

        /// <summary>
        /// Runs a sample game with randomly selected squares
        /// </summary>
        private void sampleGame()
        {
            createBoard();

            // Set sample tokens
            playerOneToken = 'X';
            playerTwoToken = 'O';

            Random rand = new Random();

            // Play a sample game
            // Loops while there is no winner
            while(currentGame.ifWinner() == 0)
            {
                // Chooses a square at random
                int chosenSquareNum = rand.Next(0, 9);
                string chosenSquareStr = chosenSquareNum switch
                {
                    0 => "NW",
                    1 => "N",
                    2 => "NE",
                    3 => "W",
                    4 => "C",
                    5 => "E",
                    6 => "SW",
                    7 => "S",
                    8 => "SE"
                };

                // Attempts to take the square
                try
                {
                    Square currentSquare = currentGame.Board[chosenSquareStr];
                    currentSquare.Holder = currentPlayer;
                    currentGame.Board[chosenSquareStr] = currentSquare;
                }
                catch (Exception)
                {
                    continue;
                }

                // Changes the current player
                switch (currentPlayer)
                {
                    case 1:
                        ((TextBlock)Board.Children[chosenSquareNum]).Text = playerOneToken.ToString();
                        currentPlayer = 2;
                        break;
                    case 2:
                        ((TextBlock)Board.Children[chosenSquareNum]).Text = playerTwoToken.ToString();
                        currentPlayer = 1;
                        break;
                }
                //Thread.Sleep(3000);
            }
            //Thread.Sleep(10000);
        }

        /// <summary>
        /// Starts the sample game
        /// </summary>
        /// /// <param name="sender">Button clicked</param>
        /// <param name="e">Event Argument</param>
        private void SampleGame_Click(object sender, RoutedEventArgs e)
        {
            sampleGame();
        }
    }
}

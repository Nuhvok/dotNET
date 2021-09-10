// Brandon Rolfe
// Project #7 (Tic-Tac-Toe)
// 5/3/21

using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// Contains a Tic Tac Toe game
    /// </summary>
    class Game
    {
        public Dictionary<string, Square> Board { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Game()
        {
            Board = new Dictionary<string, Square>
            {
                { "NW", new Square { Name = "NW" } },
                { "N", new Square { Name = "N" } },
                { "NE", new Square { Name = "NE" } },
                { "W", new Square { Name = "W" } },
                { "C", new Square { Name = "C" } },
                { "E", new Square { Name = "E" } },
                { "SW", new Square { Name = "SW" } },
                { "S", new Square { Name = "S" } },
                { "SE", new Square { Name = "SE" } }
            };
        }

        /// <summary>
        /// Checks if there is a winner or tie
        /// </summary>
        /// <returns>
        ///     0 = no winner
        ///     1 = player one win
        ///     2 = player two win
        ///     3 = tie
        /// </returns>
        public int ifWinner()
        {
            if      (Board["NW"].Holder != null && Board["NW"].Holder == Board["N"].Holder && Board["N"].Holder == Board["NE"].Holder)
            {
                return Board["NW"].Holder.Value;
            }
            else if (Board["W" ].Holder != null && Board["W" ].Holder == Board["C"].Holder && Board["C"].Holder == Board["E" ].Holder)
            {
                return Board["W" ].Holder.Value;
            }
            else if (Board["SW"].Holder != null && Board["SW"].Holder == Board["S"].Holder && Board["S"].Holder == Board["SE"].Holder)
            {
                return Board["SW"].Holder.Value;
            }
            else if (Board["NW"].Holder != null && Board["NW"].Holder == Board["W"].Holder && Board["W"].Holder == Board["SW"].Holder)
            {
                return Board["NW"].Holder.Value;
            }
            else if (Board["N" ].Holder != null && Board["N" ].Holder == Board["C"].Holder && Board["C"].Holder == Board["S" ].Holder)
            {
                return Board["N" ].Holder.Value;
            }
            else if (Board["NE"].Holder != null && Board["NE"].Holder == Board["E"].Holder && Board["E"].Holder == Board["SE"].Holder)
            {
                return Board["E" ].Holder.Value;
            }
            else if (Board["NW"].Holder != null && Board["NW"].Holder == Board["C"].Holder && Board["C"].Holder == Board["SE"].Holder)
            {
                return Board["NW"].Holder.Value;
            }
            else if (Board["NE"].Holder != null && Board["NE"].Holder == Board["C"].Holder && Board["C"].Holder == Board["SW"].Holder)
            {
                return Board["NE"].Holder.Value;
            }
            else if (Board["NW"].Holder != null &&
                     Board["N" ].Holder != null &&
                     Board["NE"].Holder != null &&
                     Board["W" ].Holder != null &&
                     Board["C" ].Holder != null &&
                     Board["E" ].Holder != null &&
                     Board["SW"].Holder != null &&
                     Board["S" ].Holder != null &&
                     Board["SE"].Holder != null)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Contains an individual square on a Tic Tac Toe board
    /// </summary>
    class Square
    {
        private int? holder;

        /// <summary>
        /// Manages the holder. It does not allow a square to be chosen multiple times
        /// </summary>
        public int? Holder
        {
            get => holder;
            set
            {
                if(holder == null)
                {
                    holder = value;
                }
                else
                {
                    throw new Exception("That square is already taken.");
                }
            }
        }

        /// <summary>
        /// Manages the name of the square
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}

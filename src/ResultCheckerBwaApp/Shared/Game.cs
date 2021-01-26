using System;
using System.Collections.Generic;
using System.Text;

namespace ResultCheckerBwaApp.Shared
{
    public class Game
    {
        public DateTime Date { get; set; }

        public string Player1 { get; set; }

        public string Player2 { get; set; }

        public string Score => Process(Player1, Player2);

        string Process(string player1, string player2) => (player1, player2) switch
        {
            ("Rock", "Paper") => "Rock is covered by Paper. Paper wins.",
            ("Rock", "Scissors") => "Rock breaks Scissors. Rock wins.",
            ("Paper", "Rock") => "Paper covers Rock. Paper wins.",
            ("Paper", "Scissors") => "Paper is cut by Scissors. Scissors wins.",
            ("Scissors", "Rock") => "Scissors is broken by Rock. Rock wins.",
            ("Scissors", "Paper") => "Scissors cuts Paper. Scissors wins.",
            (_, _) => "Tie"
        };
    }
}

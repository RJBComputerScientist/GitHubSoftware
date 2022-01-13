namespace RockPaperScissors.Logic {
    public class Round {
        public Moves Player1 { get; }
        public Moves Player2 { get; }
        public DateTime Date { get; }
        public RoundResult Result => EvaluateResult(Player1, Player2);
        public Round(DateTime date, Moves Player1, Moves Player2){
            this.Date = date;
            this.Player1 = Player1;
            this.Player2 = Player2;
        }

        //assigning player one to player 1
        //assigning CPU to player 2

        public static RoundResult EvaluateResult(Moves Player1, Moves Player2){
            return (Player1, Player2) switch {
                (Moves.Rock, Moves.Scissors) => RoundResult.Win,
                (Moves.Scissors, Moves.Rock) => RoundResult.Loss,
                (Moves.Paper, Moves.Rock) => RoundResult.Win,
                (Moves.Rock, Moves.Paper) => RoundResult.Loss,
                (Moves.Scissors, Moves.Paper) => RoundResult.Win,
                (Moves.Paper, Moves.Scissors) => RoundResult.Loss,
                (var P, var Q) when P == Q => RoundResult.Tie,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
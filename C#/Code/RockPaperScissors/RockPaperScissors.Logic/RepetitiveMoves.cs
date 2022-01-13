namespace RockPaperScissors.Logic
{
    public class RepetitiveMoveDecider : MoveInterface
    {
        private Moves _previousMove = Moves.Scissors;

        public Moves DecideMove()
        {
            Moves newMove = _previousMove switch
            {
                Moves.Paper => Moves.Rock,
                Moves.Rock => Moves.Scissors,
                Moves.Scissors => Moves.Paper,
                _ => throw new InvalidOperationException() // impossible
            };
            _previousMove = newMove;
            return newMove;
        }
    }
}
using System.Xml.Serialization;
using RockPaperScissors.Logic;

/* ============== NOTES ==============
The null-coalescing operator ?? returns the value 
of its left-hand operand if it isn't null; 
*/

namespace RockPaperScissors.App.Serialization{
    public class Record {
        [XmlAttribute]
        public DateTime When {get; set;}
        public string? CPUMove {get; set;}
        public string? PlayerMove {get; set;}
        public string? Result {get; set;}

        public Round createRound(){
           var player1 = (Moves)Enum.Parse(typeof(Moves), PlayerMove ?? throw new InvalidOperationException("Player Move Cant Be Null"));
        //    var player1 = "null";
           /*An enumeration type (or enum type) is a value 
           type defined by a set of named constants of the 
           underlying integral numeric type.
           */
           var player2 = (Moves)Enum.Parse(typeof(Moves), CPUMove ?? throw new InvalidOperationException("CPU Move Cant Be Null"));
        //    var player2 = "null";
            return new Round(date: When, Player1: player1, Player2: player2);
        }
    }
}
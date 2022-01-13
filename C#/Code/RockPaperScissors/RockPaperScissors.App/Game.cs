using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RockPaperScissors.Logic;
using Xml = RockPaperScissors.App.Serialization;
//^^ using directives

namespace RockPaperScissors.App
{
    public class Game
    {
        // public string Summary
        // {
        //     get
        //     {
        //         return "(not implemented yet)";
        //     }
        // }
         string PlayerName; 
         //^^ ill want a public getter here
         public string Player {get;}
        //  string Computer;
        //  string Move;
        //  private List<Record> AllRecords = new List<Record>();
        private static Random random = new Random();
        List<Round>? AllRecords = new List<Round>();
        private readonly MoveInterface CPUMoves;
         public XmlSerializer Serializer { get; } = new(typeof(List<Xml.Record>));

public Game(string? PlayerName,  MoveInterface CPUMoves, List<Round>? AllRecords = null){
this.Player = PlayerName;
this.CPUMoves = CPUMoves;
if(AllRecords != null){
    this.AllRecords = AllRecords;
}
}
// private static string ComputerChoice(int length){
//     // const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
//     const string chars = "PRS0";
//     string RandomIzer = new string(Enumerable.Repeat(chars, length)
//         .Select(s => s[random.Next(s.Length)]).ToArray());
//         //^^ my custom randomizer
//         string GameComputer = "";
//       switch(RandomIzer){
//                 case "R":
//                     GameComputer = "ROCK";
//                     // this.Move = PLayerMove;
//                     break;
//                 case "P":
//                    GameComputer = "PAPER";
//                     break;
//                 case "S":
//                     GameComputer = "SCISSORS";
//                     break;

//                 default:
//                 // '0' will be the default case
//                     Console.WriteLine("Your Human Intelligence Is Too Much..\n" +
//                     " COMPUTER LEFT THE ROOM");
//                     return RandomIzer;
//             }
//             Console.WriteLine("The Computer Randomized To "+RandomIzer+
//             " And Choosed "+GameComputer);
//             return GameComputer;
//             //^^ returning what i made the computer choice to be
//     // return new string(Enumerable.Repeat(chars, length)
//     //     .Select(s => s[random.Next(s.Length)]).ToArray());
// }

        public void PlayRound(){
            //Player Vs. Computer
            // Console.WriteLine("Whats Your Name?");
            Console.WriteLine("Whats Your Playing Name?");
            string? Name = Console.ReadLine();
            this.PlayerName = Name;
            // Console.WriteLine($"Ok {PlayerName}, Choose 'Rock', 'Paper' Or 'Scissors'");
            Console.WriteLine($"Ok {PlayerName}, Pick '1. Rock', '2. Paper' Or '3. Scissors'");
            // string? Choose = Console.ReadLine();
            // string PLayerMove = "";
            //^^ dont make these vars
            // string NewChoose = Choose.ToUpper();
            //     while(NewChoose != "ROCK" && NewChoose != "PAPER" && NewChoose != "SCISSORS"){
            //          Console.WriteLine("Choose A Real Move");
            //          NewChoose = Console.ReadLine().ToUpper();
            //          Console.WriteLine(NewChoose);
            //     }
            //     this.Computer = ComputerChoice(1);
            //     Console.WriteLine(Computer);
            // switch(NewChoose){
            //     case "ROCK":
            //         PLayerMove = NewChoose;
            //         this.Move = PLayerMove;
            //         break;
            //     case "PAPER":
            //        PLayerMove = NewChoose;
            //         this.Move = PLayerMove;
            //         break;
            //     case "SCISSORS":
            //         PLayerMove = NewChoose;
            //         this.Move = PLayerMove;
            //         break;

            //     default:
            //         return PLayerMove;
            // }
            // Console.WriteLine(Move);
            // return Move;
            // throw new NotImplementedException();
            // Console.WriteLine("1. Rock\n2. Paper\n3. Scissor");
            string? Choose = null;
            // string? Choose = Console.ReadLine();
            int Player=0;
            while (Choose == null || Choose.Length <= 0 )
            {
                Console.Write("What's your choice? ");
                Choose = Console.ReadLine();
                bool validchoice = int.TryParse(Choose, out Player);
                if (!validchoice || (Player > 3 || Player < 0) )
                {
                    Console.WriteLine("Invalid Choice, Try Again!");
                    Console.WriteLine();
                    Choose=null;
                    continue;
                }
               
            }

            Moves CPUChoice = CPUMoves.DecideMove();
            Console.WriteLine();// skipping a line
            Moves PlayerChoice = (Moves)(Player - 1);
            Console.WriteLine($"Your Move Was [{PlayerChoice}]");
            Console.WriteLine($"The Computer Move Was [{CPUChoice}]");
            AddRecord(PlayerChoice, CPUChoice);
        }
       private void AddRecord(Moves Player, Moves PC){
           var Record= new Round(DateTime.Now, Player, PC);
           AllRecords.Add(Record);
           Console.WriteLine($"You have a {Record.Result}!");
       }

       public void Summary()
        {
            var Summary = new StringBuilder();
            Summary.AppendLine($"Date\t\t\t{Player}\t\tComputer\tResult");
            Summary.AppendLine("---------------------------------------------------------------");
            foreach (var record in AllRecords)
            {
                Summary.AppendLine($"{record.Date}\t{record.Player1}\t\t{record.Player2}\t\t{record.Result}");
            }
            Summary.AppendLine("---------------------------------------------------------------");
            
            Console.WriteLine(Summary.ToString());
        }

        public string SerializeAsXml()
        {
            var xmlRecords = new List<Xml.Record>();

            foreach (Round record in AllRecords)
            {
                //var xml = new Xml.Record();
                //xml.When = record.Date;
                //xml.PlayerMove = record.Player;
                //xml.CPUMove = record.PC;
                //xml.Result = record.result;
                // "property initializer" syntax - call a constructor & set properties in one go.
                xmlRecords.Add(new Xml.Record
                {
                    When = record.Date,
                    PlayerMove = record.Player1.ToString(),
                    CPUMove = record.Player2.ToString(),
                    Result = record.Result.ToString()
                });
            }

            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, xmlRecords);
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}
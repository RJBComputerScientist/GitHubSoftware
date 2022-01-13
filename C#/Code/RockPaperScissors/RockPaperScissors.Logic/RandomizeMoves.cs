namespace RockPaperScissors.Logic {
    public class RandomizeMoves : MoveInterface {
       public Moves DecideMove(){
    // const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    // const string chars = "PRS0";
    // string RandomIzer = new string(Enumerable.Repeat(chars, length)
    //     .Select(s => s[random.Next(s.Length)]).ToArray());
    //     //^^ my custom randomizer
    //     string GameComputer = "";
    //   switch(RandomIzer){
    //             case "R":
    //                 GameComputer = "ROCK";
    //                 // this.Move = PLayerMove;
    //                 break;
    //             case "P":
    //                GameComputer = "PAPER";
    //                 break;
    //             case "S":
    //                 GameComputer = "SCISSORS";
    //                 break;

    //             default:
    //             // '0' will be the default case
    //                 Console.WriteLine("Your Human Intelligence Is Too Much..\n" +
    //                 " COMPUTER LEFT THE ROOM");
    //                 return RandomIzer;
    //         }
    //         Console.WriteLine("The Computer Randomized To "+RandomIzer+
    //         " And Choosed "+GameComputer);
    //         return GameComputer;
    //         //^^ returning what i made the computer choice to be
    // // return new string(Enumerable.Repeat(chars, length)
    // //     .Select(s => s[random.Next(s.Length)]).ToArray());
            Random random = new();
            return (Moves)random.Next(3); //starts from 0
       }
    }
}
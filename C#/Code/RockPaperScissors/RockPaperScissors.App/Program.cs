// app to play rock-paper-scissors with the computer

// required features:
// - play multiple rounds
// - get a summary/record of all the rounds played so far

// stretch goal features:
// - persistence (save data somehow, it will remember past game history) (and clear history)
// - play more complex variants of RPS (like RPS+lizard+spock)
// - logging (to help with debugging the app if something goes wrong)
// - some way to have more than 2 players at a time
// - support both player vs player and player vs computer
// - difficulty settings for the computer (remembers your moves and tries to predict)

// - in general, we want to write something simple
//    but in a way that allows for extending it / generalizing it in the future.
using System.Diagnostics;
using System.Xml.Serialization;
using RockPaperScissors.Logic;
/* =========== NOTES ===========
    any objects inside the CLR are automatically cleaned up by the garbage collector
    when we're done with them.
    but... some objects contain/handle resources outside the CLR (e.g. file system, network).
    e.g. StreamReader opening a file.
    for those, you have to explicitly call the Close or Dispose method.
    typically you do this in a finally block to be 100% sure that it will be called in all cases.
    .NET has a special interface called IDisposable that basically tells you
     this is a class that needs to be Disposed when you're done.
*/

namespace RockPaperScissors.App

{
    public class Program
    {
        public static void Main()
        {
            MoveInterface MoveDecider = new RandomizeMoves();
            List<Round>? Records = ReadRecordsFromFile("../Records.xml");
            Console.WriteLine("Welcome to RockPaperScissors App");
            /*
            Console.WriteLine("Whats Your Name?");
            var Name = Console.ReadLine();
            this.Player = Name;
            Console.WriteLine($"Ok {Player}, Choose 'Rock', 'Paper' Or 'Scissors'");
            string? Choose = Console.ReadLine();
            //^^ old code
            */
        string? Name = null;
        while(Name == null || Name.Length <= 0){
            Console.WriteLine("Whats Your Account Name?");
            Thread.Sleep(2000);
            /*^^^^^
        Applications commonly use multiple threads 
        instead of asynchronous processing. The 
        application creates a separate thread, 
        calls an ODBC function on it, and then
         continues processing on the main thread.
            */
            Name = Console.ReadLine();
        }
            // var game = new Game(name,records);
            Game game = new(Name,MoveDecider,Records);
            var PlayAgain = true;
            Console.WriteLine($"[%% Welcome Player {game.Player}. %%]");
            while (PlayAgain){
                Console.WriteLine("======="); //skipping a line
                Console.WriteLine("FEATURES COMING SOON");
                Console.WriteLine("Play a round With RoBo? (y/n) ");

                string? Input = Console.ReadLine();

                if (Input?.ToLower() != "y" || Input == null) { 
                    Console.WriteLine("&&&& END OF GAME &&&&");
                    break; 
                    }

                game.PlayRound();
            }
            Console.WriteLine("=== The Game Record ===");
            game.Summary();
            WriteRecordsToFile(game, "../Records.xml");

            // string summary = game.Summary();
            // Console.WriteLine(summary);

            /* ============== NOTES ==============
    if the stores name equals 'Food Store' write the history to "../FoodHistory.xml"
    if the stores name equals 'Shoe Store' write the history to "../ShoeHistory.xml"
    
*/
        }

        private static void WriteRecordsToFile(Game game, string FilePath){
        /*      ^^^^^^
        Use the static modifier to declare a static 
        member, which belongs to the type itself 
        rather than to a specific object. 
        */
        string AlmostXML = game.SerializeAsXml();
        File.WriteAllText(FilePath, AlmostXML);
        }
        // private static List<Round>? ReadRecordsFromFile(Game game, string FilePath){
    //     private static List<Round>? ReadRecordsFromFile(string FilePath){
    //     /*      ^^^^^^
    //     Use the static modifier to declare a static 
    //     member, which belongs to the type itself 
    //     rather than to a specific object. 
    //     */
    //     XmlSerializer Serializer = new(typeof(List<Record>));
    //     StreamReader? Reader = null;
    // try
    // {
    //       Reader = new(FilePath);
    //     //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
    //      var Records = (List<Record>?)Serializer.Deserializer(Reader);
    //      return Records;
    // }
    // catch (FileNotFoundException)
    // {
        
    //     return null;
    // } finally {
    //     if(Reader != null){
    //         Reader.Close();
    //     }
    // }
    //     string AlmostCode = File.ReadAllText(FilePath);
    //     List<Record> Record = null;
    //     game.SerializeAsXml();
    //     }
        private static List<Round>? ReadRecordsFromFile(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Serialization.Record>));
    try
        {
       using StreamReader Reader = new(FilePath);
        //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
         var Records = (List<Serialization.Record>?)Serializer.Deserialize(Reader);
          if (Records is null) throw new InvalidDataException();

                // sneak peak into nice advanced feature called LINQ, using lambda expression delegates
                return Records.Select(x => x.createRound()).ToList();
    }
    catch (System.Exception)
    {
        
        return null;
    } 
        }
    }
}
namespace Classes{
    public class Person {
        string FirstName;
        //private is default
        private string LastName;

        public Person() {
            //constructor that accepts no parameters
            FirstName = "My Name";
            LastName = "Is Default";
            //^^ without input 
        }

        public Person(string First, string Last){
            FirstName = First;
            LastName = Last;
            //^^ this fills in what FirstName & LastName will be 
        }

        public void setFirstName(string name){
            FirstName = name;
        }

        public string getFirstName(){
            return FirstName;
        }

        public void setLastName(string name){
            LastName = name;
        }

        public string getLastName(){
            return LastName;
        }

        public void Introduce(){
            Console.WriteLine($"Hey, My Name Is {FirstName} {LastName}");
        }

          public void ChangeName(string First, string Last){
                setFirstName(First);
                setLastName(Last);
            }
    }
}

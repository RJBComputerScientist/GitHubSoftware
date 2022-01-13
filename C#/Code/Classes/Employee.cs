namespace Classes {
    public class Employee : Person{
        public int HoursWorked;
        public double PayRate;
        public double MinHours;
        public double MaxHours;

        public Employee(int HoursWorked, double PayRate, string FirstName, string LastName) : base(){
            this.HoursWorked = HoursWorked;
            this.PayRate = PayRate;
        }
        public Employee(){
            this.HoursWorked = 0;
            this.PayRate = -5;
        }

        public void DoWork(){
            Console.WriteLine($"I've Worked {HoursWorked} Hours.");
        }

        public void setMinHours(double hours){
            MinHours = hours;
        }
        public void setMaxHours(double hours){
            MaxHours = hours;
        }
        public double getMinHours(){
            return MinHours;
        }
        public double getMaxHours(){
            return MaxHours;
        }
        public void setPayRate(double rate){
            PayRate = rate;
        }
        public double getPayRate(){
            return PayRate;
        }
    }
}

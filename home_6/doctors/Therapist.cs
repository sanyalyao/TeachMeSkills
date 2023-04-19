namespace home_6.doctors
{
    class Therapist : Doctor
    {
        public Therapist(string name) : base(name)
        {
        }

        public override void Treat(Patient patient)
        {
            Console.WriteLine($"{this.Name} will take care of {patient.Name}");
            Console.WriteLine();
        }
    }
}

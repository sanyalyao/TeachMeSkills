namespace home_6.doctors
{
    class Doctor
    {
        public string Name { get; set; }

        public Doctor(string name)
        {
            this.Name = name;
        }

        public virtual void Treat(Patient patient)
        {

        }
    }
}

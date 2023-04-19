namespace home_6
{
    enum IlnessType
    {
        Eyes,
        Teeth,
        Other
    }

    class Patient
    {
        public IlnessType IlnessType { get; set; }
        public string Name { get; set; }

        public Patient(IlnessType ilnessType, string name)
        {
            this.IlnessType = ilnessType;
            this.Name = name;
        }
    }
}

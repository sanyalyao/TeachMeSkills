using home_6.doctors;

namespace home_6
{
    class Clinic
    {
        public void VisitDoctor(List<Doctor> doctors, List<Patient> patients)
        {
            foreach (Doctor doctor in doctors)
            {
                foreach (Patient patient in patients)
                {
                    switch (patient.IlnessType)
                    {
                        case IlnessType.Eyes:
                            {
                                if (doctor.GetType() == typeof(Ophthalmologist))
                                {
                                    Console.WriteLine($"{patient.Name}, you should visit a doctor - {doctor.Name}");
                                    doctor.Treat(patient);
                                }
                                break;
                            }
                        case IlnessType.Teeth:
                            {
                                if (doctor.GetType() == typeof(Dentist))
                                {
                                    Console.WriteLine($"{patient.Name}, you should visit a doctor - {doctor.Name}");
                                    doctor.Treat(patient);
                                }
                                break;
                            }
                        default:
                            {
                                if (doctor.GetType() == typeof(Therapist))
                                {
                                    Console.WriteLine($"{patient.Name}, you should visit a doctor - {doctor.Name}");
                                    doctor.Treat(patient);
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
}

using home_6.doctors;

namespace home_6
{
    class Program
    {
        static void Main()
        {
            Clinic clinic = new Clinic();

            Ophthalmologist ophthalmologist = new Ophthalmologist("ophthalmologist");
            Therapist therapist = new Therapist("therapist");
            Dentist dentist = new Dentist("dentist");

            Patient patientIlnessEyes = new Patient(IlnessType.Eyes, "Polina");
            Patient patientIlnessTeeth = new Patient(IlnessType.Teeth, "Tom");
            Patient patientIlnessOther = new Patient(IlnessType.Other, "Jerry");

            List<Doctor> doctors = new List<Doctor>() { ophthalmologist, therapist, dentist };
            List<Patient> patients = new List<Patient>() { patientIlnessEyes, patientIlnessTeeth, patientIlnessOther };

            clinic.VisitDoctor(doctors, patients);
        }
    }
}
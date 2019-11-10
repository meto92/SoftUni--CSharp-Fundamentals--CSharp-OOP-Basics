using System;
using System.Collections.Generic;

public class Startup
{
    static void ReadAndProcessCommandsForAddingPatients(Hospital hospital)
    {
        string command = null;

        while ((command = Console.ReadLine()) != "Output")
        {
            string[] tokens = command.Split();

            string department = tokens[0];
            string doctorFirstName = tokens[1];
            string doctorLastName = tokens[2];
            string patient = tokens[3];
            string doctorFullName = $"{doctorFirstName} {doctorLastName}";

            hospital.TryAddPatient(department, doctorFullName, patient);
        }
    }

    static void ReadAndProcessCommandsForPrinting(Hospital hospital)
    {
        string command = null;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                string department = args[0];

                List<string> patients = hospital.GetPatientsFromDepartment(department);

                patients.ForEach(Console.WriteLine);
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int roomNumber))
            {
                string department = args[0];

                List<string> patients = hospital.GetPatientSortedByNameFromRoom(department, roomNumber);

                patients.ForEach(Console.WriteLine);
            }
            else
            {
                string doctorFirstName = args[0];
                string doctorLastName = args[1];
                string doctorFullName = $"{doctorFirstName} {doctorLastName}";

                List<string> patientsHealedByDoctor = hospital.GetPatientsSortedByNameHealedByDoctor(doctorFullName);

                patientsHealedByDoctor.ForEach(Console.WriteLine);
            }
        }
    }

    public static void Main()
    {
        Hospital hospital = new Hospital();

        ReadAndProcessCommandsForAddingPatients(hospital);
        ReadAndProcessCommandsForPrinting(hospital);        
    }
}
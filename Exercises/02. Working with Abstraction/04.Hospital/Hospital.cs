using System.Linq;
using System.Collections.Generic;

public class Hospital
{
    private Dictionary<string, List<List<string>>> departments;
    private Dictionary<string, List<string>> patientsByDoctors;

    public Hospital()
    {
        this.departments = new Dictionary<string, List<List<string>>>();
        this.patientsByDoctors = new Dictionary<string, List<string>>();
    }

    private void AddNewDepartment(string department)
    {
        this.departments[department] = new List<List<string>>();

        for (int room = 0; room < 20; room++)
        {
            this.departments[department].Add(new List<string>());
        }
    }

    private int GetPatientRoomNumber(string department)
    {
        int roomNumber = 0;

        for (int room = 0; room < this.departments[department].Count; room++)
        {
            if (this.departments[department][room].Count < 3)
            {
                roomNumber = room;
                break;
            }
        }

        return roomNumber;
    }

    private void AddPatient(string patient, string department, string doctorFullName)
    {
        int roomNumber = GetPatientRoomNumber(department);

        this.departments[department][roomNumber].Add(patient);
        this.patientsByDoctors[doctorFullName].Add(patient);
    }

    public void TryAddPatient(string department, string doctorFullName, string patient)
    {
        if (!this.patientsByDoctors.ContainsKey(doctorFullName))
        {
            this.patientsByDoctors[doctorFullName] = new List<string>();
        }

        if (!this.departments.ContainsKey(department))
        {
            AddNewDepartment(department);
        }

        bool isThereFreeBed = this.departments[department].SelectMany(x => x).Count() < 60;

        if (isThereFreeBed)
        {
            AddPatient(patient, department, doctorFullName);
        }
    }    

    public List<string> GetPatientsFromDepartment(string department)
    {
        List<string> patients = this.departments[department]
           .Where(x => x.Count > 0)
           .SelectMany(x => x)
           .ToList();

        return patients;
    }

    public List<string> GetPatientSortedByNameFromRoom(string department, int roomNumber)
    {
        List<string> patients =
            this.departments[department][roomNumber - 1]
                .OrderBy(x => x).ToList();

        return patients;
    }

    public List<string> GetPatientsSortedByNameHealedByDoctor(string doctorFullName)
    {
        List<string> patients =
            this.patientsByDoctors[doctorFullName]
                .OrderBy(x => x).ToList();

        return patients;
    }
}
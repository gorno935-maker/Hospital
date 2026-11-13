using System;

// ===== Абстрактный класс Doctor (с заданием №2) =====
public abstract class Doctor
{
    public string Name { get; }
    public int Experience { get; }

    // Задание №2: абстрактное свойство специальности
    public abstract string Specialization { get; }

    protected Doctor(string name, int experience)
    {
        Name = name;
        Experience = experience;
    }

    public abstract void Reception();
}

// ===== Существующие врачи с реализацией Specialization =====
public class Therapist : Doctor
{
    public override string Specialization => "Терапевт";

    public Therapist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Терапевт проводит общий осмотр пациента.");
    }
}

public class Cardiologist : Doctor
{
    public override string Specialization => "Кардиолог";

    public Cardiologist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Кардиолог проводит проверку сердца.");
    }
}

public class Dentist : Doctor
{
    public override string Specialization => "Стоматолог";

    public Dentist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Стоматолог проводит осмотр зубов.");
    }
}

// ===== Задание №1: Невролог =====
public class Neurologist : Doctor
{
    // Специальность нужна, раз свойство абстрактное
    public override string Specialization => "Невролог";

    public Neurologist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Невролог проводит проверку нервной системы.");
    }
}

// ===== Задание №3: Пациент =====
public class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Diagnosis { get; set; }

    public Patient(string name, int age, string diagnosis)
    {
        Name = name;
        Age = age;
        Diagnosis = diagnosis;
    }

    public void ShowPatientInfo()
    {
        Console.WriteLine($"Пациент: {Name}, возраст: {Age}, диагноз: {Diagnosis}");
    }
}

// ===== Задание №4: Запись на приём =====
public class Appointment
{
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }

    public Appointment(Patient patient, Doctor doctor, DateTime date)
    {
        Patient = patient;
        Doctor = doctor;
        Date = date;
    }

    public void ShowAppointment()
    {
        Console.WriteLine("=== Запись на приём ===");
        Console.WriteLine($"Пациент: {Patient.Name}");
        Console.WriteLine($"Врач: {Doctor.Name} ({Doctor.Specialization}), стаж: {Doctor.Experience} лет");
        Console.WriteLine($"Дата приёма: {Date:dd.MM.yyyy HH:mm}");
    }
}

// ===== Демонстрация =====
public class Program
{
    public static void Main()
    {
        // Задание №1 и №2
        Doctor[] doctors =
        {
            new Therapist("Иванов И.И.", 10),
            new Cardiologist("Петрова А.С.", 15),
            new Dentist("Сидоров К.П.", 7),
            new Neurologist("Алиева Д.Р.", 12)
        };

        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine($"{doctor.Name} — {doctor.Specialization}");
            doctor.Reception();
            Console.WriteLine();
        }

        // Задание №3 (вымышленные данные)
        Patient patient = new Patient("Смирнов Алексей", 34, "Мигрень");
        patient.ShowPatientInfo();
        Console.WriteLine();

        // Задание №4 (вымышленные данные)
        Appointment appointment = new Appointment(
            patient,
            doctors[3],
            new DateTime(2026, 12, 5, 10, 30, 0));
        appointment.ShowAppointment();
    }
}
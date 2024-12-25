using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs
{
    public class Employee
    {
        private decimal salary;

        public string Surname { get; set; } //фио работника
        public string Name { get; set; }
        public String Patronymic { get; set; }
        public string Gender { get; set; } //пол
        public DateTime DateOfBirth { get; set; } //дата рождения
        public string Address { get; set; } //домашний адрес
        public string Specialty { get; set; } //специальность 
        public string Experience { get; set; }// опыт работы по специальности (в годах) (будет Int)
        public string Education { get; set; } //образование
        public string EducationDocument { get; set; } //данные документа о получении образования
        public string Salary 
        {
            get 
            { 
                return salary.ToString();
            }
            set
            {
                if (!(decimal.TryParse(value, out decimal salary))) throw new ArgumentException("Зарплата работника должна быть числом!");
                this.salary = salary;
            }
        } //зарплата (decimal)
        public string PhotoPath { get; set; } //фотография

        public Employee() { }

        public Employee(string surname, string name, string patronymic, string gender, DateTime dateOfBirth, string address,
                        string specialty, string experience, string education,
                        string educationDocument, string salary, string photoPath)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Address = address;
            Specialty = specialty;
            Experience = experience;
            Education = education;
            EducationDocument = educationDocument;
            Salary = salary;
            PhotoPath = photoPath;
        }
        public Employee(string surname)
        {
            Surname = surname;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class InfoEmployeesForm : Form
    {
        public InfoEmployeesForm(string surname, string name, string patronymic, string gender, DateTime dateOfBirth, string address, string specialty, string experience, string education, string educationDocument, string salary, string photoPath)
        {
            InitializeComponent();

            // Установка текста для элементов управления
            lblSurname.Text = surname;
            lblName.Text = name;
            lblPatronymic.Text = patronymic;
            lblGender.Text = gender;
            lblDateOfBirth.Text = dateOfBirth.ToShortDateString();
            lblAddress.Text = address;
            lblSpecialty.Text = specialty;
            lblExpirience.Text = experience;
            lblEducation.Text = education;
            lblEducationDocument.Text = educationDocument;
            lblSalary.Text = salary;
            LoadEmployeePhoto(photoPath); // Здесь можно добавить логику для отображения фото, если нужно
        }
        private void LoadEmployeePhoto(string photoPath)
        {
            if (File.Exists(photoPath))
            {
                try
                {
                    // Загружаем изображение в PictureBox
                    PhotoBox.Image = Image.FromFile(photoPath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл изображения не найден.");
            }
        }

    }
}

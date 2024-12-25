﻿using System;
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
    public partial class Form2 : Form
    {
        public event Action<Project> ProjectAdded;
        public Form2()
        {
            InitializeComponent();
        }
        private void OK_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстовых полей
                string employeeName = Lider_textBox.Text; 
                string clientName = clientName_textBox.Text; 
                string clientAddress = address_textBox.Text; 
                string clientBank = bankName_textBox.Text; 
                string clientAccountNumber = accountNumber_textBox.Text; 
                string clientINN = inn_textBox.Text; 
                string clientResponsiblePerson = responsiblePerson_textBox.Text; 
                string clientPhone = responsiblePersonPhone_textBox.Text; 
                // Создаем экземпляры Employee и Client
                Employee projectLeader = new Employee(employeeName);
                Client client = new Client(clientName, clientAddress, clientBank, clientAccountNumber, clientINN, clientResponsiblePerson, clientPhone);

                // Создаем экземпляр Project
                Project project = new Project(
                    projectName_textBox.Text,
                    projectCost_textBox.Text,
                    Start_Project.Value,
                    End_Project.Value,
                    projectLeader,
                    client,
                    premiumRate_textBox.Text
                );


                ProjectAdded?.Invoke(project); // Вызываем событие
                this.Close(); 
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
    }
}

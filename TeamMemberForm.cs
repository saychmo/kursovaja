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
    public partial class TeamMemberForm : Form
    {
        public TeamMemberForm()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string teamName = textBoxTeamName.Text;

            // Проверяем, что название не пустое
            if (string.IsNullOrWhiteSpace(teamName))
            {
                MessageBox.Show("Пожалуйста, введите название коллектива.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем список для хранения названий коллективов
            List<string> teamMembers = new List<string>();

            // Проходим по строкам DataGridView и собираем данные
            foreach (DataGridViewRow row in dataGridViewTeamMembers.Rows)
            {
                if (row.Cells["LastName"].Value != null)
                {
                    string lastName = row.Cells["LastName"].Value.ToString();
                    string startDate = row.Cells["StartDate"].Value?.ToString() ?? "Не указана";
                    string endDate = row.Cells["EndDate"].Value?.ToString() ?? "Не указана";

                    teamMembers.Add($"{lastName} (с {startDate} по {endDate})");
                }
            }

            // Здесь можно добавить код для сохранения данных в базу данных или файл, если это необходимо

            // Закрываем форму и передаем данные обратно в Form1
            Form1 mainForm = (Form1)Owner;
            mainForm.AddTeamName(teamName);
            mainForm.AddTeamMembers(teamName, teamMembers);

            this.Close();
        }
    }
}

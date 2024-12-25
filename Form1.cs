using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            projects = ProgramJSON.LoadProjects();
            UpdateProjectListView();
            LoadEmployees();
        }

        private List<Employee> employees = new List<Employee>();
        private List<Project> projects = new List<Project>();

        private void LoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    photoPath.ImageLocation = filePath; // устанавливаем путь к изображению
                }
            }
        }

        private void Surname_Enter(object sender, EventArgs e)
        {
            if (Surname_textBox.Text == "Фамилия")
            {
                Surname_textBox.Clear();
                Surname_textBox.ForeColor = Color.Black;
            }
        }

        private void Surname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Surname_textBox.Text) || Surname_textBox.Text == "Фамилия")
            {
                Surname_textBox.Text = "Фамилия";
                Surname_textBox.ForeColor = Color.Gray;
            }
        }

        private void Name_textBox_Enter(object sender, EventArgs e)
        {
            if (Name_textBox.Text == "Имя")
            {
                Name_textBox.Clear();
                Name_textBox.ForeColor = Color.Black;
            }
        }

        private void Name_textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name_textBox.Text) || Name_textBox.Text == "Имя")
            {
                Name_textBox.Text = "Имя";
                Name_textBox.ForeColor = Color.Gray;
            }
        }

        private void Address_textBox_Enter(object sender, EventArgs e)
        {
            if (Address_textBox.Text == "Г. ул. д. кв.")
            {
                Address_textBox.Clear();
                Address_textBox.ForeColor = Color.Black;
            }
        }

        private void Address_textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Address_textBox.Text) || Address_textBox.Text == "Г. ул. д. кв.")
            {
                Address_textBox.Text = "Г. ул. д. кв.";
                Address_textBox.ForeColor = Color.Gray;
            }
        }

        private void Patronymic_textBox_Enter(object sender, EventArgs e)
        {
            if (Patronymic_textBox.Text == "Отчество")
            {
                Patronymic_textBox.Clear();
                Patronymic_textBox.ForeColor = Color.Black;
            }
        }

        private void Patronymic_textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Patronymic_textBox.Text) || Patronymic_textBox.Text == "Отчество")
            {
                Patronymic_textBox.Text = "Отчество";
                Patronymic_textBox.ForeColor = Color.Gray;
            }
        }

        private void CreateProject_button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Передаем список проектов
            form2.ProjectAdded += Form2_ProjectAdded; // Подписываемся на событие
            form2.ShowDialog();
        }

        private void Form2_ProjectAdded(Project project)
        {
            projects.Add(project);
            ProgramJSON.SaveProjects(projects);
            UpdateProjectListView();

            DetailForm detailForm = new DetailForm(project);
            detailForm.ShowDialog();
        }

        private void UpdateProjectListView()
        {
            listViewProjects.Items.Clear();
            foreach (var project in projects)
            {
                ListViewItem item = new ListViewItem(project.ProjectName);
                item.SubItems.Add(project.StartDate.ToShortDateString());
                item.SubItems.Add(project.EndDate.ToShortDateString());
                listViewProjects.Items.Add(project.ProjectName);
            }
        }

        private void addEmpoeeys_button_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(
                Surname_textBox.Text,
                Name_textBox.Text,
                Patronymic_textBox.Text,
                Gender.Text,
                date_of_bith_Picker.Value,
                Address_textBox.Text,
                specialty_comboBox.Text,
                experience_comboBox.Text,
                education_textBox.Text,
                educationDocument_textBox.Text,
                salary_textBox.Text,
                photoPath.ImageLocation
            );
            listExployee_textBox.Text += $"{Surname_textBox.Text} {Name_textBox.Text} {Patronymic_textBox.Text}" + "\r\n";

            employees.Add(employee);
        }

        private void listExployee_textBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listExployee_textBox.GetLineFromCharIndex(listExployee_textBox.SelectionStart);
            if (index >= 0 && index < employees.Count)
            {
                Employee selectedEmployee = employees[index];

                // Создаем новую форму и передаем данные
                InfoEmployeesForm detailsForm = new InfoEmployeesForm(
                    selectedEmployee.Surname,
                    selectedEmployee.Name,
                    selectedEmployee.Patronymic,
                    selectedEmployee.Gender,
                    selectedEmployee.DateOfBirth,
                    selectedEmployee.Address,
                    selectedEmployee.Specialty,
                    selectedEmployee.Experience,
                    selectedEmployee.Education,
                    selectedEmployee.EducationDocument,
                    selectedEmployee.Salary,
                    selectedEmployee.PhotoPath
                );

                detailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Недостаточно данных для отображения информации о сотруднике.");
            }
        }
        private void SaveEmployees()
        {
            ProgramJSON.SaveEmployees(employees);
        }

        private void LoadEmployees()
        {
            employees = ProgramJSON.LoadEmployees();

            foreach (var employee in employees)
            {
                listExployee_textBox.Text += $"{employee.Surname} {employee.Name} {employee.Patronymic}\r\n";
            }
        }
        private void listViewProjects_DoubleClick(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count > 0)
            {
                string selectedProjectName = listViewProjects.SelectedItems[0].Text;
                Project selectedProject = projects.Find(p => p.ProjectName == selectedProjectName);

                if (selectedProject != null)
                {
                    DetailForm detailForm = new DetailForm(selectedProject);
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count > 0)
            {
                int selectedIndex = listViewProjects.SelectedItems[0].Index;
                projects.RemoveAt(selectedIndex);
                UpdateProjectListView();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите проект для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (employees.Count == 0)
            {
                MessageBox.Show("Список сотрудников пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, выбран ли сотрудник в TextBox (например, выделение текста)
            if (listExployee_textBox.SelectionLength > 0)
            {
                string selectedEmployee = listExployee_textBox.SelectedText.Trim();

                // Находим индекс выбранного сотрудника
                int indexToRemove = -1;
                for (int i = 0; i < employees.Count; i++)
                {
                    string fullName = $"{employees[i].Surname} {employees[i].Name} {employees[i].Patronymic}";
                    if (fullName.Equals(selectedEmployee, StringComparison.OrdinalIgnoreCase))
                    {
                        indexToRemove = i;
                        break;
                    }
                }

                if (indexToRemove != -1)
                {
                    employees.RemoveAt(indexToRemove); // Удаляем сотрудника из списка employees
                    listExployee_textBox.Text = string.Join(Environment.NewLine, employees.Select(e => $"{e.Surname} {e.Name} {e.Patronymic}"));
                }
                else
                {
                    MessageBox.Show("Выбранный сотрудник не найден в списке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            TeamMemberForm teamMemberForm = new TeamMemberForm();
            teamMemberForm.Owner = this; // Устанавливаем владельца формы
            teamMemberForm.ShowDialog();
        }

        private Dictionary<string, List<string>> teamsData = new Dictionary<string, List<string>>();

        public void AddTeamName(string teamName)
        {
            textBoxTeams.AppendText(teamName + Environment.NewLine);
        }

        public void AddTeamMembers(string teamName, List<string> teamMembers)
        {
            // Сохраняем участников в словаре
            if (teamsData.ContainsKey(teamName))
            {
                teamsData[teamName].AddRange(teamMembers);
            }
            else
            {
                teamsData[teamName] = new List<string>(teamMembers);
            }
        }
        private void textBoxTeams_MouseClick(object sender, MouseEventArgs e)
        {
            int index = textBoxTeams.GetLineFromCharIndex(textBoxTeams.SelectionStart);
            string[] lines = textBoxTeams.Lines;

            if (index >= 0 && index < lines.Length)
            {
                string selectedTeamName = lines[index];

                // Получаем участников для выбранного коллектива
                if (teamsData.TryGetValue(selectedTeamName, out List<string> teamMembers))
                {
                    // Открываем форму с информацией о коллективе
                    TeamInfoForm teamInfoForm = new TeamInfoForm(selectedTeamName, teamMembers);
                    teamInfoForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Участники не найдены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEmployees();
            ProgramJSON.SaveProjects(projects);
        }

    }
}
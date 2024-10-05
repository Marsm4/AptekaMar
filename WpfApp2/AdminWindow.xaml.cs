using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Pharmacy321
{
    public partial class AdminWindow : Window
    {
        private Database database;

        public AdminWindow()
        {
            InitializeComponent();
            database = new Database();

            LoadContractsGrid();
        }

        private void LoadContractsGrid()
        {
            DataTable contracts = database.GetContracts(); // Метод для получения договоров из БД
            ContractsDataGrid.ItemsSource = contracts.DefaultView;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string FName = FNameTextBox.Text;
            string Name = NameTextBox.Text;
            string Othestvo = OthestvoTextBox.Text;
            string Adres = AdresTextBox.Text;
            string Telefon = TelefonTextBox.Text;
            string Poshta = PoshtaTextBox.Text;
            string Doljnost = DoljnostTextBox.Text;
            string Shas_Rabot = Shas_RabotTextBox.Text;

            int telefon;
            if (!int.TryParse(TelefonTextBox.Text, out telefon))
            {
                MessageBox.Show("Введите корректный номер телефона.");
                return;
            }

            int shasRabot;
            if (!int.TryParse(Shas_RabotTextBox.Text, out shasRabot))
            {
                MessageBox.Show("Введите корректное количество часов работы.");
                return;
            }

            database.AddEmployee(FName, Name, Othestvo, Adres, telefon, Poshta, Doljnost, shasRabot);

            // Метод для добавления сотрудника в БД
            MessageBox.Show("Сотрудник добавлен успешно!");

            // Очистка полей после добавления
            FNameTextBox.Clear();
            NameTextBox.Clear();
            OthestvoTextBox.Clear();
            AdresTextBox.Clear();
            TelefonTextBox.Clear();
            PoshtaTextBox.Clear();
            DoljnostTextBox.Clear();
            Shas_RabotTextBox.Clear();
        }


        private void CreateContractButton_Click(object sender, RoutedEventArgs e)
        {
            string Nomer_Dogovota = Nomer_DogovotaTextBox.Text;

            if (string.IsNullOrWhiteSpace(Nomer_Dogovota))
            {
                MessageBox.Show("Пожалуйста, введите номер договора.");
                return;
            }

            if (int.TryParse(Nomer_Dogovota, out int nomerDogovora))
            {
                try
                {
                    database.CreateContract(nomerDogovora); // Создание договора в БД
                    MessageBox.Show("Договор создан успешно!");

                    // Очистка полей после добавления
                    Nomer_DogovotaTextBox.Clear();

                    LoadContractsGrid(); // Обновление списка договоров
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Номер договора должен быть числом.");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика выхода из окна администратора
            MainWindow mainWindow = new MainWindow(); // Переход на окно авторизации
            mainWindow.Show();
            this.Close(); // Закрытие текущего окна
        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using Microsoft.IdentityModel.Protocols;
using System.Runtime.Remoting.Contexts;
using WpfApp2;

//namespace Pharmacy321
//{
//    public class Database
//    {
//        private string connectionString;



//        public Database()
//        {
//            connectionString = ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString;
//        }

//        public DataTable GetClients()
//        {
//            DataTable clientsTable = new DataTable();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = "SELECT ID_Klient, FName, Name, Othestvo, Pochta, Telefon, Skidka FROM Klient"; // Убедитесь, что вы выбираете все необходимые поля
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    SqlDataAdapter adapter = new SqlDataAdapter(command);
//                    adapter.Fill(clientsTable);
//                }
//            }

//            return clientsTable;
//        }
//        public DataTable GetSpecialists()
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "SELECT ID_Sotudnica, FName + ' - ' + Doljnost AS FullNameAndPosition FROM Sotrudnic";
//                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
//                DataTable dataTable = new DataTable();
//                adapter.Fill(dataTable);
//                return dataTable;
//            }
//        }
//        public void AddClient(string FName, string Name, string Othestvo, string Pochta, string Telefon, string Skidka)
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "INSERT INTO Klient (FName, Name,  Othestvo, Pochta, Telefon, Skidka) VALUES (@FName, @Name, @Othestvo, @Pochta, @Telefon, @Skidka)";
//                SqlCommand command = new SqlCommand(query, conn);
//                command.Parameters.AddWithValue("@FName", FName);
//                command.Parameters.AddWithValue("@Name", Name);
//                command.Parameters.AddWithValue("@Othestvo", Othestvo);
//                command.Parameters.AddWithValue("@Pochta", Pochta);
//                command.Parameters.AddWithValue("@Telefon", Telefon);
//                command.Parameters.AddWithValue("@Skidka", Skidka);
//                command.ExecuteNonQuery();
//            }
//        }
//        public void RecordAppointment(int clientId, int specialistId, int contractId)
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                string query = "INSERT INTO Zapis (ID_klienta, ID_Spec_Sotrudnic, ID_Dogovora) VALUES (@ClientId, @SpecialistId, @ContractId)";
//                SqlCommand command = new SqlCommand(query, conn);
//                command.Parameters.AddWithValue("@ClientId", clientId);
//                command.Parameters.AddWithValue("@SpecialistId", specialistId);
//                command.Parameters.AddWithValue("@ContractId", contractId);
//                command.ExecuteNonQuery();
//            }
//        }


//        private int GetClientIdByName(string clientName)
//        {
//            // Метод для получения ID клиента по имени
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = "SELECT ID_Klient FROM Klient WHERE LOWER(FName + ' ' + Name) = @ClientName";
//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@ClientName", clientName);
//                    return (int)command.ExecuteScalar(); // Возвращает первый найденный ID_Klient
//                }
//            }
//        }
//        public DataTable GetEmployees()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("SELECT * FROM Sotrudnic", connection);
//                SqlDataAdapter adapter = new SqlDataAdapter(command);
//                DataTable employees = new DataTable();
//                adapter.Fill(employees);
//                return employees;
//            }
//        }

//        public DataTable GetContracts()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("SELECT ID_Dogovora, Nomer_Dogovota FROM Dogovor", connection);
//                SqlDataAdapter adapter = new SqlDataAdapter(command);
//                DataTable contracts = new DataTable();
//                adapter.Fill(contracts);
//                return contracts;
//            }
//        }


//        public void AddEmployee(string fName, string name, string othestvo, string adres, string telefon, string poshta, string doljnost, string shas_rabot)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("INSERT INTO Sotrudnic (FName, Name, Othestvo, Adres, Telefon, Poshta, Doljnost, Shas_Rabot) VALUES (@FName, @Name, @Othestvo, @Adres, @Telefon, @Poshta, @Doljnost, @Shas_Rabot)", connection);
//                command.Parameters.AddWithValue("@FName", fName);
//                command.Parameters.AddWithValue("@Name", name);
//                command.Parameters.AddWithValue("@Othestvo", othestvo);
//                command.Parameters.AddWithValue("@Adres", adres);
//                command.Parameters.AddWithValue("@Telefon", telefon);
//                command.Parameters.AddWithValue("@Poshta", poshta);
//                command.Parameters.AddWithValue("@Doljnost", doljnost);
//                command.Parameters.AddWithValue("@Shas_Rabot", shas_rabot);

//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }


//        public void CreateContract(string Nomer_Dogovota)
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    string query = "INSERT INTO Dogovor (Nomer_Dogovota) VALUES (@Nomer_Dogovota)";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Nomer_Dogovota", Nomer_Dogovota);
//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Ошибка при добавлении договора: {ex.Message}");
//            }
//        }


//    }
//}


namespace Pharmacy321
{
    public class Database
    {
        private фзеулфEntities context;

        public Database()
        {
            // Инициализируем контекст
            context = new фзеулфEntities();
        }

        // Получение клиентов
        public DataTable GetClients()
        {
            DataTable clientsTable = new DataTable();

            // Заголовки столбцов
            clientsTable.Columns.Add("ID_Klient", typeof(int));
            clientsTable.Columns.Add("FName", typeof(string));
            clientsTable.Columns.Add("Name", typeof(string));
            clientsTable.Columns.Add("Othestvo", typeof(string));
            clientsTable.Columns.Add("Pochta", typeof(string));
            clientsTable.Columns.Add("Telefon", typeof(string));
            clientsTable.Columns.Add("Skidka", typeof(string));

            // Получаем данные клиентов из базы
            var clients = context.Klient.ToList();
            foreach (var client in clients)
            {
                clientsTable.Rows.Add(client.ID_Klient, client.FName, client.Name, client.Othestvo, client.Pochta, client.Telefon, client.Skidka);
            }

            return clientsTable;
        }

        // Получение специалистов
        public DataTable GetSpecialists()
        {
            DataTable specialistsTable = new DataTable();
            specialistsTable.Columns.Add("ID_Sotudnica", typeof(int));
            specialistsTable.Columns.Add("FullNameAndPosition", typeof(string));

            var specialists = context.Sotrudnic.ToList();
            foreach (var specialist in specialists)
            {
                string fullNameAndPosition = $"{specialist.FName} - {specialist.Doljnost}";
                specialistsTable.Rows.Add(specialist.ID_Sotudnica, fullNameAndPosition);
            }

            return specialistsTable;
        }

        // Добавление клиента
        public void AddClient(string FName, string Name, string Othestvo, string Pochta, string Telefon, int Skidka)
        {
            try
            {
                Klient newClient = new Klient
                {
                    FName = FName,
                    Name = Name,
                    Othestvo = Othestvo,
                    Pochta = Pochta,
                    Telefon = Telefon,
                    Skidka = Skidka
                };

                context.Klient.Add(newClient);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}");
            }
        }

        // Запись на прием
        //public void RecordAppointment(int clientId, int specialistId)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("INSERT INTO Appointments (ClientId, SpecialistId) VALUES (@ClientId, @SpecialistId)", connection))
        //        {
        //            command.Parameters.AddWithValue("@ClientId", clientId);
        //            command.Parameters.AddWithValue("@SpecialistId", specialistId);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}



        // Получение сотрудников
        public DataTable GetEmployees()
        {
            DataTable employeesTable = new DataTable();
            employeesTable.Columns.Add("ID_Sotrudnic", typeof(int));
            employeesTable.Columns.Add("FName", typeof(string));
            employeesTable.Columns.Add("Name", typeof(string));
            employeesTable.Columns.Add("Doljnost", typeof(string));

            var employees = context.Sotrudnic.ToList();
            foreach (var employee in employees)
            {
                employeesTable.Rows.Add(employee.ID_Sotudnica, employee.FName, employee.Name, employee.Doljnost);
            }

            return employeesTable;
        }

        // Получение договоров
        public DataTable GetContracts()
        {
            DataTable contractsTable = new DataTable();
            contractsTable.Columns.Add("ID_Dogovora", typeof(int));
            contractsTable.Columns.Add("Nomer_Dogovota", typeof(string));

            var contracts = context.Dogovor.ToList();
            foreach (var contract in contracts)
            {
                contractsTable.Rows.Add(contract.ID_Dogovora, contract.Nomer_Dogovota);
            }

            return contractsTable;
        }

        // Добавление сотрудника
        public void AddEmployee(string fName, string name, string othestvo, string adres, int telefon, string poshta, string doljnost, int shas_rabot)
        {
            try
            {
                Sotrudnic newEmployee = new Sotrudnic
                {
                    FName = fName,
                    Name = name,
                    Othestvo = othestvo,
                    Adres = adres,
                    Telefon = telefon,
                    Poshta = poshta,
                    Doljnost = doljnost,
                    Shas_Rabot = shas_rabot
                };

                context.Sotrudnic.Add(newEmployee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }
        }

        // Создание договора
        public void CreateContract(int nomerDogovora)
        {
            try
            {
                var contract = new Dogovor
                {
                    Nomer_Dogovota = nomerDogovora,
                    // Добавьте здесь все необходимые поля, которые должны быть заполнены
                };
                context.Dogovor.Add(contract);
                context.SaveChanges();
            }        
              catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании договора: {ex.Message}\n{ex.StackTrace}");
            }

        }
    



        public void RecordAppointment(int clientId, int specialistId)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand("INSERT INTO Appointments (ClientId, SpecialistId) VALUES (@ClientId, @SpecialistId)", connection))
            //    {
            //        command.Parameters.AddWithValue("@ClientId", clientId);
            //        command.Parameters.AddWithValue("@SpecialistId", specialistId);
            //        command.ExecuteNonQuery();
            //    }
            //}
        }
    }
}

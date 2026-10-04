using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Uzenetkuldo_jb.Models;
using Uzenetkuldo_jb.Models;

namespace Uzenetkuldo_jb.Services
{
    public class UzenetServices
    {
        private readonly string connectionString = "Server=localhost;Database=uzenetkuldo_jb;Uid=root;Pwd=;";

        // 1. READ
        public List<Uzenet> GetAllUzenetek()
        {
            List<Uzenet> lista = new List<Uzenet>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email FROM uzenet";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Uzenet u = new Uzenet()
                            {
                                Id = reader.GetInt32("Id"),
                                Szoveg = reader.GetString("Szoveg"),
                                KüldesiIdo = reader.GetDateTime("KüldesiIdo"),
                                UzenetTipus = reader.GetString("UzenetTipus"),
                                Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) ? null : reader.GetString("Telefon"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email")
                            };
                            lista.Add(u);
                        }
                    }
                }
            }
            return lista;
        }

        // 2. CREATE
        public void AddUzenet(Uzenet uzenet)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO uzenet (Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email) VALUES (@szoveg, @kuldesido, @tipus, @telefon, @email)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@szoveg", uzenet.Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesido", uzenet.KüldesiIdo);
                    cmd.Parameters.AddWithValue("@tipus", uzenet.UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (object)uzenet.Telefon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)uzenet.Email ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. UPDATE
        public void UpdateUzenet(Uzenet uzenet)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE uzenet SET Szoveg = @szoveg, KüldesiIdo = @kuldesido, UzenetTipus = @tipus, Telefon = @telefon, Email = @email WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", uzenet.Id);
                    cmd.Parameters.AddWithValue("@szoveg", uzenet.Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesido", uzenet.KüldesiIdo);
                    cmd.Parameters.AddWithValue("@tipus", uzenet.UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (object)uzenet.Telefon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)uzenet.Email ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. DELETE
        public void DeleteUzenet(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM uzenet WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
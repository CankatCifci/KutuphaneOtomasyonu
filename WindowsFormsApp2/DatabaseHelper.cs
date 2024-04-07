using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace WindowsFormsApp2
{
    public static class DatabaseHelper
    {
        public static string databasePath = @"C:\Users\msi\source\repos\WindowsFormsApp2\WindowsFormsApp2\Files\kutuphane.db";

        public static void InitializeDatabase()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);

                string createKitapTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Kitap (
                        KitapId INTEGER PRIMARY KEY AUTOINCREMENT,
                        KitapAdi TEXT NOT NULL,
                        Yazar TEXT NOT NULL
                    );";

                string createUyeTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Uye (
                        UyeId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Ad TEXT NOT NULL,
                        Soyad TEXT NOT NULL
                    );";

                using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createKitapTablesQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createUyeTablesQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

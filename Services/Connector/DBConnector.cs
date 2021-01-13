using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


//Im NuGet-Manager MySQL.Data installieren

namespace DBConnector
{
    class Connector
    {
        /// <summary>
        /// Schreibt in die als Argument mitgegebene Tabelle die mitgegebenen Argumente. Commit wird automatisch ausgeführt
        /// </summary>
        /// <param name="tabelle">Der Name der Tabelle als String</param>
        /// <param name="args">Die Folge der zu schreibenden Argumente als String mit Komma getrennt</param>
        public static void dbWrite(string tabelle, params string[] args)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql06.manitu.net;port=3306;username=u59561;password=B5QfgAWbGZSAtTRK");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string values = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (i == args.Length - 1)
                {
                    values += "'" + args[i] + "'";
                }
                else
                {
                    values += "'" + args[i] + "', ";
                }
            }
            command.CommandText = "Insert into " + tabelle + " VALUES (" + values + ");";
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            Reader.Close();
            command.CommandText = "commit;";
            connection.Close();
        }

        /// <summary>
        /// Gibt alle Zeilen der Tabelle zurück. Als Argument kann eine Spalte gewählt werden oder alle.
        /// </summary>
        /// <param name="tabelle">Name der Tabelle als String</param>
        /// <param name="spalte">Name der Spalte als String. Benutze "*" für alle Spalten der Tabelle</param>
        public static List<string[]> dbRead(string tabelle, string spalte = "*")
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql06.manitu.net;port=3306;username=u59561;password=B5QfgAWbGZSAtTRK");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select {spalte} from db59561.{tabelle}";
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            List<string[]> readReturn = new List<string[]>();
            while (Reader.Read())
            {
                string[] readTmp = new string[Reader.FieldCount];
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    readTmp[i] = Reader.GetString(i);
                }
                readReturn.Add(readTmp);
            }
            Reader.Close();
            connection.Close();
            return readReturn;
        }

        /// <summary>
        /// Hans Peter
        /// </summary>
        /// <param name="condition">Abfragekondition als String nach dem "where"-Stichwort -- Beispiel: "Name = Mustermann"</param>
        /// <param name="tabelle">Der Tabellenname als String aus der ausgewählt wird</param>
        /// <param name="spalte">Die Spalten, die zurückgegeben werden sollen</param>
        public static List<string[]> dbRead(string tabelle, string[] spalte, string condition)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql06.manitu.net;port=3306;username=u59561;password=B5QfgAWbGZSAtTRK");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select {String.Join(", ", spalte)} from db59561.{tabelle} where {condition}";
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            List<string[]> readReturn = new List<string[]>();
            while (Reader.Read())
            {
                string[] readTmp = new string[Reader.FieldCount];
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    readTmp[i] = Reader.GetString(i);
                }
                readReturn.Add(readTmp);
            }
            Reader.Close();
            connection.Close();
            return readReturn;
        }

        /// <summary>
        /// Gibt die Bezeichung der Spalten der Tabelle zurück
        /// </summary>
        /// <param name="tabelle">Der Name der Tabelle als String</param>
        public static List<string[]> dbRowNames(string tabelle)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql06.manitu.net;port=3306;username=u59561;password=B5QfgAWbGZSAtTRK");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='{tabelle}'";
            MySqlDataReader Reader = command.ExecuteReader();
            List<string[]> readReturn = new List<string[]>();
            while (Reader.Read())
            {
                string[] readTmp = new string[Reader.FieldCount];
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    readTmp[i] = Reader.GetString(i);
                }
                readReturn.Add(readTmp);
            }
            Reader.Close();
            connection.Close();
            return readReturn;
        }


        public static void dBCMD(string arg)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql06.manitu.net;port=3306;username=u59561;password=B5QfgAWbGZSAtTRK");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = arg;
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            Reader.Close();
            command.CommandText = "commit;";
            connection.Close();
        }
    }
}

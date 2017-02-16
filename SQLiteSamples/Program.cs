// Author: Tigran Gasparian
// This sample is part Part One of the 'Getting Started with SQLite in C#' tutorial at http://www.blog.tigrangasparian.com/

using System;
using System.Data.SQLite;
using CsvReadWrite;
namespace SQLiteSamples
{
    class Program
    {
        // Holds our connection with the database
        SQLiteConnection m_dbConnection;

        static void Main(string[] args)
        {

            
            //CsvRead();
            getColumnNames("C:\\Users\\stanimir\\Downloads\\ProblemList.csv");

            Program p = new Program();
        }


        public static void CsvRead()
        {
            CsvReadWrite.CsvFileReader reader = new CsvFileReader("C:\\Users\\stanimir\\Downloads\\ProblemList.csv");
            CsvRow row = new CsvRow();
            while (reader.ReadRow(row))
            {
                foreach (string s in row)
                {
                    Console.Write(s);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static String[] getColumnNames(String csvFile)
        {
            
            CsvReadWrite.CsvFileReader reader = new CsvFileReader(csvFile);
            CsvRow row = new CsvRow();
            reader.ReadRow(row);
            int i = row.Count - 1;
            String[] columnNames = new String[i];
            
                int j = 0;
                foreach (string s in row)
                {
                    columnNames[j++] = s;
                }

            return columnNames;
        }

        public Program()
        {
            //("C:\Users\stanimir\Downloads\ProblemList.csv");
            String databaseName = "MyDatabase";
            String tableName = "demotable";
            createNewDatabase(databaseName);
            connectToDatabase(databaseName);
            //createTable(tableName);
            fillTable(tableName);
            printTable(tableName);
        }

        // Creates an empty database file
        void createNewDatabase(String databaseName)
        {
            SQLiteConnection.CreateFile(databaseName + ".sqlite");
        }

        // Creates a connection with our database file.
        void connectToDatabase(String databaseName)
        {
            //m_dbConnection = new SQLiteConnection("Data Source=" + databaseName + ".sqlite;Version=3;");
            m_dbConnection = new SQLiteConnection("Data Source=" + databaseName + ".sqlite;");
            m_dbConnection.Open();
        }

        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        void createTable(String tableName, String[] )
        {
            string sql = "create table " + tableName + " (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
       

        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        void fillTable(String tableName)
        {
            string sql = "insert into " + tableName + " (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into  " + tableName + "  (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into  " + tableName + "  (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        void fillTable(String fileName, String tableName)
        {
            string sql = "insert into " + tableName + " (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into  " + tableName + "  (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into  " + tableName + "  (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Writes the highscores to the console sorted on score in descending order.
        void printTable(String tableName)
        {
            string sql = "select * from  " + tableName + "  order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }


    }
}

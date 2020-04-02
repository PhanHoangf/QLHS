﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.DAO
{
    public class DataProvider
    {
        private string connectStr = @"Data Source=DESKTOP-A1VAJLI;Initial Catalog = QLHS; Integrated Security = True";

        private static DataProvider instance;

        public static DataProvider Instance {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private DataProvider() { }
        public DataTable ExecuteQuery(string query,object[] parameter =null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query,connection);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
           
            }



                return data;
        }
    }
}
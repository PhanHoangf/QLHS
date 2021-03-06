﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class StudentDAO
    {
        private static StudentDAO instance;

        public static StudentDAO Instance
        {
            get { if (instance == null) instance = new StudentDAO(); return instance; }
            private set { StudentDAO.instance = value; }
        }
        private StudentDAO() { }

        public List<Student> LoadHs(string query)
        {
            List<Student> Studentlist = new List<Student>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Student student = new Student(item);
                Studentlist.Add(student);
            }
            return Studentlist;
        }
        public bool InsertHocsinh(int idlop,string hoten, string gioitinh,DateTime ngaysinh,string diachi,string email)
        {
            string query = "INSERT INTO DSHocSinh (iDlop, Hoten, Gioitinh, Ngaysinh, Diachi, Email) VALUES ( @iDlop , @Hoten , @Gioitinh , @Ngaysinh , @Diachi , @Email );";
            int result = DataProvider.Instance.ExecuteNonQuery(query,new object[] {idlop,hoten,gioitinh,ngaysinh,diachi,email});
            return result > 0;
        }
        public bool DeleteHocsinh(int idhocsinh)
        {
            int result= DataProvider.Instance.ExecuteNonQuery("delete DSHocSinh where iDhocsinh = " + idhocsinh);
            return result > 0;
        }
        public bool UpdateHocsinh(int iDhocsinh, string hoten, string gioitinh, DateTime ngaysinh, string diachi, string email)
        {
            string query = "UPDATE DSHocSinh SET Hoten = @Hoten , Gioitinh = @Gioitinh , Ngaysinh = @Ngaysinh , Diachi = @Diachi , Email = @Email where iDhocsinh= @iDhocsinh ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoten, gioitinh, ngaysinh, diachi, email, iDhocsinh });
            return result > 0;
        }

        public DataTable FindHocSinhByName(string ten)
        {
            string query = "EXEC USP_TimKiemHsByTen N'"+ten+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
    }
}

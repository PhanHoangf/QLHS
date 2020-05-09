﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class fTongKetMon : Form
    {
        public fTongKetMon()
        {
            InitializeComponent();
            LoadTongKetMon();
            xuiCustomGroupbox1.Enabled = false;
            LoadDanhSachLop();
            LoadDanhSachMonHoc();
            lblSoDat.Visible = false;
        }

        public void LoadTongKetMon()
        {
            dtgvTongKetMon.DataSource = TongKetMonDAO.Instance.loadTongKetMon();
        }

        public void loadTongKetMonByID(int idlop,int idmonhoc)
        {
            dtgvTongKetMon.DataSource = TongKetMonDAO.Instance.loadTongKetMonbyID(idlop,idmonhoc);
        }

        public void LoadDanhSachLop()
        {
            string query = "SELECT *FROM Lop";
            List<Classes> classesList = ClassDAO.Instance.LoadClassList(query);
            foreach (Classes item in classesList)
            {
                cbDanhSachLop.Items.Add(item.TenLop);
            }
        }

        public void LoadDanhSachMonHoc()
        {
            string query = "SELECT *FROM MonHoc";
            List<Subjects> subjectList = SubjectDAO.Instance.loadSubjects(query);
            foreach (Subjects item in subjectList)
            {
                cbDanhSachMon.Items.Add(item.TenMon);
            }
        }

        public int findIdLop(string a)
        {
            string query = "SELECT *FROM Lop";
            List<Classes> classesList = ClassDAO.Instance.LoadClassList(query);
            foreach (Classes item in classesList)
            {
                if (item.TenLop == a)
                {
                    return item.ID;
                }
            }
            return -1;
        }

        public int findIdMonHoc(string a)
        {
            string query = "SELECT *FROM MonHoc";
            List<Subjects> subjectList = SubjectDAO.Instance.loadSubjects(query);
            foreach (Subjects item in subjectList)
            {
                if (item.TenMon == a) { return item.ID; }
            }
            return -1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            loadTongKetMonByID(findIdLop(cbDanhSachLop.Text),findIdMonHoc(cbDanhSachMon.Text));
            int a = dtgvTongKetMon.RowCount -1;
            lblSoDat.Text = a.ToString();
            lblSoDat.Visible = true;
        }
    }
}

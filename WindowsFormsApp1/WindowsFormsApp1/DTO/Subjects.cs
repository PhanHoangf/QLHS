﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class Subjects
    {
        private string tenMon;
        private int iD;
        private float diemDat;
        public Subjects(int id,string tenmon, float diemdat)
        {
            this.ID = id;
            this.TenMon = tenMon;
            this.DiemDat = diemdat;
        }
        public Subjects(DataRow row)
        {
            this.ID = (int)row["iDmonhoc"];
            this.TenMon = row["Tenmon"].ToString();
            this.DiemDat = (float)row["DiemDat"];
        }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int ID { get => iD; set => iD = value; }
        public float DiemDat { get => diemDat; set => diemDat = value; }
    }
}

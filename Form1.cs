using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using System.Configuration;

namespace QLKSan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
        }
        SqlConnection con;
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIdRoom.Text = "";
            txtNameRoom.Text = "";
            txtPrice.Text = "";
            txtNameUser.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QLKS"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            Display();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        public void Display()
        {
            string sqlSELECT = "SELECT id,MaPhong,TenPhong,Gia FROM KSan ORDER BY id ASC ";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            tblRoom.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string SqlINSERT = "INSERT INTO KSan VALUES (@MaPhong, @TenPhong,@Gia,@TenNguoiDat,@LoaiPhong,@TinhTrang)";
            SqlCommand cmd = new SqlCommand(SqlINSERT,con);
            cmd.Parameters.AddWithValue("MaPhong", txtIdRoom.Text);
            cmd.Parameters.AddWithValue("TenPhong", txtNameRoom.Text);
            cmd.Parameters.AddWithValue("Gia", txtPrice.Text);
            cmd.Parameters.AddWithValue("TenNguoiDat", txtNameUser.Text);
            cmd.Parameters.AddWithValue("LoaiPhong", cbxLoaiPhong.Text);
            cmd.Parameters.AddWithValue("TinhTrang", cbxTinhTrang.Text);
            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string SqlUpdate = "UPDATE KSan SET TenPhong = @TenPhong , Gia = @Gia, TenNguoiDat = @TenNguoiDat,LoaiPhong = @LoaiPhong,TinhTrang = @TinhTrang WHERE MaPhong = @MaPhong ";
            SqlCommand cmd = new SqlCommand(SqlUpdate, con);
            cmd.Parameters.AddWithValue("MaPhong", txtIdRoom.Text);
            cmd.Parameters.AddWithValue("TenPhong", txtNameRoom.Text);
            cmd.Parameters.AddWithValue("Gia", txtPrice.Text);
            cmd.Parameters.AddWithValue("TenNguoiDat", txtNameUser.Text);
            cmd.Parameters.AddWithValue("LoaiPhong", cbxLoaiPhong.Text);
            cmd.Parameters.AddWithValue("TinhTrang", cbxTinhTrang.Text);
            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string SqlDelete = "DELETE FROM KSan WHERE MaPhong = @MaPhong";
            SqlCommand cmd = new SqlCommand(SqlDelete, con);
            cmd.Parameters.AddWithValue("MaPhong", txtIdRoom.Text);
            cmd.Parameters.AddWithValue("TenPhong", txtNameRoom.Text);
            cmd.Parameters.AddWithValue("Gia", txtPrice.Text);
            cmd.Parameters.AddWithValue("TenNguoiDat", txtNameUser.Text);
            cmd.Parameters.AddWithValue("LoaiPhong", cbxLoaiPhong.Text);
            cmd.Parameters.AddWithValue("TinhTrang", cbxTinhTrang.Text);
            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SqlSearch = "SELECT * FROM KSan WHERE MaPhong = @MaPhong";
            SqlCommand cmd = new SqlCommand(SqlSearch, con);
            cmd.Parameters.AddWithValue("MaPhong", txtIdRoom.Text);
            cmd.Parameters.AddWithValue("TenPhong", txtNameRoom.Text);
            cmd.Parameters.AddWithValue("Gia", txtPrice.Text);
            cmd.Parameters.AddWithValue("TenNguoiDat", txtNameUser.Text);
            cmd.Parameters.AddWithValue("LoaiPhong", cbxLoaiPhong.Text);
            cmd.Parameters.AddWithValue("TinhTrang", cbxTinhTrang.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            tblRoom.DataSource = dt;
        }
    }
}

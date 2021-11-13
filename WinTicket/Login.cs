using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Model;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                lblLoginUyari.Text = "Kullanıcı adı ve şifrenizi giriniz!";
            }
            else
            {
                var _loggedUser = Login(txtKullaniciAdi.Text, Util.Security.Encrypt(txtSifre.Text));
                if (_loggedUser != null)
                {
                    // Set globals
                    Global.Username = _loggedUser.Username;
                    Global.UserRole = _loggedUser.UserRole;

                    // Başarılı ise Dashboard formunu aç
                    var frmDashboard = new Dashboard();
                    frmDashboard.Location = this.Location;
                    frmDashboard.StartPosition = FormStartPosition.Manual;
                    frmDashboard.FormClosing += delegate { this.Show(); };
                    frmDashboard.Show();
                    this.Hide();
                }
                else
                {
                    lblLoginUyari.Text = "Hatalı kullanıcı adı ya da şifre!";
                }
            }
        }

        /// <summary>
        /// Login kontrolü
        /// </summary>
        /// <param name="kullaniciAdi"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        private User Login(string kullaniciAdi, string sifre)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();
            KullaniciTableAdapter kullaniciTableAdapter = new KullaniciTableAdapter();
            kullaniciTableAdapter.Fill(dataSet.Kullanici);

            var kullanici = dataSet.Kullanici.FirstOrDefault(k => k.KullaniciAdi.Equals(kullaniciAdi) && k.Sifre.Equals(sifre));

            if (kullanici != null)
            {
                return new User
                {
                    Username = kullanici.KullaniciAdi,
                    UserRole = (UserRole)kullanici.RoleId
                };
            }

            return null;
        }

        private void btnGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmDashboard = new Dashboard();
            frmDashboard.Location = this.Location;
            frmDashboard.StartPosition = FormStartPosition.Manual;
            frmDashboard.FormClosing += delegate { this.Show(); };
            frmDashboard.Show();
            this.Hide();
        }
    }
}

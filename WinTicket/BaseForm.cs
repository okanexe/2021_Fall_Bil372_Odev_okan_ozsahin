using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Util;

namespace WinTicket
{
    public class BaseForm : Form
    {
        public string _connectionString;
        public Operation _operation;
        public BaseForm()
        {
            this._connectionString = Properties.Settings.Default.WinTicketConnectionString;
            this._operation = new Operation();
        }

        #region Common
        /// <summary>
        /// Problems
        /// </summary>
        /// <returns></returns>
        protected DataTable GetProblem()
        {
            string sqlCommand = "SELECT Id, HedeflenenAmacTanimi FROM Problem";
            var problemDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Problem");

            DataRow row = problemDataSet.Tables[0].NewRow();
            row["HedeflenenAmacTanimi"] = "Seçiniz";
            problemDataSet.Tables[0].Rows.InsertAt(row, 0);

            return problemDataSet.Tables[0];
        }
        /// <summary>
        /// Birim DS
        /// </summary>
        /// <returns></returns>
        protected DataTable GetUstBirim()
        {
            string sqlCommand = "SELECT Id, BirimAdi FROM Birim";
            var birimDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Birim");

            DataRow row = birimDataSet.Tables[0].NewRow();
            row["BirimAdi"] = "Seçiniz";
            row["Id"] = 0;
            birimDataSet.Tables[0].Rows.InsertAt(row, 0);

            return birimDataSet.Tables[0];
        }

        /// <summary>
        /// Birim Müdür DS
        /// </summary>
        /// <returns></returns>
        protected DataTable GetBirimMuduru()
        {
            string sqlCommand = "SELECT Id, CONCAT(Ad, ' ', Soyad) AS AdSoyad FROM Personel";
            var personelDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Personel");

            DataRow row = personelDataSet.Tables[0].NewRow();
            row["AdSoyad"] = "Seçiniz";
            personelDataSet.Tables[0].Rows.InsertAt(row, 0);

            return personelDataSet.Tables[0];
        }

        /// <summary>
        /// İlçe DS
        /// </summary>
        /// <returns></returns>
        protected DataTable GetIlce(int ilId)
        {
            string sqlCommand = "SELECT Id, IlceAdi FROM Ilce WHERE IlId = " + ilId;
            var ilceDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Ilce");

            DataRow row = ilceDataSet.Tables[0].NewRow();
            row["IlceAdi"] = "Seçiniz";
            ilceDataSet.Tables[0].Rows.InsertAt(row, 0);

            return ilceDataSet.Tables[0];
        }

        /// <summary>
        /// Birim Müdür DS
        /// </summary>
        /// <returns></returns>
        protected DataTable GetUstPersonel()
        {
            string sqlCommand = "SELECT Id, CONCAT(Ad, ' ', Soyad) AS AdSoyad FROM Personel";
            var personelDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Personel");

            DataRow row = personelDataSet.Tables[0].NewRow();
            row["AdSoyad"] = "Seçiniz";
            row["Id"] = 0;
            personelDataSet.Tables[0].Rows.InsertAt(row, 0);

            return personelDataSet.Tables[0];
        }
        /// <summary>
        /// Birim
        /// </summary>
        /// <returns></returns>
        protected DataTable GetBirim()
        {
            string sqlCommand = "SELECT Id, BirimAdi FROM Birim";
            var birimDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Birim");

            DataRow row = birimDataSet.Tables[0].NewRow();
            row["BirimAdi"] = "Seçiniz";
            birimDataSet.Tables[0].Rows.InsertAt(row, 0);

            return birimDataSet.Tables[0];
        }
        /// <summary>
        /// Çıktı
        /// </summary>
        /// <returns></returns>
        protected DataTable GetCikti()
        {
            string sqlCommand = "SELECT Id, CiktiAdi FROM Cikti";
            var ciktiDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Cikti");

            DataRow row = ciktiDataSet.Tables[0].NewRow();
            row["CiktiAdi"] = "Seçiniz";
            ciktiDataSet.Tables[0].Rows.InsertAt(row, 0);

            return ciktiDataSet.Tables[0];
        }
        /// <summary>
        /// Kullanıcı
        /// </summary>
        /// <returns></returns>
        protected DataTable GetKullanici()
        {
            string sqlCommand = "SELECT Id, KullaniciAdi FROM Kullanici";
            var kullaniciDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Kullanici");

            DataRow row = kullaniciDataSet.Tables[0].NewRow();
            row["KullaniciAdi"] = "Seçiniz";
            kullaniciDataSet.Tables[0].Rows.InsertAt(row, 0);

            return kullaniciDataSet.Tables[0];
        }
        #endregion
    }
}

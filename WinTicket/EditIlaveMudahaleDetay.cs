using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Model;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditIlaveMudahaleDetay : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ilaveMudahaleDetayId;

        public EditIlaveMudahaleDetay(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ilaveMudahaleDetayId = id;
        }

        private void EditIlaveMudahaleDetay_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
            alanTableAdapter.Fill(dataSet.Alan);

            SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
            sinifTableAdapter.Fill(dataSet.Sinif);

            MudahaleTableAdapter mudahaleTableAdapter = new MudahaleTableAdapter();
            mudahaleTableAdapter.Fill(dataSet.Mudahale);

            ProblemTableAdapter problemTableAdapter = new ProblemTableAdapter();
            problemTableAdapter.Fill(dataSet.Problem);

            AktiviteTableAdapter aktiviteTableAdapter = new AktiviteTableAdapter();
            aktiviteTableAdapter.Fill(dataSet.Aktivite);

            DataRow alanDataRow = dataSet.Alan.NewRow();
            alanDataRow["AlanAdi"] = "Seçiniz";
            alanDataRow["TipId"] = 0;
            dataSet.Alan.Rows.InsertAt(alanDataRow, 0);

            DataRow sinifDataRow = dataSet.Sinif.NewRow();
            sinifDataRow["SinifAdi"] = "Seçiniz";
            sinifDataRow["AlanTipId"] = 0;
            dataSet.Sinif.Rows.InsertAt(sinifDataRow, 0);

            DataRow mudahaleDataRow = dataSet.Mudahale.NewRow();
            mudahaleDataRow["MudahaleAdi"] = "Seçiniz";
            mudahaleDataRow["AlanId"] = 0;
            mudahaleDataRow["SinifId"] = 0;
            dataSet.Mudahale.Rows.InsertAt(mudahaleDataRow, 0);

            DataRow aktiviteDataRow = dataSet.Aktivite.NewRow();
            aktiviteDataRow["AktiviteTanimi"] = "Seçiniz";
            dataSet.Aktivite.Rows.InsertAt(aktiviteDataRow, 0);

            ddlAlan.DataSource = dataSet.Alan;
            ddlAlan.DisplayMember = "AlanAdi";
            ddlAlan.ValueMember = "Id";

            ddlSinif.DataSource = dataSet.Sinif;
            ddlSinif.DisplayMember = "SinifAdi";
            ddlSinif.ValueMember = "Id";

            ddlMudahale.DataSource = dataSet.Mudahale;
            ddlMudahale.DisplayMember = "MudahaleAdi";
            ddlMudahale.ValueMember = "Id";

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            ddlAktivite.DataSource = dataSet.Aktivite;
            ddlAktivite.DisplayMember = "AktiviteTanimi";
            ddlAktivite.ValueMember = "Id";

            if (ilaveMudahaleDetayId.HasValue)
            {
                IlaveMudahaleDetayTableAdapter ilaveMudahaleDetayTableAdapter = new IlaveMudahaleDetayTableAdapter();
                ilaveMudahaleDetayTableAdapter.Fill(dataSet.IlaveMudahaleDetay);
                var selectedIlaveMudahaleDetay = dataSet.IlaveMudahaleDetay.FirstOrDefault(m => m.Id.Equals(ilaveMudahaleDetayId));
                if (selectedIlaveMudahaleDetay != null)
                {
                    //Texts
                    txtSira.Text = selectedIlaveMudahaleDetay.Sira.ToString();

                    //Combos
                    ddlAlan.SelectedValue = selectedIlaveMudahaleDetay.AlanId;
                    ddlSinif.SelectedValue = selectedIlaveMudahaleDetay.SinifId;
                    ddlMudahale.SelectedValue = selectedIlaveMudahaleDetay.MudahaleId;
                    ddlProblem.SelectedValue = selectedIlaveMudahaleDetay.ProblemId;
                    ddlAktivite.SelectedValue = selectedIlaveMudahaleDetay.AktiviteId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlAlan, ddlSinif, ddlMudahale, ddlAktivite, txtSira };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ilaveMudahaleDetayId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE IlaveMudahaledetay SET ProblemId = {0}, AlanId = {1}, SinifId = {2}, MudahaleId = {3}, AktiviteId = {4}, Sira = {5}, EkleyenKullaniciAdi = '{6}' WHERE Id = " + ilaveMudahaleDetayId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtSira.Text, Global.Username);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO IlaveMudahaledetay (ProblemId, AlanId, SinifId, MudahaleId, AktiviteId, Sira, EkleyenKullaniciAdi) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6}')";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtSira.Text, Global.Username);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadIlaveMudahaleDetay();
            this.Close();
        }
    }
}

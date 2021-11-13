using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditCalisanProblem : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? calisanProblemId;

        public EditCalisanProblem(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.calisanProblemId = id;
        }

        private void EditCalisanProblem_Load(object sender, EventArgs e)
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

            ddlKullanici.DataSource = GetKullanici();
            ddlKullanici.DisplayMember = "KullaniciAdi";
            ddlKullanici.ValueMember = "Id";

            ddlAktivite.DataSource = dataSet.Aktivite;
            ddlAktivite.DisplayMember = "AktiviteTanimi";
            ddlAktivite.ValueMember = "Id";

            if (calisanProblemId.HasValue)
            {
                CalisanProblemTableAdapter calisanProblemTableAdapter = new CalisanProblemTableAdapter();
                calisanProblemTableAdapter.Fill(dataSet.CalisanProblem);
                var selectedCalisanProblem = dataSet.CalisanProblem.FirstOrDefault(m => m.Id.Equals(calisanProblemId));
                if (selectedCalisanProblem != null)
                {
                    //Texts
                    txtAktiviteAciklama.Text = selectedCalisanProblem.AktiviteAciklama;

                    //DateTimePicker
                    dtpTarih.Value = selectedCalisanProblem.Tarih;

                    //Combos
                    ddlProblem.SelectedValue = selectedCalisanProblem.ProblemId;
                    ddlAlan.SelectedValue = selectedCalisanProblem.AlanId;
                    ddlSinif.SelectedValue = selectedCalisanProblem.SinifId;
                    ddlMudahale.SelectedValue = selectedCalisanProblem.MudahaleId;
                    ddlKullanici.SelectedValue = selectedCalisanProblem.KullaniciId;
                    ddlAktivite.SelectedValue = selectedCalisanProblem.AktiviteId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlKullanici, ddlAlan, ddlMudahale, ddlAktivite, ddlSinif, txtAktiviteAciklama, dtpTarih };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (calisanProblemId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE CalisanProblem SET ProblemId = {0}, KullaniciId = {1}, AlanId = {2}, SinifId = {3}, MudahaleId = {4}, AktiviteId = {5}, AktiviteAciklama = '{6}', Tarih = CONVERT(DATE, '{7}', 105) WHERE Id = " + calisanProblemId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlKullanici.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtAktiviteAciklama.Text, dtpTarih.Value.ToShortDateString());
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO CalisanProblem (ProblemId, KullaniciId, AlanId, SinifId, MudahaleId, AktiviteId, AktiviteAciklama, Tarih) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6}', CONVERT(DATE, '{7}', 105))";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlKullanici.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtAktiviteAciklama.Text, dtpTarih.Value.ToShortDateString());
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadCalisanProblem();
            this.Close();
        }
    }
}

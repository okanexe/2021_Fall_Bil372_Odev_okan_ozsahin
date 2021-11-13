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
    public partial class EditSinif : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? sinifId;

        public EditSinif(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.sinifId = id;
        }

        private void EditSinif_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTipiTableAdapter alanTipiTableAdapter = new AlanTipiTableAdapter();
            alanTipiTableAdapter.Fill(dataSet.AlanTipi);

            DataRow dataRow = dataSet.AlanTipi.NewRow();
            dataRow["TipAdi"] = "Seçiniz";
            dataSet.AlanTipi.Rows.InsertAt(dataRow, 0);

            ddlAlanTipi.DataSource = dataSet.AlanTipi;
            ddlAlanTipi.DisplayMember = "TipAdi";
            ddlAlanTipi.ValueMember = "Id";

            if (sinifId.HasValue)
            {
                SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
                sinifTableAdapter.Fill(dataSet.Sinif);
                var selectedSinif = dataSet.Sinif.FirstOrDefault(m => m.Id.Equals(sinifId));
                if (selectedSinif != null)
                {
                    // Text
                    txtSinifAdi.Text = selectedSinif.SinifAdi;

                    //Combos
                    ddlAlanTipi.SelectedValue = selectedSinif.AlanTipId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlanTipi, txtSinifAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (sinifId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Sinif SET SinifAdi = '{0}', AlanTipId = {1} WHERE Id = " + sinifId;
                sqlCommand = string.Format(sqlCommand, txtSinifAdi.Text, ddlAlanTipi.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Sinif (SinifAdi, AlanTipId) VALUES ('{0}', {1})";
                sqlCommand = string.Format(sqlCommand, txtSinifAdi.Text, ddlAlanTipi.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadSinif();
            this.Close();
        }
    }
}

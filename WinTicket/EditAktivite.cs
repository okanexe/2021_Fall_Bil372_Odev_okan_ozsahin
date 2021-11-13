using System;
using System.Linq;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditAktivite : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? aktiviteId;

        public EditAktivite(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.aktiviteId = id;
        }

        private void EditAktivite_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            if (aktiviteId.HasValue)
            {
                AktiviteTableAdapter aktiviteTableAdapter = new AktiviteTableAdapter();
                aktiviteTableAdapter.Fill(dataSet.Aktivite);
                var selectedAktivite = dataSet.Aktivite.FirstOrDefault(m => m.Id.Equals(aktiviteId));
                if (selectedAktivite != null)
                {
                    // Text
                    txtAktiviteTanimi.Text = selectedAktivite.AktiviteTanimi;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtAktiviteTanimi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (aktiviteId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Aktivite SET AktiviteTanimi = '{0}' WHERE Id = " + aktiviteId;
                sqlCommand = string.Format(sqlCommand, txtAktiviteTanimi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Aktivite (AktiviteTanimi) VALUES ('{0}')";
                sqlCommand = string.Format(sqlCommand, txtAktiviteTanimi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadAktivite();
            this.Close();
        }
    }
}

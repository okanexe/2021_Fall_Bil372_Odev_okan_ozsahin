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
    public partial class EditPersonelProblem : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? personelProblemId;

        public EditPersonelProblem(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.personelProblemId = id;
        }

        private void EditPersonelProblem_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            ddlKullanici.DataSource = GetKullanici();
            ddlKullanici.DisplayMember = "KullaniciAdi";
            ddlKullanici.ValueMember = "Id";

            if (personelProblemId.HasValue)
            {
                PersonelProblemTableAdapter personelProblemTableAdapter = new PersonelProblemTableAdapter();
                personelProblemTableAdapter.Fill(dataSet.PersonelProblem);
                var selectedPersonelProblem = dataSet.PersonelProblem.FirstOrDefault(m => m.Id.Equals(personelProblemId));
                if (selectedPersonelProblem != null)
                {
                    //Combos
                    ddlProblem.SelectedValue = selectedPersonelProblem.ProblemId;
                    ddlKullanici.SelectedValue = selectedPersonelProblem.KullaniciId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlKullanici };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (personelProblemId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE PersonelProblem SET ProblemId = {0}, KullaniciId = {1} WHERE Id = " + personelProblemId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlKullanici.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO PersonelProblem (ProblemId, KullaniciId) VALUES ({0}, {1})";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlKullanici.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadPersonelProblem();
            this.Close();
        }
    }
}

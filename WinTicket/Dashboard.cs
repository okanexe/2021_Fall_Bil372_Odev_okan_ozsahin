using System;
using System.Windows.Forms;
using WinTicket.Model;
using WinTicket.Util;

namespace WinTicket
{
    public partial class Dashboard : Form
    {
        private string _connectionString;
        private Operation _operation;
        public Dashboard()
        {
            InitializeComponent();
            _connectionString = Properties.Settings.Default.WinTicketConnectionString;
            _operation = new Operation();
        }

        #region Form Main
        private void InitPanel()
        {
            // Bolum I
            pnlKullanici.Visible = false;
            pnlBirim.Visible = false;
            pnlPersonel.Visible = false;
            pnlIl.Visible = false;
            pnlIlce.Visible = false;
            pnlProblemTipi.Visible = false;
            pnlProblem.Visible = false;
            pnlAlanTipi.Visible = false;
            pnlAlan.Visible = false;
            pnlSinif.Visible = false;
            pnlMudahale.Visible = false;
            pnlMudahaleDetay.Visible = false;
            pnlBelirtec.Visible = false;
            pnlCikti.Visible = false;
            pnlCiktiDetay.Visible = false;
            pnlProblemBirim.Visible = false;
            pnlAktivite.Visible = false;

            // Bolum II
            pnlProblemMudahale.Visible = false;
            pnlProblemCikti.Visible = false;
            pnlIlaveMudahaleDetay.Visible = false;
            pnlIlaveCiktiDetay.Visible = false;
            pnlPersonelProblem.Visible = false;
            pnlProblemCiktiDegerlendirme.Visible = false;
            pnlProblemDurumDegerlendirme.Visible = false;
            pnlCalisanProblem.Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Bolum I
            TreeNode adminSubMenu = new TreeNode("Yönetici");
            adminSubMenu.Nodes.Add(new TreeNode("Kullanıcı"));
            adminSubMenu.Nodes.Add(new TreeNode("Birim"));
            adminSubMenu.Nodes.Add(new TreeNode("Personel"));
            adminSubMenu.Nodes.Add(new TreeNode("İl"));
            adminSubMenu.Nodes.Add(new TreeNode("İlçe"));
            adminSubMenu.Nodes.Add(new TreeNode("Problem Tipi"));

            TreeNode sablonSubMenu = new TreeNode("Şablon");
            sablonSubMenu.Nodes.Add(new TreeNode("Alan Tipi"));
            sablonSubMenu.Nodes.Add(new TreeNode("Alan Tanımı"));
            sablonSubMenu.Nodes.Add(new TreeNode("Sınıf"));
            sablonSubMenu.Nodes.Add(new TreeNode("Müdahale"));
            sablonSubMenu.Nodes.Add(new TreeNode("Aktivite"));
            sablonSubMenu.Nodes.Add(new TreeNode("Müdahale Detay"));
            sablonSubMenu.Nodes.Add(new TreeNode("Çıktı"));
            sablonSubMenu.Nodes.Add(new TreeNode("Belirteç"));
            sablonSubMenu.Nodes.Add(new TreeNode("Çıktı Detay"));
            sablonSubMenu.Nodes.Add(new TreeNode("Problem Birim"));

            // Bolum II
            sablonSubMenu.Nodes.Add(new TreeNode("Problem Müdahale"));
            sablonSubMenu.Nodes.Add(new TreeNode("Problem Çıktı"));
            sablonSubMenu.Nodes.Add(new TreeNode("İlave Müdahale Detay"));
            sablonSubMenu.Nodes.Add(new TreeNode("İlave Çıktı Detay"));
            sablonSubMenu.Nodes.Add(new TreeNode("Personel Problem"));
            sablonSubMenu.Nodes.Add(new TreeNode("Problem Çıktı Değerlendirme"));
            sablonSubMenu.Nodes.Add(new TreeNode("Problem Durum Değerlendirme"));
            sablonSubMenu.Nodes.Add(new TreeNode("Çalışan Problem"));

            if (Global.UserRole.Equals(UserRole.ADMIN))
            {
                tvMenu.Nodes.Add(adminSubMenu);
            }

            if (Global.UserRole.Equals(UserRole.ADMIN) || Global.UserRole.Equals(UserRole.CALISAN))
            {
                tvMenu.Nodes.Add(sablonSubMenu);
            }

            // Bolum I
            tvMenu.Nodes.Add(new TreeNode("Problem Tanımı"));

            InitPanel();

            // Bolum I
            LoadKullanici();
            LoadBirim();
            LoadPersonel();
            LoadIl();
            LoadIlce();
            LoadProblemTipi();
            LoadProblem();
            LoadAlanTipi();
            LoadAlan();
            LoadSinif();
            LoadAktivite();
            LoadMudahale();
            LoadMudahaleDetay();
            LoadBelirtec();
            LoadCikti();
            LoadCiktiDetay();
            LoadProblemBirim();

            // Bolum II
            LoadProblemMudahale();
            LoadProblemCikti();
            LoadIlaveMudahaleDetay();
            LoadIlaveCiktiDetay();
            LoadPersonelProblem();
            LoadProblemCiktiDegerlendirme();
            LoadProblemDurumDegerlendirme();
            LoadCalisanProblem();
        }

        private void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            InitPanel();

            var current = tvMenu.SelectedNode.Text;
            switch (current)
            {
                // Bolum I
                case "Kullanıcı":
                    pnlKullanici.Visible = true;
                    break;
                case "Birim":
                    pnlBirim.Visible = true;
                    break;
                case "Personel":
                    pnlPersonel.Visible = true;
                    break;
                case "İl":
                    pnlIl.Visible = true;
                    break;
                case "İlçe":
                    pnlIlce.Visible = true;
                    break;
                case "Problem Tipi":
                    pnlProblemTipi.Visible = true;
                    break;
                case "Problem Tanımı":
                    pnlProblem.Visible = true;
                    break;
                case "Alan Tipi":
                    pnlAlanTipi.Visible = true;
                    break;
                case "Alan Tanımı":
                    pnlAlan.Visible = true;
                    break;
                case "Sınıf":
                    pnlSinif.Visible = true;
                    break;
                case "Müdahale":
                    pnlMudahale.Visible = true;
                    break;
                case "Müdahale Detay":
                    pnlMudahaleDetay.Visible = true;
                    break;
                case "Belirteç":
                    pnlBelirtec.Visible = true;
                    break;
                case "Çıktı":
                    pnlCikti.Visible = true;
                    break;
                case "Çıktı Detay":
                    pnlCiktiDetay.Visible = true;
                    break;
                case "Problem Birim":
                    pnlProblemBirim.Visible = true;
                    break;
                case "Aktivite":
                    pnlAktivite.Visible = true;
                    break;

                // Bolum II
                case "Problem Müdahale":
                    pnlProblemMudahale.Visible = true;
                    break;
                case "Problem Çıktı":
                    pnlProblemCikti.Visible = true;
                    break;
                case "İlave Müdahale Detay":
                    pnlIlaveMudahaleDetay.Visible = true;
                    break;
                case "İlave Çıktı Detay":
                    pnlIlaveCiktiDetay.Visible = true;
                    break;
                case "Personel Problem":
                    pnlPersonelProblem.Visible = true;
                    break;
                case "Problem Çıktı Değerlendirme":
                    pnlProblemCiktiDegerlendirme.Visible = true;
                    break;
                case "Problem Durum Değerlendirme":
                    pnlProblemDurumDegerlendirme.Visible = true;
                    break;
                case "Çalışan Problem":
                    pnlCalisanProblem.Visible = true;
                    break;
            }
        }

        #endregion

        // Bolum I
        #region Birim Panel
        private void btnBirimEkle_Click(object sender, EventArgs e)
        {
            int? birimId = null;

            var selected = dgBirim.SelectedRows;
            if (selected.Count == 1)
            {
                birimId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var addBirim = new EditBirim(this, birimId);
            addBirim.Location = this.Location;
            addBirim.StartPosition = FormStartPosition.Manual;
            addBirim.FormClosing += delegate { this.Show(); };
            addBirim.Show();
        }

        /// <summary>
        /// Birim formu verileri
        /// </summary>
        public void LoadBirim()
        {
            string sqlCommand = @"
                SELECT 
                    K.Id, 
                    K.BirimAdi, 
                    L.BirimAdi                  AS UstBirim, 
                    K.Adres, 
                    M.IlAdi, 
                    N.IlceAdi, 
                    K.PostaKodu, 
                    CONCAT(O.Ad, ' ', O.Soyad)  AS BirimMuduru 
                FROM 
	                Birim				K
	                LEFT JOIN Birim		L	ON K.UstBirimId		= L.Id
	                LEFT JOIN Il		M	ON K.IlId			= M.Id
	                LEFT JOIN Ilce		N	ON K.IlceId			= N.Id
	                LEFT JOIN Personel	O	ON K.BirimMudurId	= O.Id";

            var birimDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Birim");

            dgBirim.DataSource = birimDataSet.Tables[0];

            string[] headerAliases = { "#", "Birim Adı", "Üst Birim", "Adres", "İl", "İlçe", "Posta Kodu", "Yönetici" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgBirim.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgBirim_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgBirim.SelectedRows;
            if (selected.Count == 1)
            {
                btnBirimEkle.Text = "Güncelle";
            }
            else
            {
                btnBirimEkle.Text = "Ekle";
            }
        }

        private void btnBirimSil_Click(object sender, EventArgs e)
        {
            var selected = dgBirim.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Birim WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadBirim();
                }
            }
        }
        #endregion
        #region Personel Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadPersonel()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
                    K.SicilNo, 
	                K.Ad, 
	                K.Soyad, 
	                K.KullaniciAdi, 
	                K.Email, 
	                K.Telefon, 
	                K.Adres, 
	                N.IlAdi,
	                O.IlceAdi,
	                K.PostaKodu, 
	                CONCAT(L.Ad, ' ', L.Soyad) AS UstPersonel,
	                M.BirimAdi
                FROM
	                Personel K
	                LEFT JOIN	Personel	L	ON	K.UstPersonelId = L.Id
	                LEFT JOIN	Birim		M	ON	K.BirimId		= M.Id
	                LEFT JOIN	Il			N	ON	K.IlId			= N.Id
	                LEFT JOIN	Ilce		O	ON	K.IlceId		= O.Id";

            var personelDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Personel");

            dgPersonel.DataSource = personelDataSet.Tables[0];

            string[] headerAliases = { "#", "Sicil", "Ad", "Soyad", "Kullanıcı Adı", "Email", "Telefon", "Adres", "İl", "İlçe", "Posta Kodu", "Üst Personel", "Birim" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgPersonel.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            var selected = dgPersonel.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Personel WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadPersonel();
                }
            }
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            int? personelId = null;

            var selected = dgPersonel.SelectedRows;
            if (selected.Count == 1)
            {
                personelId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editPersonel = new EditPersonel(this, personelId);
            editPersonel.Location = this.Location;
            editPersonel.StartPosition = FormStartPosition.Manual;
            editPersonel.FormClosing += delegate { this.Show(); };
            editPersonel.Show();
        }

        private void dgPersonel_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgPersonel.SelectedRows;
            if (selected.Count == 1)
            {
                btnPersonelEkle.Text = "Güncelle";
            }
            else
            {
                btnPersonelEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Kullanici Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadKullanici()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
                    K.KullaniciAdi, 
	                L.RoleAdi KullaniciRol
                FROM
	                Kullanici               K
	                JOIN	KullaniciRol	L	ON	K.RoleId = L.Id";

            var kullaniciDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Kullanici");

            dgKullanici.DataSource = kullaniciDataSet.Tables[0];

            string[] headerAliases = { "#", "Kullanıcı Adı", "Kullanıcı Rol" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgKullanici.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            int? kullaniciId = null;

            var selected = dgKullanici.SelectedRows;
            if (selected.Count == 1)
            {
                kullaniciId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editKullanici = new EditKullanici(this, kullaniciId);
            editKullanici.Location = this.Location;
            editKullanici.StartPosition = FormStartPosition.Manual;
            editKullanici.FormClosing += delegate { this.Show(); };
            editKullanici.Show();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            var selected = dgKullanici.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Kullanici WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadKullanici();
                }
            }
        }

        private void dgKullanici_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgKullanici.SelectedRows;
            if (selected.Count == 1)
            {
                btnKullaniciEkle.Text = "Güncelle";
            }
            else
            {
                btnKullaniciEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Il Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadIl()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
                    K.IlAdi
                FROM
	                Il K";

            var ilDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Il");

            dgIl.DataSource = ilDataSet.Tables[0];

            string[] headerAliases = { "#", "İl Adı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgIl.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnIlEkle_Click(object sender, EventArgs e)
        {
            int? ilId = null;

            var selected = dgIl.SelectedRows;
            if (selected.Count == 1)
            {
                ilId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var ediIl = new EditIl(this, ilId);
            ediIl.Location = this.Location;
            ediIl.StartPosition = FormStartPosition.Manual;
            ediIl.FormClosing += delegate { this.Show(); };
            ediIl.Show();
        }

        private void btnIlSil_Click(object sender, EventArgs e)
        {
            var selected = dgIl.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Il WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadIl();
                }
            }
        }

        private void dgIl_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgIl.SelectedRows;
            if (selected.Count == 1)
            {
                btnIlEkle.Text = "Güncelle";
            }
            else
            {
                btnIlEkle.Text = "Ekle";
            }
        }

        #endregion
        #region Ilce Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadIlce()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
                    K.IlceAdi, 
	                L.IlAdi
                FROM
	                Ilce            K
	                JOIN	Il      L	ON	K.IlId = L.Id";

            var ilceDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Ilce");

            dgIlce.DataSource = ilceDataSet.Tables[0];

            string[] headerAliases = { "#", "İlçe Adı", "İl Adı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgIlce.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnIlceEkle_Click(object sender, EventArgs e)
        {
            int? ilceId = null;

            var selected = dgIlce.SelectedRows;
            if (selected.Count == 1)
            {
                ilceId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editIlce = new EditIlce(this, ilceId);
            editIlce.Location = this.Location;
            editIlce.StartPosition = FormStartPosition.Manual;
            editIlce.FormClosing += delegate { this.Show(); };
            editIlce.Show();
        }

        private void btnIlceSil_Click(object sender, EventArgs e)
        {
            var selected = dgIlce.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Ilce WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadIlce();
                }
            }
        }

        private void dgIlce_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgIlce.SelectedRows;
            if (selected.Count == 1)
            {
                btnIlceEkle.Text = "Güncelle";
            }
            else
            {
                btnIlceEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Problem Tipi Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemTipi()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        K.TipAdi
		        FROM
			        ProblemTipi K";

            var problemTipiDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemTipi");

            dgProblemTipi.DataSource = problemTipiDataSet.Tables[0];

            string[] headerAliases = { "#", "Problem Tipi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemTipi.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnProblemTipiEkle_Click(object sender, EventArgs e)
        {
            int? tipId = null;

            var selected = dgProblemTipi.SelectedRows;
            if (selected.Count == 1)
            {
                tipId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemTipi = new EditProblemTipi(this, tipId);
            editProblemTipi.Location = this.Location;
            editProblemTipi.StartPosition = FormStartPosition.Manual;
            editProblemTipi.FormClosing += delegate { this.Show(); };
            editProblemTipi.Show();
        }

        private void btnProblemTipiSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemTipi.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemTipi WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemTipi();
                }
            }
        }

        private void dgProblemTipi_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemTipi.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemTipiEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemTipiEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Problem Tanimi Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblem()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
	                L.TipAdi,
                    K.TanimlayiciAd,
                    K.TanimlayiciSoyad,
                    K.TanimlayiciTCKN,
                    K.TanimlayiciPasaportNo,
                    K.HedeflenenAmacTanimi
                FROM
	                Problem                 K
	                JOIN	ProblemTipi     L	ON	K.TipId = L.Id";

            var problemDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Problem");

            dgProblem.DataSource = problemDataSet.Tables[0];

            string[] headerAliases = { "#", "Problem Tipi", "Tanımlayıcı Adı", "Tanımlayıcı Soyadı", "Tanımlayıcı TCKN", "Tanımlayıcı Pasaport No", "Hedeflenen Amaç Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblem.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnProblemEkle_Click(object sender, EventArgs e)
        {
            int? problemId = null;

            var selected = dgProblem.SelectedRows;
            if (selected.Count == 1)
            {
                problemId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblem = new EditProblem(this, problemId);
            editProblem.Location = this.Location;
            editProblem.StartPosition = FormStartPosition.Manual;
            editProblem.FormClosing += delegate { this.Show(); };
            editProblem.Show();
        }

        private void btnProblemSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblem.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Problem WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblem();
                }
            }
        }

        private void dgProblem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblem.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Alan Tipi Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadAlanTipi()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        K.TipAdi
		        FROM
			        AlanTipi K";

            var alanTipiDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "AlanTipi");

            dgAlanTipi.DataSource = alanTipiDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan Tipi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgAlanTipi.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnAlanTipiSil_Click(object sender, EventArgs e)
        {
            var selected = dgAlanTipi.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM AlanTipi WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadAlanTipi();
                }
            }
        }

        private void btnAlanTipiEkle_Click(object sender, EventArgs e)
        {
            int? alanTipiId = null;

            var selected = dgAlanTipi.SelectedRows;
            if (selected.Count == 1)
            {
                alanTipiId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editAlanTipi = new EditAlanTipi(this, alanTipiId);
            editAlanTipi.Location = this.Location;
            editAlanTipi.StartPosition = FormStartPosition.Manual;
            editAlanTipi.FormClosing += delegate { this.Show(); };
            editAlanTipi.Show();
        }

        private void dgAlanTipi_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgAlanTipi.SelectedRows;
            if (selected.Count == 1)
            {
                btnAlanTipiEkle.Text = "Güncelle";
            }
            else
            {
                btnAlanTipiEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Alan Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadAlan()
        {
            string sqlCommand = @"
                SELECT 
	                K.Id,
	                K.AlanAdi,
                    L.TipAdi
                FROM
	                Alan                 K
	                JOIN	AlanTipi     L	ON	K.TipId = L.Id";

            var alanDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Alan");

            dgAlan.DataSource = alanDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan Adı", "Alan Tipi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgAlan.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void btnAlanEkle_Click(object sender, EventArgs e)
        {
            int? alanId = null;

            var selected = dgAlan.SelectedRows;
            if (selected.Count == 1)
            {
                alanId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editAlan = new EditAlan(this, alanId);
            editAlan.Location = this.Location;
            editAlan.StartPosition = FormStartPosition.Manual;
            editAlan.FormClosing += delegate { this.Show(); };
            editAlan.Show();
        }

        private void btnAlanSil_Click(object sender, EventArgs e)
        {
            var selected = dgAlan.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Alan WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadAlan();
                }
            }
        }

        private void dgAlan_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgAlan.SelectedRows;
            if (selected.Count == 1)
            {
                btnAlanEkle.Text = "Güncelle";
            }
            else
            {
                btnAlanEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Sinif Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadSinif()
        {
            string sqlCommand = @"
		    SELECT 
			    K.Id,
			    K.SinifAdi,
			    L.TipAdi
		    FROM
			    Sinif                   K
			    JOIN	AlanTipi        L	ON	K.AlanTipId = L.Id";

            var alanDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Sinif");

            dgSinif.DataSource = alanDataSet.Tables[0];

            string[] headerAliases = { "#", "Sınıf Adı", "Alan Tipi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgSinif.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void btnSinifEkle_Click(object sender, EventArgs e)
        {
            int? sinifId = null;

            var selected = dgSinif.SelectedRows;
            if (selected.Count == 1)
            {
                sinifId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editSinif = new EditSinif(this, sinifId);
            editSinif.Location = this.Location;
            editSinif.StartPosition = FormStartPosition.Manual;
            editSinif.FormClosing += delegate { this.Show(); };
            editSinif.Show();
        }

        private void btnSinifSil_Click(object sender, EventArgs e)
        {
            var selected = dgSinif.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Sinif WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadAlan();
                }
            }
        }

        private void dgSinif_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgSinif.SelectedRows;
            if (selected.Count == 1)
            {
                btnSinifEkle.Text = "Güncelle";
            }
            else
            {
                btnSinifEkle.Text = "Ekle";
            }
        }

        #endregion
        #region Müdahale Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadMudahale()
        {
            string sqlCommand = @"
		        SELECT
			        K.Id,
                    K.MudahaleAdi,
			        L.AlanAdi,
			        M.SinifAdi
		        FROM
			        Mudahale             K
			        JOIN	Alan         L	ON	K.AlanId  = L.Id
                    JOIN	Sinif        M	ON	K.SinifId = M.Id";

            var mudahaleDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Mudahale");

            dgMudahale.DataSource = mudahaleDataSet.Tables[0];

            string[] headerAliases = { "#", "Müdahale Adı", "Alan Adı", "Sınıf Adı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgMudahale.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void dgMudahale_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgMudahale.SelectedRows;
            if (selected.Count == 1)
            {
                btnMudahaleEkle.Text = "Güncelle";
            }
            else
            {
                btnMudahaleEkle.Text = "Ekle";
            }
        }

        private void btnMudahaleEkle_Click(object sender, EventArgs e)
        {
            int? mudahaleId = null;

            var selected = dgMudahale.SelectedRows;
            if (selected.Count == 1)
            {
                mudahaleId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editMudahale = new EditMudahale(this, mudahaleId);
            editMudahale.Location = this.Location;
            editMudahale.StartPosition = FormStartPosition.Manual;
            editMudahale.FormClosing += delegate { this.Show(); };
            editMudahale.Show();
        }

        private void btnMudahaleSil_Click(object sender, EventArgs e)
        {
            var selected = dgMudahale.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Mudahale WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadMudahale();
                }
            }
        }
        #endregion
        #region Müdahale Detay Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadMudahaleDetay()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.MudahaleAdi,
                    M.AlanAdi,
                    N.SinifAdi,
                    O.AktiviteTanimi,
                    K.Sira
		        FROM
			        MudahaleDetay       K
			        JOIN	Mudahale    L	ON	K.MudahaleId    = L.Id
                    JOIN	Alan        M	ON	K.AlanId        = M.Id
                    JOIN	Sinif       N	ON	K.SinifId       = N.Id
                    JOIN	Aktivite    O	ON	K.AktiviteId    = O.Id";

            var mudahaleDetayDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "MudahaleDetay");

            dgMudahaleDetay.DataSource = mudahaleDetayDataSet.Tables[0];

            string[] headerAliases = { "#", "Müdahale Adı", "Alan Adı", "Sınıf Adı", "Aktivite Adı", "Sıra" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgMudahaleDetay.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgMudahaleDetay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgMudahaleDetay.SelectedRows;
            if (selected.Count == 1)
            {
                btnMudahaleDetayEkle.Text = "Güncelle";
            }
            else
            {
                btnMudahaleDetayEkle.Text = "Ekle";
            }
        }

        private void btnMudahaleDetayEkle_Click(object sender, EventArgs e)
        {
            int? mudahaleDetayId = null;

            var selected = dgMudahaleDetay.SelectedRows;
            if (selected.Count == 1)
            {
                mudahaleDetayId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editMudahaleDetay = new EditMudahaleDetay(this, mudahaleDetayId);
            editMudahaleDetay.Location = this.Location;
            editMudahaleDetay.StartPosition = FormStartPosition.Manual;
            editMudahaleDetay.FormClosing += delegate { this.Show(); };
            editMudahaleDetay.Show();
        }

        private void btnMudahaleDetaySil_Click(object sender, EventArgs e)
        {
            var selected = dgMudahaleDetay.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM MudahaleDetay WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadMudahaleDetay();
                }
            }
        }
        #endregion
        #region Belirtec Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadBelirtec()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        K.BelirtecTanimi
		        FROM
			        Belirtec K";

            var belirtecDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Belirtec");

            dgBelirtec.DataSource = belirtecDataSet.Tables[0];

            string[] headerAliases = { "#", "Belirteç Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgBelirtec.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnBelirtecEkle_Click(object sender, EventArgs e)
        {
            int? belirtecId = null;

            var selected = dgBelirtec.SelectedRows;
            if (selected.Count == 1)
            {
                belirtecId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editBelirtec = new EditBelirtec(this, belirtecId);
            editBelirtec.Location = this.Location;
            editBelirtec.StartPosition = FormStartPosition.Manual;
            editBelirtec.FormClosing += delegate { this.Show(); };
            editBelirtec.Show();
        }

        private void btnBelirtecSil_Click(object sender, EventArgs e)
        {
            var selected = dgBelirtec.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Belirtec WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadBelirtec();
                }
            }
        }

        private void dgBelirtec_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgBelirtec.SelectedRows;
            if (selected.Count == 1)
            {
                btnBelirtecEkle.Text = "Güncelle";
            }
            else
            {
                btnBelirtecEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Cikti Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadCikti()
        {
            string sqlCommand = @"
		        SELECT
			        K.Id,
                    K.CiktiAdi,
			        L.AlanAdi,
			        M.SinifAdi
		        FROM
			        Cikti                K
			        JOIN	Alan         L	ON	K.AlanId  = L.Id
                    JOIN	Sinif        M	ON	K.SinifId = M.Id";

            var ciktiDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Cikti");

            dgCikti.DataSource = ciktiDataSet.Tables[0];

            string[] headerAliases = { "#", "Çıktı Adı", "Alan Adı", "Sınıf Adı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgCikti.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnCiktiEkle_Click(object sender, EventArgs e)
        {
            int? ciktiId = null;

            var selected = dgCikti.SelectedRows;
            if (selected.Count == 1)
            {
                ciktiId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editCikti = new EditCikti(this, ciktiId);
            editCikti.Location = this.Location;
            editCikti.StartPosition = FormStartPosition.Manual;
            editCikti.FormClosing += delegate { this.Show(); };
            editCikti.Show();
        }

        private void btnCiktiSil_Click(object sender, EventArgs e)
        {
            var selected = dgCikti.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Cikti WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadCikti();
                }
            }
        }
        private void dgCikti_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgCikti.SelectedRows;
            if (selected.Count == 1)
            {
                btnCiktiEkle.Text = "Güncelle";
            }
            else
            {
                btnCiktiEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Cikti Detay Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadCiktiDetay()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.CiktiAdi,
                    M.AlanAdi,
                    N.SinifAdi,
                    O.BelirtecTanimi,
                    K.Sira
		        FROM
			        CiktiDetay          K
			        JOIN	Cikti       L	ON	K.CiktiId       = L.Id
                    JOIN	Alan        M	ON	K.AlanId        = M.Id
                    JOIN	Sinif       N	ON	K.SinifId       = N.Id
                    JOIN	Belirtec    O	ON	K.BelirtecId    = O.Id";

            var ciktiDetayDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "CiktiDetay");

            dgCiktiDetay.DataSource = ciktiDetayDataSet.Tables[0];

            string[] headerAliases = { "#", "Çıktı Adı", "Alan Adı", "Sınıf Adı", "Belirteç Adı", "Sıra" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgCiktiDetay.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void btnCiktiDetayEkle_Click(object sender, EventArgs e)
        {
            int? ciktiDetayId = null;

            var selected = dgCiktiDetay.SelectedRows;
            if (selected.Count == 1)
            {
                ciktiDetayId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editCiktiDetay = new EditCiktiDetay(this, ciktiDetayId);
            editCiktiDetay.Location = this.Location;
            editCiktiDetay.StartPosition = FormStartPosition.Manual;
            editCiktiDetay.FormClosing += delegate { this.Show(); };
            editCiktiDetay.Show();
        }

        private void btnCiktiDetaySil_Click(object sender, EventArgs e)
        {
            var selected = dgCiktiDetay.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM CiktiDetay WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadCiktiDetay();
                }
            }
        }

        private void dgCiktiDetay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgCiktiDetay.SelectedRows;
            if (selected.Count == 1)
            {
                btnCiktiDetayEkle.Text = "Güncelle";
            }
            else
            {
                btnCiktiDetayEkle.Text = "Ekle";
            }
        }
        #endregion
        #region Problem Birim Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemBirim()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.HedeflenenAmacTanimi,
			        M.BirimAdi,
                    K.EslesmeTarihi
		        FROM
			        ProblemBirim         K
			        JOIN	Problem      L	ON	K.ProblemId = L.Id
                    JOIN	Birim        M	ON	K.BirimId   = M.Id";

            var problemBirimDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemBirim");

            dgProblemBirim.DataSource = problemBirimDataSet.Tables[0];

            string[] headerAliases = { "#", "Hedeflenen Amaç Tanımı", "Birim Adı", "Eşleşme Tarihi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemBirim.Columns[i].HeaderText = headerAliases[i];
            }
        }
        private void dgProblemBirim_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemBirim.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemBirimEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemBirimEkle.Text = "Ekle";
            }
        }

        private void btnProblemBirimEkle_Click(object sender, EventArgs e)
        {
            int? problemBirimId = null;

            var selected = dgProblemBirim.SelectedRows;
            if (selected.Count == 1)
            {
                problemBirimId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemBirim = new EditProblemBirim(this, problemBirimId);
            editProblemBirim.Location = this.Location;
            editProblemBirim.StartPosition = FormStartPosition.Manual;
            editProblemBirim.FormClosing += delegate { this.Show(); };
            editProblemBirim.Show();
        }

        private void btnProblemBirimSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemBirim.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemBirim WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemBirim();
                }
            }
        }
        #endregion
        #region Aktivite Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadAktivite()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        K.AktiviteTanimi
		        FROM
			        Aktivite K";

            var aktiviteDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "Aktivite");

            dgAktivite.DataSource = aktiviteDataSet.Tables[0];

            string[] headerAliases = { "#", "Aktivite Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgAktivite.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgAktivite_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgAktivite.SelectedRows;
            if (selected.Count == 1)
            {
                btnAktiviteEkle.Text = "Güncelle";
            }
            else
            {
                btnAktiviteEkle.Text = "Ekle";
            }
        }

        private void btnAktiviteEkle_Click(object sender, EventArgs e)
        {
            int? aktiviteId = null;

            var selected = dgAktivite.SelectedRows;
            if (selected.Count == 1)
            {
                aktiviteId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editAktivite = new EditAktivite(this, aktiviteId);
            editAktivite.Location = this.Location;
            editAktivite.StartPosition = FormStartPosition.Manual;
            editAktivite.FormClosing += delegate { this.Show(); };
            editAktivite.Show();
        }

        private void btnAktiviteSil_Click(object sender, EventArgs e)
        {
            var selected = dgAktivite.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM Aktivite WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadAktivite();
                }
            }
        }
        #endregion

        // Bolum II
        #region Problem Müdahale Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemMudahale()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.AlanAdi,
			        M.SinifAdi,
			        N.MudahaleAdi,
			        O.HedeflenenAmacTanimi
		        FROM
			        ProblemMudahale K
			        JOIN Alan		L	ON K.AlanId 	= L.Id
			        JOIN Sinif		M	ON K.SinifId 	= M.Id 
			        JOIN Mudahale	N	ON K.MudahaleId = N.Id 
			        JOIN Problem	O	ON K.ProblemId 	= O.Id";

            var problemMudahaleDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemMudahale");

            dgProblemMudahale.DataSource = problemMudahaleDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan", "Sınıf", "Müdahale", "Hedeflenen Amaç Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemMudahale.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgProblemMudahale_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemMudahale.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemMudahaleEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemMudahaleEkle.Text = "Ekle";
            }
        }

        private void btnProblemMudahaleEkle_Click(object sender, EventArgs e)
        {
            int? problemMudahaleId = null;

            var selected = dgProblemMudahale.SelectedRows;
            if (selected.Count == 1)
            {
                problemMudahaleId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemMudahale = new EditProblemMudahale(this, problemMudahaleId);
            editProblemMudahale.Location = this.Location;
            editProblemMudahale.StartPosition = FormStartPosition.Manual;
            editProblemMudahale.FormClosing += delegate { this.Show(); };
            editProblemMudahale.Show();
        }

        private void btnProblemMudahaleSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemMudahale.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemMudahale WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemMudahale();
                }
            }
        }

        #endregion
        #region Problem Çıktı Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemCikti()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.AlanAdi,
			        M.SinifAdi,
			        N.CiktiAdi,
			        O.HedeflenenAmacTanimi
		        FROM
			        ProblemCikti 	K
			        JOIN Alan		L	ON K.AlanId 	= L.Id
			        JOIN Sinif		M	ON K.SinifId 	= M.Id 
			        JOIN Cikti		N	ON K.CiktiId 	= N.Id 
			        JOIN Problem	O	ON K.ProblemId 	= O.Id";

            var problemCiktiDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemCikti");

            dgProblemCikti.DataSource = problemCiktiDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan", "Sınıf", "Çıktı Adı", "Hedeflenen Amaç Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemCikti.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgProblemCikti_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemCikti.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemCiktiEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemCiktiEkle.Text = "Ekle";
            }
        }

        private void btnProblemCiktiEkle_Click(object sender, EventArgs e)
        {
            int? problemCiktiId = null;

            var selected = dgProblemCikti.SelectedRows;
            if (selected.Count == 1)
            {
                problemCiktiId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemCikti = new EditProblemCikti(this, problemCiktiId);
            editProblemCikti.Location = this.Location;
            editProblemCikti.StartPosition = FormStartPosition.Manual;
            editProblemCikti.FormClosing += delegate { this.Show(); };
            editProblemCikti.Show();
        }

        private void btnProblemCiktiSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemCikti.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemCikti WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemCikti();
                }
            }
        }
        #endregion
        #region İlave Müdahale Detay Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadIlaveMudahaleDetay()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.AlanAdi,
			        M.SinifAdi,
			        N.MudahaleAdi,
			        O.AktiviteTanimi,
			        K.Sira,
			        K.EkleyenKullaniciAdi,
			        K.EklenmeTarihi
		        FROM
			        IlaveMudahaleDetay 	K
			        JOIN Alan			L	ON K.AlanId 		= L.Id
			        JOIN Sinif			M	ON K.SinifId 		= M.Id 
			        JOIN Mudahale		N	ON K.MudahaleId 	= N.Id 
			        JOIN Aktivite		O	ON K.AktiviteId 	= O.Id";

            var ilaveMudahaleDetayDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "IlaveMudahaleDetay");

            dgIlaveMudahaleDetay.DataSource = ilaveMudahaleDetayDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan", "Sınıf", "Müdahale", "Aktivite Tanımı", "Sıra", "Ekleyen", "Eklenme Tarihi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgIlaveMudahaleDetay.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgIlaveMudahaleDetay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgIlaveMudahaleDetay.SelectedRows;
            if (selected.Count == 1)
            {
                btnIlaveMudahaleDetayEkle.Text = "Güncelle";
            }
            else
            {
                btnIlaveMudahaleDetayEkle.Text = "Ekle";
            }
        }

        private void btnIlaveMudahaleDetayEkle_Click(object sender, EventArgs e)
        {
            int? ilaveMudahaleDetayId = null;

            var selected = dgIlaveMudahaleDetay.SelectedRows;
            if (selected.Count == 1)
            {
                ilaveMudahaleDetayId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editIlaveMudahaleDetay = new EditIlaveMudahaleDetay(this, ilaveMudahaleDetayId);
            editIlaveMudahaleDetay.Location = this.Location;
            editIlaveMudahaleDetay.StartPosition = FormStartPosition.Manual;
            editIlaveMudahaleDetay.FormClosing += delegate { this.Show(); };
            editIlaveMudahaleDetay.Show();
        }

        private void btnIlaveMudahaleDetaySil_Click(object sender, EventArgs e)
        {
            var selected = dgIlaveMudahaleDetay.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM IlaveMudahaleDetay WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadIlaveMudahaleDetay();
                }
            }
        }
        #endregion
        #region İlave Çıktı Detay Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadIlaveCiktiDetay()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.AlanAdi,
			        M.SinifAdi,
			        N.MudahaleAdi,
			        O.BelirtecTanimi,
			        K.Sira,
                    P.HedeflenenAmacTanimi,
			        K.EkleyenKullaniciAdi,
			        K.EklenmeTarihi
		        FROM
			        IlaveCiktiDetay 	K
			        JOIN Alan			L	ON K.AlanId 		= L.Id
			        JOIN Sinif			M	ON K.SinifId 		= M.Id 
			        JOIN Mudahale		N	ON K.MudahaleId 	= N.Id 
			        JOIN Belirtec		O	ON K.BelirtecId 	= O.Id
			        JOIN Problem		P	ON K.ProblemId 		= P.Id";

            var ilaveCiktiDetayDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "IlaveCiktiDetay");

            dgIlaveCiktiDetay.DataSource = ilaveCiktiDetayDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan", "Sınıf", "Müdahale", "Belirteç", "Sıra", "Hedeflenen Amaç Tanımı", "Ekleyen", "Eklenme Tarihi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgIlaveCiktiDetay.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgIlaveCiktiDetay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgIlaveMudahaleDetay.SelectedRows;
            if (selected.Count == 1)
            {
                btnIlaveCiktiDetayEkle.Text = "Güncelle";
            }
            else
            {
                btnIlaveCiktiDetayEkle.Text = "Ekle";
            }
        }

        private void btnIlaveCiktiDetayEkle_Click(object sender, EventArgs e)
        {
            int? ilaveCiktiDetayId = null;

            var selected = dgIlaveCiktiDetay.SelectedRows;
            if (selected.Count == 1)
            {
                ilaveCiktiDetayId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editIlaveCiktiDetay = new EditIlaveCiktiDetay(this, ilaveCiktiDetayId);
            editIlaveCiktiDetay.Location = this.Location;
            editIlaveCiktiDetay.StartPosition = FormStartPosition.Manual;
            editIlaveCiktiDetay.FormClosing += delegate { this.Show(); };
            editIlaveCiktiDetay.Show();
        }

        private void btnIlaveCiktiDetaySil_Click(object sender, EventArgs e)
        {
            var selected = dgIlaveCiktiDetay.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM IlaveCiktiDetay WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadIlaveCiktiDetay();
                }
            }
        }
        #endregion
        #region Personel Problem Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadPersonelProblem()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.HedeflenenAmacTanimi,
			        M.KullaniciAdi
		        FROM
			        PersonelProblem 	K
			        JOIN Problem		L	ON K.ProblemId 		= L.Id
			        JOIN Kullanici		M	ON K.KullaniciId 	= M.Id";

            var personelProblemDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "PersonelProblem");

            dgPersonelProblem.DataSource = personelProblemDataSet.Tables[0];

            string[] headerAliases = { "#", "Hedeflenen Amaç Tanımı", "Kullanıcı Adı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgPersonelProblem.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgPersonelProblem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgPersonelProblem.SelectedRows;
            if (selected.Count == 1)
            {
                btnPersonelProblemEkle.Text = "Güncelle";
            }
            else
            {
                btnPersonelProblemEkle.Text = "Ekle";
            }
        }

        private void btnPersonelProblemEkle_Click(object sender, EventArgs e)
        {
            int? personelProblemId = null;

            var selected = dgPersonelProblem.SelectedRows;
            if (selected.Count == 1)
            {
                personelProblemId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editPersonelProblem = new EditPersonelProblem(this, personelProblemId);
            editPersonelProblem.Location = this.Location;
            editPersonelProblem.StartPosition = FormStartPosition.Manual;
            editPersonelProblem.FormClosing += delegate { this.Show(); };
            editPersonelProblem.Show();
        }

        private void btnPersonelProblemSil_Click(object sender, EventArgs e)
        {
            var selected = dgPersonelProblem.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM PersonelProblem WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadPersonelProblem();
                }
            }
        }
        #endregion
        #region Problem Çıktı Değerlendirme Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemCiktiDegerlendirme()
        {
            string sqlCommand = @"
		        SELECT 
	                K.Id,
	                L.BelirtecTanimi,
	                K.Skor,
	                K.SkorTarihi,
	                M.HedeflenenAmacTanimi
                FROM
	                ProblemCiktiDegerlendirme 		K
	                JOIN Belirtec			        L	ON K.BelirtecId 	= L.Id 
	                JOIN Problem		            M	ON K.ProblemId 		= M.Id";

            var problemCiktiDegerlendirmeDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemCiktiDegerlendirme");

            dgProblemCiktiDegerlendirme.DataSource = problemCiktiDegerlendirmeDataSet.Tables[0];

            string[] headerAliases = { "#", "Belirteç Tanımı", "Skor", "Skor Tarihi", "Hedeflenen Amaç Tanımı" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemCiktiDegerlendirme.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgProblemCiktiDegerlendirme_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemCiktiDegerlendirme.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemCiktiDegerlendirmeEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemCiktiDegerlendirmeEkle.Text = "Ekle";
            }
        }

        private void btnProblemCiktiDegerlendirmeEkle_Click(object sender, EventArgs e)
        {
            int? problemCiktiDegerlendirmeId = null;

            var selected = dgProblemCiktiDegerlendirme.SelectedRows;
            if (selected.Count == 1)
            {
                problemCiktiDegerlendirmeId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemCiktiDegerlendirme = new EditProblemCiktiDegerlendirme(this, problemCiktiDegerlendirmeId);
            editProblemCiktiDegerlendirme.Location = this.Location;
            editProblemCiktiDegerlendirme.StartPosition = FormStartPosition.Manual;
            editProblemCiktiDegerlendirme.FormClosing += delegate { this.Show(); };
            editProblemCiktiDegerlendirme.Show();
        }

        private void btnProblemCiktiDegerlendirmeSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemCiktiDegerlendirme.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemCiktiDegerlendirme WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemCiktiDegerlendirme();
                }
            }
        }
        #endregion
        #region Problem Durum Değerlendirme Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadProblemDurumDegerlendirme()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        K.YeniProblemTanimi,
			        K.YeniHedef,
			        L.HedeflenenAmacTanimi,
			        K.OncekiProblemSkoru,
			        K.TahminEdilenProblemSkoru,
			        M.KullaniciAdi,
			        K.DegerlendirmeTarihi
		        FROM
			        ProblemDurumDegerlendirme 		K
			        JOIN Problem					L	ON K.ProblemId 		= L.Id
			        JOIN Kullanici					M	ON K.KullaniciId 	= M.Id";

            var problemDurumDegerlendirmeDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "ProblemDurumDegerlendirme");

            dgProblemDurumDegerlendirme.DataSource = problemDurumDegerlendirmeDataSet.Tables[0];

            string[] headerAliases = { "#", "Yeni Problem Tanımı", "Yeni Hedef", "Hedeflenen Amaç Tanımı", "Önceki Problem Skoru", "Tahmin Edilen Problem Skoru", "Değerlendirme Kullanıcı", "Değerlendirme Tarihi" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgProblemDurumDegerlendirme.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgProblemDurumDegerlendirme_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgProblemDurumDegerlendirme.SelectedRows;
            if (selected.Count == 1)
            {
                btnProblemDurumDegerlendirmeEkle.Text = "Güncelle";
            }
            else
            {
                btnProblemDurumDegerlendirmeEkle.Text = "Ekle";
            }
        }

        private void btnProblemDurumDegerlendirmeEkle_Click(object sender, EventArgs e)
        {
            int? problemDurumDegerlendirmeId = null;

            var selected = dgProblemDurumDegerlendirme.SelectedRows;
            if (selected.Count == 1)
            {
                problemDurumDegerlendirmeId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editProblemDurumDegerlendirme = new EditProblemDurumDegerlendirme(this, problemDurumDegerlendirmeId);
            editProblemDurumDegerlendirme.Location = this.Location;
            editProblemDurumDegerlendirme.StartPosition = FormStartPosition.Manual;
            editProblemDurumDegerlendirme.FormClosing += delegate { this.Show(); };
            editProblemDurumDegerlendirme.Show();
        }

        private void btnProblemDurumDegerlendirmeSil_Click(object sender, EventArgs e)
        {
            var selected = dgProblemDurumDegerlendirme.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM ProblemDurumDegerlendirme WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadProblemDurumDegerlendirme();
                }
            }
        }
        #endregion
        #region Çalışan Problem Panel
        /// <summary>
        /// 
        /// </summary>
        public void LoadCalisanProblem()
        {
            string sqlCommand = @"
		        SELECT 
			        K.Id,
			        L.AlanAdi,
			        M.SinifAdi,
			        N.MudahaleAdi,
			        O.AktiviteTanimi,
			        P.KullaniciAdi,
			        R.HedeflenenAmacTanimi,
                    K.AktiviteAciklama,
                    K.Tarih
		        FROM
			        CalisanProblem 		K
			        JOIN Alan			L	ON K.AlanId 		= L.Id
			        JOIN Sinif			M	ON K.SinifId 		= M.Id 
			        JOIN Mudahale		N	ON K.MudahaleId 	= N.Id 
			        JOIN Aktivite		O	ON K.AktiviteId 	= O.Id
			        JOIN Kullanici		P	ON K.KullaniciId 	= P.Id
			        JOIN Problem		R	ON K.ProblemId 		= R.Id";

            var calisanProblemDataSet = _operation.GetDataSet(_connectionString, sqlCommand, "CalisanProblem");

            dgCalisanProblem.DataSource = calisanProblemDataSet.Tables[0];

            string[] headerAliases = { "#", "Alan", "Sınıf", "Müdahale", "Aktivite Tanımı", "Kullanıcı", "Hedeflenen Amaç Tanımı", "Aktivite Açıklama", "Tarih" };

            for (int i = 0; i < headerAliases.Length; i++)
            {
                dgCalisanProblem.Columns[i].HeaderText = headerAliases[i];
            }
        }

        private void dgCalisanProblem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var selected = dgCalisanProblem.SelectedRows;
            if (selected.Count == 1)
            {
                btnCalisanProblemEkle.Text = "Güncelle";
            }
            else
            {
                btnCalisanProblemEkle.Text = "Ekle";
            }
        }

        private void btnCalisanProblemEkle_Click(object sender, EventArgs e)
        {
            int? calisanProblemId = null;

            var selected = dgCalisanProblem.SelectedRows;
            if (selected.Count == 1)
            {
                calisanProblemId = Convert.ToInt32(selected[0].Cells[0].Value);
            }

            var editCalisanProblem = new EditCalisanProblem(this, calisanProblemId);
            editCalisanProblem.Location = this.Location;
            editCalisanProblem.StartPosition = FormStartPosition.Manual;
            editCalisanProblem.FormClosing += delegate { this.Show(); };
            editCalisanProblem.Show();
        }

        private void btnCalisanProblemSil_Click(object sender, EventArgs e)
        {
            var selected = dgCalisanProblem.SelectedRows;
            if (selected.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçtiğiniz kayıtlar silinecetir, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel);
                if (((int)dialogResult) == 1)
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        var current = selected[i].Cells[0].Value;
                        string sqlCommand = "DELETE FROM CalisanProblem WHERE Id = {0}";
                        sqlCommand = string.Format(sqlCommand, current);
                        _operation.Delete(_connectionString, sqlCommand);
                    }

                    this.LoadCalisanProblem();
                }
            }
        }
        #endregion
    }
}
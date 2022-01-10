using Common;
using Domain;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FrmKlijent : Form
    {
        List<Poruka> poruke = new List<Poruka>();
        public FrmKlijent()
        {
            InitializeComponent();
            InitListener();
            lblPorukeKorisnika.Visible = false;
            dgvPorukeKorisnika.Visible = false;

            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            //timer.Interval = 2000;
            //timer.Tick += Tick;
            //timer.Start();
        }

        //private void Tick(object sender, EventArgs e)
        //{
        //    KlijentPoruka zahtev = new KlijentPoruka
        //    {
        //        Operacija = Operacija.VratiUlogovaneKorisnike
        //    };
        //    Komunikacija.Instance.PosaljiPoruku(zahtev); 
        //}

        private void RasporediPoruke()
        {
            if (poruke.Count > 3)
            {
                poruke.Reverse();
                dgvPoslednje3Poruke.DataSource = new BindingList<Poruka>(poruke.Take(3).ToList());
                dgvOstalePoruke.DataSource = new BindingList<Poruka>(poruke.Skip(3).ToList());

                dgvPoslednje3Poruke.Columns["Primio"].Visible = false;
                dgvOstalePoruke.Columns["Primio"].Visible = false;

                dgvPoslednje3Poruke.Columns["VremeSlanja"].Visible = false;
                dgvOstalePoruke.Columns["VremeSlanja"].Visible = false;
            }
            else
            {
                poruke.Reverse();
                dgvPoslednje3Poruke.DataSource = new BindingList<Poruka>(poruke);

                dgvPoslednje3Poruke.Columns["Primio"].Visible = false;
                dgvPoslednje3Poruke.Columns["VremeSlanja"].Visible = false;

                
            }
            
        }

        private void InitListener()
        {
            Thread nit = new Thread(CitajPoruke);
            nit.IsBackground = true;
            nit.Start();
        }

        private void CitajPoruke()
        {
            bool kraj = false;
            try
            {
                while (!kraj)
                {
                    ServerPoruka porukaServera = Komunikacija.Instance.ProcitajPorukuOdServera();

                    switch (porukaServera.Operacija)
                    {
                        case Operacija.PosaljiSvima:
                            Invoke(new Action(() =>
                            {
                                poruke.Add((Poruka)porukaServera.Objekat);
                                RasporediPoruke();
                            }));
                            break;
                        case Operacija.PosaljiJednom:
                            Invoke(new Action(() =>
                            {
                                poruke.Add((Poruka)porukaServera.Objekat);
                                RasporediPoruke();
                            }));
                            break;
                        case Operacija.VratiUlogovaneKorisnike:
                            List<Korisnik> klijenti = (List<Korisnik>)porukaServera.Objekat;
                            Invoke(new Action(() =>
                            {
                                dgvPrijavljeniKorisnici.DataSource = new BindingList<Korisnik>(klijenti);
                                dgvPrijavljeniKorisnici.Columns["Sifra"].Visible = false;
                            }));
                            break;
                        case Operacija.Kraj:
                            Kraj();
                            kraj = true;
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Kraj()
        {
            KlijentPoruka zahtev = new KlijentPoruka { Operacija = Operacija.Kraj };
            Komunikacija.Instance.PosaljiPoruku(zahtev);
            Invoke(new Action(Close));
        }

        private void btnPosaljiSvima_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                TekstPoruke = rtbPoruka.Text,
                TipSlanja = TipSlanja.Svima
            };

            KlijentPoruka zahtev = new KlijentPoruka
            {
                Operacija = Operacija.PosaljiSvima,
                Objekat = poruka
            };

            Komunikacija.Instance.PosaljiPoruku(zahtev);
            rtbPoruka.Text = "";
        }

        private void btnPosaljiJednom_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrijavljeniKorisnici.SelectedRows[0] == null)
                {
                    return;
                }

                Korisnik primaoc = (Korisnik)dgvPrijavljeniKorisnici.SelectedRows[0].DataBoundItem;

                Poruka poruka = new Poruka
                {
                    TekstPoruke = rtbPoruka.Text,
                    TipSlanja = TipSlanja.Samo_njemu,
                    Primio = primaoc
                };

                KlijentPoruka zahtev = new KlijentPoruka
                {
                    Objekat = poruka,
                    Operacija = Operacija.PosaljiJednom
                };

                Komunikacija.Instance.PosaljiPoruku(zahtev);
                rtbPoruka.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Greska pri izboru korisnika, pokusajte opet");
                rtbPoruka.Text = "";
            }
        }

        private void btnPrikaziPoruke_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrijavljeniKorisnici.SelectedRows[0] == null)
                {
                    return;
                }

                BindingList<Poruka> porukePosiljaoca;

                Korisnik posiljalac = (Korisnik)dgvPrijavljeniKorisnici.SelectedRows[0].DataBoundItem;

                porukePosiljaoca = new BindingList<Poruka>(poruke.Where(poruka => poruka.Poslao.Email == posiljalac.Email && poruka.Poslao.Sifra == posiljalac.Sifra).ToList());

                dgvPorukeKorisnika.Visible = true;
                lblPorukeKorisnika.Visible = true;

                dgvPorukeKorisnika.DataSource = porukePosiljaoca;

                dgvPorukeKorisnika.Columns["Primio"].Visible = false;
                dgvPorukeKorisnika.Columns["Poslao"].Visible = false;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Greska pri izboru korisnika, pokusajte opet");
            }
        }

        //private void dgvPorukeKorisnika_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if(dgvPorukeKorisnika.SelectedCells[0].OwningColumn.Name == "TekstPoruke")
        //    {
        //        dgvPorukeKorisnika.Columns["TekstPoruke"].Visible = false;
        //    }
        //}
    }
}

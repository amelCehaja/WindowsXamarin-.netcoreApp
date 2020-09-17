﻿using Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinUI.Izvjestaji
{
    public partial class frmIzvjestajClanovi : Form
    {
        private readonly APIService _clanarinaService = new APIService("clanarina");
        private readonly APIService _prisutnostService = new APIService("prisutnostclana");
        public frmIzvjestajClanovi()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Model.IzvjestajClanovi izvjestajClanovi = new Model.IzvjestajClanovi
            {
                clanarine = new List<Model.Clanarina>(),
                Dani = new Model.Dani
                {
                    Ponedeljak = 0,
                    Cetvrtak = 0,
                    Nedelja = 0,
                    Petak = 0,
                    Srijeda = 0,
                    Subota = 0,
                    Utorak = 0
                }
            };
            ClanarinaSearchRequest clanarinaSearch = new ClanarinaSearchRequest
            {
                Od = dateTimePicker1.Value,
                Do = dateTimePicker2.Value
            };
            List<Model.Clanarina> clanarine = await _clanarinaService.Get<List<Model.Clanarina>>(clanarinaSearch);
            foreach (var x in clanarine)
            {
                izvjestajClanovi.clanarine.Add(x);
            }

            dataGridView1.DataSource = izvjestajClanovi;
            PrisutnostClanaSearchRequest prisutnostClanaSearch = new PrisutnostClanaSearchRequest { Od = dateTimePicker1.Value, Do = dateTimePicker2.Value };
            List<Model.PrisutnostClana> prisutnostClana = await _prisutnostService.Get<List<Model.PrisutnostClana>>(prisutnostClanaSearch);
            foreach (var x in prisutnostClana)
            {
                switch (x.Datum.DayOfWeek.ToString())
                {
                    case "Monday":
                        izvjestajClanovi.Dani.Ponedeljak++;
                        break;
                    case "Tuesday":
                        izvjestajClanovi.Dani.Utorak++;
                        break;
                    case "Wendsday":
                        izvjestajClanovi.Dani.Srijeda++;
                        break;
                    case "Thursday":
                        izvjestajClanovi.Dani.Cetvrtak++;
                        break;
                    case "Friday":
                        izvjestajClanovi.Dani.Petak++;
                        break;
                    case "Saturday":
                        izvjestajClanovi.Dani.Subota++;
                        break;
                    case "Sunday":
                        izvjestajClanovi.Dani.Nedelja++;
                        break;
                    default:
                        break;
                }
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = clanarine;
            txtPon.Text = izvjestajClanovi.Dani.Ponedeljak.ToString();
            txtUto.Text = izvjestajClanovi.Dani.Utorak.ToString();
            txtSri.Text = izvjestajClanovi.Dani.Srijeda.ToString();
            txtCet.Text = izvjestajClanovi.Dani.Cetvrtak.ToString();
            txtPet.Text = izvjestajClanovi.Dani.Petak.ToString();
            txtSub.Text = izvjestajClanovi.Dani.Srijeda.ToString();
            txtNed.Text = izvjestajClanovi.Dani.Nedelja.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

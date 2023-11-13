using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static modelo2.Form1;

namespace modelo2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public REPARACION[] frm2Reparaciones { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
              // cargar los items en el primer control combobox
            cmbDispositivo.Items.Clear();
            cmbDispositivo.Items.Add("Smartphone");
            cmbDispositivo.Items.Add("Tablet");
            cmbDispositivo.Items.Add("Consola de VideoJuego");
            cmbDispositivo.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int i = frm2Reparaciones.Length;
            grReparaciones.Rows.Clear();

            switch (cmbDispositivo.SelectedIndex)
            {
                case -1:
                    for (int j = 0; j < i; j++)
                    {
                        grReparaciones.Rows.Add(frm2Reparaciones[j].Cliente.ToString(),
                        frm2Reparaciones[j].Dispositivo,
                        frm2Reparaciones[j].Reparacion,
                        frm2Reparaciones[j].Pago.ToString(),
                        frm2Reparaciones[j].Importe.ToString()
                        );
                        switch (grReparaciones.Rows[j].Cells[3].Value)
                        {
                            case "1":
                                grReparaciones.Rows[j].Cells[3].Value = "Contado";
                                break;
                            case "2":
                                grReparaciones.Rows[j].Cells[3].Value = "Credito";
                                break;
                        }


                    }
                    break;
                case 0:
                    for (int j = 0; j < i; j++)
                    {
                        if (frm2Reparaciones[j].Dispositivo == "Smartphone")
                        {
                            grReparaciones.Rows.Add(
                                frm2Reparaciones[j].Cliente.ToString(),
                                 frm2Reparaciones[j].Dispositivo,
                                 frm2Reparaciones[j].Reparacion,
                                 frm2Reparaciones[j].Pago.ToString(),
                                 frm2Reparaciones[j].Importe.ToString()
                                 );
                            switch (grReparaciones.Rows[j].Cells[3].Value)
                            {
                                case "1":
                                    grReparaciones.Rows[j].Cells[3].Value = "Contado";
                                    break;
                                case "2":
                                    grReparaciones.Rows[j].Cells[3].Value = "Credito";
                                    break;
                            }
                        }


                    }
                    break;

                case 1:
                    for (int j = 0; j < i; j++)
                    {
                        if (frm2Reparaciones[j].Dispositivo == "Tablet")
                        {
                            grReparaciones.Rows.Add(
                            frm2Reparaciones[j].Cliente.ToString(),
                             frm2Reparaciones[j].Dispositivo,
                             frm2Reparaciones[j].Reparacion,
                             frm2Reparaciones[j].Pago.ToString(),
                             frm2Reparaciones[j].Importe.ToString()
                            );

                            switch (grReparaciones.Rows[j].Cells[3].Value)
                            {
                                case "1":
                                    grReparaciones.Rows[j].Cells[3].Value = "Contado";
                                    break;
                                case "2":
                                    grReparaciones.Rows[j].Cells[3].Value = "Credito";
                                    break;
                            }
                        }


                    }
                    break;

                case 2:
                    for (int j = 0; j < i; j++)
                    {
                        if (frm2Reparaciones[j].Dispositivo == "Consola de VideoJuego")
                        {
                            grReparaciones.Rows.Add(
                                frm2Reparaciones[j].Cliente.ToString(),
                                 frm2Reparaciones[j].Dispositivo,
                                 frm2Reparaciones[j].Reparacion,
                                 frm2Reparaciones[j].Pago.ToString(),
                                 frm2Reparaciones[j].Importe.ToString()
                                );
                            switch (grReparaciones.Rows[j].Cells[3].Value)
                            {
                                case "1":
                                    grReparaciones.Rows[j].Cells[3].Value = "Contado";
                                    break;
                                case "2":
                                    grReparaciones.Rows[j].Cells[3].Value = "Credito";
                                    break;
                            }
                        }

                    }
                    break;

            }
        }
    }
}

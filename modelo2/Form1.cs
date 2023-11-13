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
    public partial class Form1 : Form
    {
        // declaraciones para el formulario
        public struct REPARACION
        {
            public string Cliente;
            public string Dispositivo;
            public string Reparacion;
            public int FormaPago;
            public float Importe;
        };

        float precio = 0; 
        // declaramos arreglo 
        const int MAX = 5;
        REPARACION[] reparacion;
        int pos; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            btnRegistrar.Enabled = false;   
            txtCliente.Text = "";
            

            // combos
            cmbDispositivo.Items.Clear();
            cmbDispositivo.Items.Add("Smartphone");
            cmbDispositivo.Items.Add("Tablet");
            cmbDispositivo.Items.Add("Consola de Videojuego");
            cmbDispositivo.SelectedIndex = 0;
            //
            cmbReparación.Items.Clear();
            cmbReparación.Items.Add("Pantalla");
            cmbReparación.Items.Add("Teclado");
            cmbReparación.Items.Add("Sistema Operativo");
            cmbReparación.SelectedIndex = 0;
            btnRegistrar.Enabled = false;
            //
            cmbConsulta.Items.Clear();
            cmbConsulta.Items.Add("");
            cmbConsulta.Items.Add("Smartphone");
            cmbConsulta.Items.Add("Tablet");
            cmbConsulta.Items.Add("Consola de Videojuego");
            cmbConsulta.SelectedIndex = -1;

            cmbForma.Items.Clear();
            cmbForma.Items.Add("Contado");
            cmbForma.Items.Add("Credito");
            cmbForma.SelectedIndex = 0;

            //creamos el arreglo

            reparacion = new REPARACION[MAX];
            pos = 0; 

            //limpiamos grilla 
            dgvDatos.Rows.Clear();  

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtTotal.Text = "";
            optContado.Checked = true; 
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            float porcentajes = 0;
            validarDatos(); 
            switch (cmbDispositivo.SelectedIndex)
            {

                case 0: 
                    precio = 2500; 
                    break;

                case 1:
                    precio = 1500;
                    break;

                case 2:
                    precio = 1000;
                    break;
            }

            switch (cmbReparación.SelectedIndex)
            {
                case 0:
                    precio = precio + 1000;
                    break;
                case 1:
                    precio = precio + 1500;
                    break;
                case 2:
                    precio = precio + 2000;
                    break;
            }



            if (optContado.Checked)
            {
                porcentajes = precio * 20 / 100;
                precio = precio - porcentajes;


            }
            else
            {
                porcentajes = precio * 10 / 100;
                precio = precio + porcentajes;
            }
            txtTotal.Text = precio.ToString();
            btnRegistrar.Enabled = true; 
        }

        private void validarDatos()
        {

            if (txtCliente.Text.Length < 3)
            {
                MessageBox.Show("Debe ser nombre mas largo"); 
            }


        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

           
            if (txtCliente.Text != " ")
            {

                reparacion[pos].Cliente = txtCliente.Text;
                reparacion[pos].Reparacion= cmbReparación.Text;
                reparacion[pos].Dispositivo= cmbDispositivo.Text;
                reparacion[pos].Importe = precio;
                if (optContado.Checked)
                {
                    reparacion[pos].FormaPago = 1;
                }
                else
                {
                    reparacion[pos].FormaPago = 2;
                }
                pos++;


                if (pos>MAX)
                {
                    MessageBox.Show("COMPLETO");
                    btnRegistrar.Enabled = false;
                }

                btnRegistrar.Enabled = false;
                txtCliente.Text = "";
                

            }

           





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
           // if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) solo numeros  
           if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8)) //solo letras
            {
                MessageBox.Show("Solo se permiten letras"); 
                e.Handled = true;
                return;
            }

            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) solo numeros
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

            dgvDatos.Rows.Clear(); // Borra el DataGridView antes de agregar nuevas filas

            // Filtrar datos basados en el dispositivo seleccionado en cmbConsulta
            string dispositivoSeleccionado = cmbConsulta.Text;

            if (dispositivoSeleccionado == "") // Muestra todo si no se selecciona un dispositivo específico
            {
                for (int i = 0; i < pos; i++)
                {
                    dgvDatos.Rows.Add(reparacion[i].Cliente, 
                        reparacion[i].Dispositivo, 
                        reparacion[i].Reparacion,
                        reparacion[i].FormaPago == 1 ? "Contado" : "Crédito",
                        reparacion[i].Importe);
                }
            }
            else // Muestra datos para el dispositivo seleccionado
            {
                for (int i = 0; i < pos; i++)
                {
                    if (reparacion[i].Dispositivo == dispositivoSeleccionado)
                    {
                        dgvDatos.Rows.Add(reparacion[i].Cliente,
                            reparacion[i].Dispositivo,
                            reparacion[i].Reparacion,
                            reparacion[i].FormaPago == 1 ? "Contado" : "Crédito",
                            reparacion[i].Importe);
                    }
                }
            }
        }
        //private void btnConsulta_Click(object sender, EventArgs e)
        //{
        //    Form2 frm = new Form2();
        //    frm.frm2Reparaciones = reparaciones;
        //    frm.Show();
        //}
    }
}



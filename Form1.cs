using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioTriangulo_19881837
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Data.OleDb.OleDbConnection conBD = new System.Data.OleDb.OleDbConnection();
        String sAccion = "";

        public void abrirConexion()
        {
            // Se crea el string de conexión a la base de datos

            conBD.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\MINEDUCYT\Documents\Triangulos.accdb;Persist Security Info=False";
            try

            {
                // Se abre la base de datos

                conBD.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Error real!: " + ex.Message);
            }
        }
        public void cerrarConexion()
        {
            // Se chequea si está la conexión abierta
            if (conBD.State == ConnectionState.Open)
            {
                // Se cierra la conexión
                conBD.Close();
            }
        }
        private void desactivarAcciones()
        {
            btnConsulta.Enabled = false;
            btnAlta.Enabled = false;
            btnBaja.Enabled = false;
            btnModificacion.Enabled = false;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        private void activarAcciones()
        {
            btnConsulta.Enabled = true;
            btnAlta.Enabled = true;
            btnBaja.Enabled = true;
            btnModificacion.Enabled = true;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            // Se cancela la acción a realizar
            sAccion = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturamos los tres lados de los TextBox
                double a = Convert.ToDouble(txtLadoA.Text);
                double b = Convert.ToDouble(txtLadoB.Text);
                double c = Convert.ToDouble(txtLadoC.Text);

                // 2. Calculamos primero el semiperímetro (s)
                double s = (a + b + c) / 2;

                // 3. Calculamos el área usando la fórmula de Herón
                // Math.Sqrt es para la raíz cuadrada
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                // 4. Mostramos los resultados
                txtSemiperimetro.Text = s.ToString();
                txtArea.Text = area.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Asegúrate de llenar los tres lados con números.");
            }

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            // Se indica la acción que hay que realizar
            sAccion = "Consulta";
            // Se activan y desactivan los botones correspondientes
            desactivarAcciones();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Se cierra la conexión antes de terminar
            cerrarConexion();
            // Se finaliza el programa
            this.Close();

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            // Se indica la acción que hay que realizar
            sAccion = "Alta";
            // Se activan y desactivan los botones correspondientes
            desactivarAcciones();

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            // Se indica la acción que hay que realizar
            sAccion = "Baja";
            // Se activan y desactivan los botones correspondientes
            desactivarAcciones();

        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            // Se indica la acción que hay que realizar
            sAccion = "Modificación";
            // Se activan y desactivan los botones correspondientes
            desactivarAcciones();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se activan y desactivan los botones correspondientes
            activarAcciones();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
        

        // Se termina la acción realizada
        sAccion = "";
                    // Se activan y desactivan los botones correspondientes
                    activarAcciones();
    } 

  

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Se cierra la conexión antes de terminar
            cerrarConexion();
            // Se finaliza el programa
            this.Close();

        }
    }
    }

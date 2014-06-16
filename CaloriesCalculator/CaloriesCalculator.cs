using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using System.Diagnostics;

namespace CaloriesCalculator
{
    public partial class CaloriesCalculator : Form
    {
        private Persona persona;
        private StringBuilder numsegsoc = new StringBuilder();
        private Formulario formulario;


        public CaloriesCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            clean();

            if (validarDatosDeEntrada())
            {

                if (rbtnMale.Checked)
                {
                    persona = new Hombre(Convert.ToDouble(txtCm.Text),
                                          Convert.ToDouble(txtPeso.Text),
                                          Convert.ToDouble(txtEdad.Text));

                }
                else
                {
                    persona = new Mujer(Convert.ToDouble(txtCm.Text),
                                        Convert.ToDouble(txtPeso.Text),
                                        Convert.ToDouble(txtEdad.Text));


                }
                txtCalories.Text = persona.calcularCalorias().ToString();
                txtPesoIdeal.Text = persona.pesoIdeal().ToString();
                txtDistance.Text = persona.DiferenciaPesoIdeal().ToString();

            }

        }

        private void clean()
        {
            txtDistance.Text = "";
            txtPesoIdeal.Text = "";
            txtCalories.Text = "";
        }
        private Boolean validarDatosDeEntrada()
        {
            double result;
            if (!double.TryParse(txtCm.Text, out result))
            {
                MessageBox.Show("Altura debe ser un valor numérico");
                txtCm.Select();
                return false;
            }


            if (!double.TryParse(txtPeso.Text, out result))
            {
                MessageBox.Show("Peso debe ser un valor numérico");
                txtPeso.Select();
                return false;
            }

            if (!double.TryParse(txtEdad.Text, out result))
            {
                MessageBox.Show("Edad debe ser un valor numérico");
                txtEdad.Select();
                return false;
            }
            if (!(Convert.ToDouble(txtCm.Text) >= 150))
            {
                MessageBox.Show("Altura mínima 150cm");
                txtCm.Select();
                return false;
            }
            return true;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatosPaciente() && validarDatosDeEntrada())
            {

                if (rbtnMale.Checked)
                {
                    persona = new Hombre(Convert.ToDouble(txtCm.Text),
                                          Convert.ToDouble(txtPeso.Text),
                                          Convert.ToDouble(txtEdad.Text),
                                          textBoxNSS1.Text+textBoxNSS2.Text+textBoxNSS3.Text,
                                          textBoxNombre.Text,
                                          textBoxApellido1.Text,
                                          textBoxApellido2.Text);

                }
                else
                {
                    persona = new Mujer(Convert.ToDouble(txtCm.Text),
                                          Convert.ToDouble(txtPeso.Text),
                                          Convert.ToDouble(txtEdad.Text),
                                          textBoxNSS1.Text + textBoxNSS2.Text + textBoxNSS3.Text,
                                          textBoxNombre.Text,
                                          textBoxApellido1.Text,
                                          textBoxApellido2.Text);
                }

                formulario = new Formulario(persona);

                MessageBox.Show(formulario.Documento.InnerXml);


            }
        }

        private Boolean validarDatosPaciente()
        {
            int result;
            if (!int.TryParse(textBoxNSS1.Text, out result) || (result <= 99 || result >= 1000))
            {
                MessageBox.Show("Introduzca los tres primeros numeros de su NSS");
                textBoxNSS1.Select();
                return false;
            }
        

            if (!int.TryParse(textBoxNSS2.Text, out result) || (result <= 99 || result >= 1000))
            {
                MessageBox.Show("Introduzca los tres siguientes numeros de su NSS");
                textBoxNSS2.Select();
                return false;
            }
        

            if (!int.TryParse(textBoxNSS3.Text, out result) || (result <= 99 || result >= 1000))
            {
                MessageBox.Show("Introduzca los tres ultimos numeros de su NSS");
                textBoxNSS3.Select();
                return false;
            }
         

            if (textBoxNombre.Text.Trim().Length < 1)
            {
                MessageBox.Show("Nombre invalido");
                textBoxNombre.Select();
                return false;
            }
            else
            {
                if (!esletra(textBoxNombre.Text.ToString()))
                {
                    MessageBox.Show("El nombre tiene caracteres invalidos");
                    textBoxNombre.Select();
                    return false;
                }
            }

            if (textBoxApellido1.Text.Trim().Length < 1)
            {
                MessageBox.Show("Apellido invalido");
                textBoxApellido1.Select();
                return false;
            }
            else
            {
                if (!esletra(textBoxApellido1.Text.ToString()))
                {
                    MessageBox.Show("El Apellido1 tiene caracteres invalidos");
                    textBoxApellido1.Select();
                    return false;
                }
            }


            if ((textBoxApellido2.Text)!= "")
            {
                if (!esletra(textBoxApellido2.Text.ToString()))
                {
                    MessageBox.Show("El Apellido2 tiene caracteres invalidos");
                    textBoxApellido2.Select();
                    return false;
                }
            }
            return true;

        }
        private Boolean esletra(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        private void txtDistance_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            String path = "C:\\myFile.xml";
            if (File.Exists(path))
            {
                Process.Start("IExplore.exe", path);
            }
            else
            {
                MessageBox.Show("No existe nungun fichero XML. Debe guardar su información para poder visualizar el documento.");
            }


            
        }

        private void textBoxNSS1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}










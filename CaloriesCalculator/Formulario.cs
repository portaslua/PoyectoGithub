using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;

namespace CaloriesCalculator
{
    class Formulario
    {
        private String ubicacion = "C:\\myFile.xml";
        private XmlDocument documento;

        public XmlDocument Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        private Persona persona;
        Boolean FicheroExiste;
        private int pos_paciente_XML;


        public Formulario(Persona p)
        {
            this.persona = p;
            documento = new XmlDocument();
            ComprobarExistenciaFichero();

            documento.Save(ubicacion);
           


        }

        private void ComprobarExistenciaFichero()
        {
            try
            {
                documento.Load(ubicacion);
                FicheroExiste = true;
            }
            catch (FileNotFoundException)
            {
                FicheroExiste = false;
            }

            if (FicheroExiste == false)
            {
                CrearNuevoFormulario();

            }
            else
            {
                if (ExistePaciente())
                {
                  pos_paciente_XML = BuscarPaciente();
                  neomedida(pos_paciente_XML);
                }
                else
                    nuevopaciente();
            }
        }

        private void CrearNuevoFormulario()
        {
            documento.LoadXml(
            "<HistorialPacientes>" +
              "<paciente NSS=\"" + persona.NumeroSeguridadSocial + "\"" +
              " Nombre=\"" + persona.Nombre + "\"" +
              " Apellido1=\"" + persona.Apellido1 + "\"" +
              " Apellido2=\"" + persona.Apellido2 + "\"" + ">" +
              "<medidas fecha=\"" + DateTime.Now + "\"" + ">" +
              "<altura>" + persona.Altura + "</altura>" +
              "<peso>" + persona.Peso + "</peso>" +
              "<edad>" + persona.Edad + "</edad>" +
              "<CaloriasDiarias>" + persona.calcularCalorias() + "</CaloriasDiarias>" +
              "<PesoIdeal>" + persona.pesoIdeal() + "</PesoIdeal>" +
              "<DiferenciaPesoIdeal>" + persona.DiferenciaPesoIdeal() + "</DiferenciaPesoIdeal>" +
              "</medidas>" +
              "</paciente>" +
              "</HistorialPacientes>");
        }
        public int BuscarPaciente()
        {
      
            for (int i = 0; i < documento.SelectNodes("/HistorialPacientes/paciente").Count; i++)
            {
             XmlNode nodo = documento.SelectNodes("/HistorialPacientes/paciente")[i];
             if (nodo.Attributes["NSS"].Value.ToString() == persona.NumeroSeguridadSocial)
                {
                    return i;
                }
            }
            return -1;

        }

        public Boolean ExistePaciente()
        {

            for (int i = 0; i < documento.SelectNodes("/HistorialPacientes/paciente").Count; i++)
            {
                XmlNode nodo = documento.SelectNodes("/HistorialPacientes/paciente")[i];
                if (nodo.Attributes["NSS"].Value.ToString() == persona.NumeroSeguridadSocial)
                {
                    return true;
                }
            }
            return false;

        }


        public void neomedida(int pos)
        {
            XmlNode nuevamedida = documento.SelectNodes("/HistorialPacientes/paciente")[pos].FirstChild.CloneNode(true);
            AsignarMedidasPaciente(nuevamedida);
            documento.SelectNodes("/HistorialPacientes/paciente")[pos].AppendChild(nuevamedida);



        }

        private void AsignarMedidasPaciente(XmlNode nuevamedida)
        {
            nuevamedida.Attributes["fecha"].Value = DateTime.Now.ToString();
            nuevamedida["altura"].FirstChild.Value = persona.Altura.ToString();
            nuevamedida["peso"].FirstChild.Value = persona.Peso.ToString();
            nuevamedida["edad"].FirstChild.Value = persona.Edad.ToString();
            nuevamedida["CaloriasDiarias"].FirstChild.Value = persona.calcularCalorias().ToString();
            nuevamedida["PesoIdeal"].FirstChild.Value = persona.pesoIdeal().ToString();
            nuevamedida["DiferenciaPesoIdeal"].FirstChild.Value = persona.DiferenciaPesoIdeal().ToString();
        }



        public void nuevopaciente()
        {
            XmlNode neopaciente = documento.SelectNodes("/HistorialPacientes/paciente")[0].CloneNode(false);
            neopaciente.Attributes["NSS"].Value = persona.NumeroSeguridadSocial.ToString();
            neopaciente.Attributes["Nombre"].Value = persona.Nombre.ToString();
            neopaciente.Attributes["Apellido1"].Value = persona.Apellido1.ToString();
            XmlNode medidas = documento.SelectNodes("/HistorialPacientes/paciente/medidas")[0].CloneNode(true);
            AsignarMedidasPaciente(medidas);
            neopaciente.AppendChild(medidas);
            documento.SelectNodes("/HistorialPacientes")[0].AppendChild(neopaciente);

        }
        

    }

}

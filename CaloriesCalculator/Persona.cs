using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriesCalculator
{
     abstract class Persona
    {

        public static double CmToInch = 1 / 2.54;
        public static double InchToCm = 2.54;
        public static double KgToLib = 0.45359237;
        public static double LibToKg = 2.20462262;

        private double altura;

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private double edad;

        public double Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        //parte nueva
        private string numeroSeguridadSocial;

        public string NumeroSeguridadSocial
        {
            get { return numeroSeguridadSocial; }
            set { numeroSeguridadSocial = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido1;

        public string Apellido1
        {
            get { return apellido1; }
            set { apellido1 = value; }
        }
        private string apellido2;

        public string Apellido2
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }
    
        //parte nueva
        public Persona(double altura, double peso, double edad)
        {
            this.altura = altura;
            this.peso = peso;
            this.edad = edad;
        }
        public Persona(double altura, double peso, double edad, string numeroSeguridadSocial, string nombre, string apellido1, string apellido2)
        {
            this.altura = altura;
            this.peso = peso;
            this.edad = edad;
            this.numeroSeguridadSocial = numeroSeguridadSocial;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            
        }
        public double DiferenciaPesoIdeal()
        {
            return (peso - pesoIdeal());
        }
        public abstract double calcularCalorias();
        public abstract double pesoIdeal();
      
    }
}



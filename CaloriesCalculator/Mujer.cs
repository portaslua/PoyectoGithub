using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriesCalculator
{
    class Mujer : Persona
    {
        public Mujer(double altura, double peso, double edad)
            : base(altura, peso, edad)
        {
        }
        public Mujer(double altura, double peso, double edad, string numeroSeguridadSocial, string nombre, string apellido1, string apellido2)
            : base(altura, peso, edad, numeroSeguridadSocial, nombre, apellido1, apellido2)
        {
        }
        public override double calcularCalorias()
        {
            return (655 + (4.3 * KgToLib * Peso)
                         + (4.7 * CmToInch * Altura)
                         - (4.7 * Edad));
        }
        public override double pesoIdeal()
        {
            return (KgToLib * 2.2046 * (50 + 2.3 * (Altura * CmToInch - 5 * 12)));
        }
    }
}

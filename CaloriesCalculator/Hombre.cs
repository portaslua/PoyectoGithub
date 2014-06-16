using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriesCalculator
{
    class Hombre : Persona
    {
        public Hombre(double altura, double peso, double edad)
            : base(altura, peso, edad)
        {
        }
        public Hombre(double altura, double peso, double edad, string numeroSeguridadSocial, string nombre, string apellido1, string apellido2)
            : base(altura, peso, edad, numeroSeguridadSocial, nombre, apellido1, apellido2)
        {
        }
        public override double calcularCalorias()
        {
            return (66 + (6.3 * KgToLib * Peso)
                       + (12.9 * CmToInch * Altura)
                       - (6.8 * Edad));
        }
        public override double pesoIdeal()
        {
            return KgToLib * 2.2046 * (50 + 2.3 * (Altura * CmToInch - 5 * 12));
        }
    }
}

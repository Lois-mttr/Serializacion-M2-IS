using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionJSON
{
    [Serializable]

    internal class InformacionSeria
    {
        private int cuenta;
        private string nombre;
        private string apellido;
        private decimal saldo;

        public InformacionSeria (int count, string nomber, string lastname, decimal price)
        {
            Cuenta = count;
            Nombre = nomber;
            Apellido = lastname;
            Saldo = price;
        }

        public int Cuenta { get => cuenta; set => cuenta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }
    }
}

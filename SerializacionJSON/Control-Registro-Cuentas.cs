using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SerializacionJSON
{

    [Serializable]
    internal class Control_Registro_Cuentas
    {
        List<InformacionSeria> registro = new ();

        public void addCount(InformacionSeria persona)
        {
            if (persona != null)
            {
                registro.Add(persona);
            }
        }

        public override string ToString()
        {
            string texto = "Registros.... " + "\n";

            foreach(InformacionSeria Cpersonas in registro)
            {
                texto += "--------------------------------------" + "\n";
                texto += "Cuenta: " + Cpersonas.Cuenta + "\n";
                texto += "Nombre: " + Cpersonas.Nombre + "\n";
                texto += "Apellido: " + Cpersonas.Apellido + "\n";
                texto += "Saldo: " + Cpersonas.Saldo + "\n";
                texto += "--------------------------------------" + "\n";
                Console.WriteLine("\n");
            }

            return texto;
        }
    }
}

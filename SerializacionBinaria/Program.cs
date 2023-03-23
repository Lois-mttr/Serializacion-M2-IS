
using System.Runtime.Serialization.Formatters.Binary;

Console.WriteLine("Serealizacion Binaria en c#\r");
Console.WriteLine("---------------------------\n");

BinaryFormatter formateador = new BinaryFormatter();

Stream stream = null;
RegistroSerializable registro = null;
int cuenta;
string valorCuenta = "";
string nombre = "";
string apellido = "";
decimal saldo = 0.0M;
string valorSaldo = "";

//Elija el usuario

Console.WriteLine("Elija una opcion de la siguiente lista: ");
Console.WriteLine("\ts - Crear y serealizar registro ");
Console.WriteLine("\td - deserealizar registro ");
Console.WriteLine("¿Su opcion? ");

string op = Console.ReadLine();

switch (op)
{

    case "s":
        stream = new FileStream("clientes.txt", FileMode.OpenOrCreate, FileAccess.Write);

        Console.Write("Ecriba el numero de cuenta y luego presione Enter: ");
        valorCuenta = Console.ReadLine();

        while (!int.TryParse(valorCuenta, out cuenta))
        {
            Console.Write("Esta entrada no es valida. Introduzca un valor entero:  ");
            valorCuenta = Console.ReadLine();
        }


        //pida al usuario que escriba el primer nombre 
        Console.Write("EScriba el primer nombre y luego presione Enter: ");
        nombre = Console.ReadLine();


        //pida al usuario que ingrese el apellido paterno 
        Console.Write("Escriba el apellido paterno y luego presione Enter: ");
        apellido = Console.ReadLine();


        //pida al usuario que escriba el valor del saldo 
        Console.Write("Escriba el valor del saldo y luego presione Enter: ");
        valorSaldo = Console.ReadLine();

        while (!decimal.TryParse(valorSaldo, out saldo))
        {
            Console.Write("Esta entrada no es valida. Introduzca un valor entero:  ");
            valorSaldo = Console.ReadLine();
        }

        registro = new RegistroSerializable(cuenta, nombre, apellido, saldo);
        Console.WriteLine("\n");
        Console.WriteLine("Registro a serealizar");
        Console.WriteLine(registro.ToString());

        //Empezamos la serealizacion 
        Console.WriteLine("-------------------- Serializamos -------------------- ");
        //serealizamos

        formateador.Serialize(stream, registro);

        //cerramos el stream 
        stream.Close();


        break;

    case "d":

        //deserealizamos el objeto 

        Console.WriteLine("--------------- Deserializamos ---------------");
        // abrimos el stream 

        stream = new FileStream("clientes.txt", FileMode.Open, FileAccess.Read);

        //deserealizamos 
        registro = (RegistroSerializable)formateador.Deserialize(stream);

        //cerramos el stream

        stream.Close();


        //uamos el onjeto que serealizamos 

        Console.WriteLine("El registro deserializado es:  ");
        Console.WriteLine(registro.ToString());






        break;

    default:
        Console.WriteLine("Opcion invalida");

        break;
}





[Serializable]

public class RegistroSerializable
{


    private int cuenta;
    private string primerNombre;
    private string apellidoPaterno;
    private decimal saldo;

    public RegistroSerializable() : this(0, "", "", 0.0M)
    {

    }

    public RegistroSerializable(int valorCuenta, string valorPrimerNombre,
        string valorApellidoPaterno, decimal valorSaldo)
    {
        Cuenta = valorCuenta;
        PrimerNombre = valorPrimerNombre;
        ApellidoPaterno = valorApellidoPaterno;
        Saldo = valorSaldo;
    }

    public int Cuenta { get => cuenta; set => cuenta = value; }
    public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
    public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
    public decimal Saldo { get => saldo; set => saldo = value; }

    public override string ToString()
    {
        return "Cuenta: "+cuenta+"\n" + "Nombre: " + primerNombre +"\n " + "Apellido: "+ apellidoPaterno + "\n "+ "Saldo: "+ saldo +"\n";
    }

}
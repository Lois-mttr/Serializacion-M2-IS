using System.Xml.Serialization;

Console.WriteLine("Serealizacion XML en c#\r");
Console.WriteLine("---------------------------\n");

XmlSerializer formateador = new XmlSerializer(typeof(RegistroSerializable));
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
        stream = new FileStream("clientes.xml", FileMode.OpenOrCreate, FileAccess.Write);

        Console.Write("Ecriba el numero de la cuenta y luego presione Enter: ");
        valorCuenta = Console.ReadLine();

        while(!int.TryParse(valorCuenta, out cuenta))
        {

            Console.WriteLine("No es una entrada valida, introduzca un valor entero: ");
            valorCuenta = Console.ReadLine();

        }
        

        //pida al usuario que escriba el primer nombre 
        Console.Write("Escriba el primer nombre y luego presione Enter: ");
        nombre = Console.ReadLine();


        //pida al usuario que ingrese el apellido paterno 
        Console.Write("Escriba el apellido paterno y luego presione Enter: ");
        apellido = Console.ReadLine();


        //pida al usuario que escriba el valor del saldo 
        Console.Write("Escriba el valor del saldo y luego presione Enter: ");
        valorSaldo = Console.ReadLine();

        while (!decimal.TryParse(valorSaldo, out saldo))
        {

            Console.WriteLine("No es una entrada valida, introduzca un valor decimal: ");
            valorSaldo = Console.ReadLine();

        }


        registro = new RegistroSerializable(cuenta, nombre, apellido, saldo);
        Console.WriteLine("\n");
        Console.WriteLine("Registro a serealizar");
        Console.WriteLine(registro.ToString());

        //Empezamos la serealizacion 
        Console.WriteLine("-------------------- Serealizamos -------------------- ");
        //serealizamos

        formateador.Serialize(stream, registro);

        //cerramos el stream 
        stream.Close();


        break;

    case "d":

        //deserealizamos el objeto 

        Console.WriteLine("--------------- Deserializamos ---------------");
        // abrimos el stream 

        stream = new FileStream("clientes.xml", FileMode.Open, FileAccess.Read);

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


    private int Cuenta;
    private string Nombre;
    private string Apellido;
    private decimal Saldo;

    public RegistroSerializable()
    {

    }
    public RegistroSerializable(int cuenta, string nombre,
        string apellido , decimal  saldo)
    {

        Cuenta1 = cuenta;
        Nombre1 = nombre;
        Apellido1 = apellido;
        Saldo1 = saldo;

    }

    public decimal Saldo1 { get => Saldo; set => Saldo = value; }
    public string Apellido1 { get => Apellido; set => Apellido = value; }
    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public int Cuenta1 { get => Cuenta; set => Cuenta = value; }

    public override string ToString()
    {
        return "Cuenta: " + Cuenta + "\n" + "Nombre: " + Nombre + "\n " + "Apellido: " + Apellido + "\n " + "Saldo: " + Saldo + "\n";
    }

}
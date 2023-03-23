using System.Xml.Serialization;

Console.WriteLine("Serealizacion XML en c#\r");
Console.WriteLine("---------------------------\n");

XmlSerializer formateador = new XmlSerializer(typeof(RegistroSerializable));
Stream stream = null;
RegistroSerializable registro = null;

string Chasis = "";
string Marca = "";
string Modelo = "";
string valorPrecio = "";
string valorAño = "";
decimal Precio = 0.0M;
int Año = 0;
bool salir = true;

do { 
//Elija el usuario
Console.WriteLine("Elija una opcion de la siguiente lista: ");
Console.WriteLine("\ts - Crear y serealizar registro ");
Console.WriteLine("\td - deserealizar registro ");
Console.WriteLine("\te- Salir del programa ");
Console.WriteLine("¿Su opcion? ");

    string op = Console.ReadLine();

switch (op)
{

    case "s":
        stream = new FileStream("clientes.xml", FileMode.OpenOrCreate, FileAccess.Write);

        Console.Write("Ecriba el chasis del auto y luego presione Enter: ");
        Chasis = Console.ReadLine();

        //pida al usuario que escriba el primer nombre 
        Console.Write("Escriba la marca del auto y luego presione Enter: ");
        Marca = Console.ReadLine();

        //pida al usuario que ingrese el apellido paterno 
        Console.Write("Escriba el modelo del auto y luego presione Enter: ");
        Modelo = Console.ReadLine();


        //pida al usuario que escriba el valor del saldo 
        Console.Write("Escriba el precio del auto y luego presione Enter: ");
        valorPrecio = Console.ReadLine();

        while (!decimal.TryParse(valorPrecio, out Precio))
        {

            Console.WriteLine("No es una entrada valida, introduzca un valor decimal: ");
            valorPrecio = Console.ReadLine();

        }

        Console.Write("Ecriba el año de fabricacion del vehiculo y luego presione Enter: ");
        valorAño = Console.ReadLine();

        while (!int.TryParse(valorAño, out Año))
        {

            Console.WriteLine("No es una entrada valida, introduzca un valor entero: ");
            valorAño = Console.ReadLine();

        }


        registro = new RegistroSerializable(Chasis, Marca, Modelo, Precio, Año);
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
}while(!salir);





[Serializable]

public class RegistroSerializable
{


    private string Chasis;
    private string Marca;
    private string Modelo;
    private decimal Precio;
    private int Año;

    public RegistroSerializable()
    {

    }
    public RegistroSerializable(string chasis, string marca,
        string modelo, decimal precio, int año)
    {

        Chasis1 = chasis;
        Marca1 = marca;
        Modelo1 = modelo;
        Precio1 = precio;
        Año1 = año;

    }

    public string Chasis1 { get => Chasis; set => Chasis = value; }
    public string Marca1 { get => Marca; set => Marca = value; }
    public string Modelo1 { get => Modelo; set => Modelo = value; }
    public decimal Precio1 { get => Precio; set => Precio = value; }
    public int Año1 { get => Año; set => Año = value; }

    public override string ToString()
    {
        return "Cuenta: " + Chasis + "\n" + "Nombre: " + Marca + "\n " + "Apellido: " + Modelo + "\n " + "Saldo: " + Precio + "\n" + "Año: "+ Año + "\n";
    }

}
using SerializacionJSON;
using System.Text.Json;

Console.WriteLine("Serealizacion JSON en c#\r");
Console.WriteLine("---------------------------\n");


Control_Registro_Cuentas deserealizable = null;
int cuenta;
string valorCuenta = "";
string nombre = "";
string apellido = "";
decimal saldo = 0.0M;
string valorSaldo = "";
string fileName = "cliente.json";
string jsonString = "";

Control_Registro_Cuentas registroSerializable = new();
//Elija el usuario
do
{
    Console.WriteLine("°°°°°°°°°°Menú de opciones°°°°°°°°°°°");
    Console.WriteLine("Elija una opcion de la siguiente lista: ");
    Console.WriteLine("\ts - Crear y serealizar registro ");
    Console.WriteLine("\td - deserealizar registro ");
    Console.WriteLine("\te- Salir del programa");
    Console.WriteLine("¿Su opcion? ");
    Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");

    string op = Console.ReadLine();

    switch (op)
    {

        case "s":


            Console.Write("Ecriba el número de la cuenta y luego presione Enter: ");
            valorCuenta = Console.ReadLine();

            while (!int.TryParse(valorCuenta, out cuenta))
            {

                Console.WriteLine("No es una entrada válida, introduzca un valor entero: ");
                valorCuenta = Console.ReadLine();

            }

            Console.Write("Escriba el primer nombre y luego presione Enter: ");
            nombre = Console.ReadLine();


            Console.Write("Escriba el apellido paterno y luego presione Enter: ");
            apellido = Console.ReadLine();

            Console.Write("Escriba el valor del saldo y luego presione Enter: ");
            valorSaldo =  Console.ReadLine();

            while (!decimal.TryParse( valorSaldo, out saldo))
            {

                Console.WriteLine("No es una entrada válida, introduzca un valor decimal: ");
                valorSaldo = Console.ReadLine();

            }
             
           
            Console.WriteLine("Registro a serealizar");
            Console.WriteLine("\n");

            if(valorCuenta != null && nombre != null && apellido != null && valorSaldo !=null)
            {
                registroSerializable.addCount(new InformacionSeria(int.Parse(valorCuenta), nombre.ToString(), apellido.ToString(),Convert.ToDecimal( valorSaldo)));
            }

            Console.WriteLine("-------------------- Serealizamos -------------------- ");

            jsonString = JsonSerializer.Serialize(registroSerializable);
            File.WriteAllText(fileName, jsonString);

            break;

        case "d":

            Console.WriteLine("--------------- Deserializamos ---------------");
            jsonString = File.ReadAllText(fileName);
            deserealizable = JsonSerializer.Deserialize<Control_Registro_Cuentas>(jsonString)!;

            Console.WriteLine("El registro deserializado es:  ");
            Console.WriteLine(registroSerializable.ToString());

            break;

        case "e":
            Console.WriteLine("Hasta la próxima...!");
            Environment.Exit(0);
            break;


        default:
            Console.WriteLine("Opcion invalida");
            break;
    }
}while (true);

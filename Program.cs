using System.Data.Sql;
using System.Data.SqlClient;



string nombre;
string apellido;
int opcion = 0;
string cadena;

Console.WriteLine("Escoge una opcion");
Console.WriteLine("1 Realiza cuestionario");
Console.WriteLine("2 Ver registros");
opcion = int.Parse(Console.ReadLine());

SqlConnection conectarbd = new SqlConnection();
cadena ="Data Source = DESKTOP-P306A4Q\\SQLEXPRESS; Initial Catalog=Csharp;Integrated Security=True";

//Ver registros

if (opcion == 2)
{    
    try
    {
        SqlCommand cmd;
        conectarbd.ConnectionString = cadena;
        conectarbd.Open();
        cmd = new SqlCommand("SELECT * FROM [Csharp].[dbo].[Personas]", conectarbd);
        SqlDataReader dr = cmd.ExecuteReader();

        while(dr.Read()){
            Console.WriteLine(Convert.ToString(dr[0]) + " " + Convert.ToString(dr[1]));
        }

        Console.WriteLine("registros"); 
    }
    catch (Exception ex)//(System.Exception)
    {        
       Console.WriteLine("Sin conexion " + ex.ToString());
    }
}

if (opcion == 1)
{
    do
{
Console.WriteLine("Como te llamas?");
nombre = Console.ReadLine();
} while (String.IsNullOrEmpty(nombre));

if (nombre!="")
{
    Console.WriteLine("Te llamas " +nombre);
}


do
{
Console.WriteLine("Cual es tu apellido?");
apellido = Console.ReadLine();
} while (String.IsNullOrEmpty(apellido));

if (apellido!="")
{
    Console.WriteLine("Tu apellido es " +apellido);
}

//Insertar a SQL

//cadena ="Data Source = DESKTOP-P306A4Q\\SQLEXPRESS; Initial Catalog=Csharp;Integrated Security=True";
//SqlConnection conectarbd = new SqlConnection();
    try
    {
        SqlCommand cmd;
        conectarbd.ConnectionString = cadena;
        conectarbd.Open();
        cmd = new SqlCommand("INSERT INTO [Csharp].[dbo].[Personas](Nombre,Apellido) VALUES ('"+nombre+"','"+apellido+"')", conectarbd);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Se insertaron los registros"); 
    }
    catch (Exception ex)//(System.Exception)
    {        
       Console.WriteLine("Sin conexion " + ex.ToString());
    }
}


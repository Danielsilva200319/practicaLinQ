using System.Runtime.CompilerServices;
using practicaLinQ;

internal class Program
{
    private static void Main(string[] args)
    {
        int?[] args2 = new int?[5];
        Console.WriteLine(args2[0]);
        LinQueries queries = new LinQueries();
        // imprimirValores(queries.AllCollection());
        // imprimirValores(queries.LibrosAndroid());
        // imprimirValores(queries.LibrosDespues2000());
        // imprimirValores(queries.LibrosAndroid2005());
        // imprimirValores(queries.Libros250paginas());
        // Console.WriteLine(queries.verificar() ? "Todos los libros contienen un status" : "Al menos uno de los libros no contiene un status");
        /* if (queries.verificar2005())
        {
            imprimirValores(queries.Libros2005());
        }
        else
        {
            Console.WriteLine("No hay libros de ese año");
        } */
    }
    private static void imprimirValores(IEnumerable<Book> books)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0,-70} {1,7} {2,20}", "titulo", "N. Paginas", "Fecha Publicaación");
        foreach (Book book in books)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            registros += 1;
            Console.WriteLine("{0,-70} {1,7} {2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}
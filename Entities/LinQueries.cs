using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace practicaLinQ;
public class LinQueries
{
    List<Book> listBooks = new List<Book>();
    public LinQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.listBooks = System.Text.Json.JsonSerializer
            .Deserialize<List<Book>>(json,new System.Text.Json.JsonSerializerOptions() 
            { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
        }
    }
    public IEnumerable<Book> AllCollection()
    {
        return listBooks;
    }
    public IEnumerable<Book> LibrosDespues2000()
    {
        return from book in listBooks where book.PublishedDate.Year >200 select book;
    }
    public IEnumerable<Book> Libros2005()
    {
        return from book in listBooks where book.PublishedDate.Year == 2005 select book;
    }
    public IEnumerable<Book> LibrosAndroid()
    {
        return from book in listBooks where book.Title.Contains("Android") select book;
    }
    public IEnumerable<Book> LibrosAndroid2005()
    {
        return from book in listBooks where book.PublishedDate.Year > 2005 && book.Title.Contains("Android") select book;
    }
    public IEnumerable<Book> Libros250paginas()
    {
        return from book in listBooks where book.PageCount > 250 && book.Title.Contains("Action") select book;
    }
    public bool verificar()
    {
        return listBooks.All(book => book.Status != String.Empty);
    }
    public bool verificar2005()
    {
        return listBooks.Any(book => book.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> CategoriaPython()
    {
        return listBooks.Where(
            book => (book.Categories ?? Array.Empty<string>()).Contains("Python")
        );
    }
    public IEnumerable<Book> OrdebyJava()
    {
        return listBooks.Where(
            book => (book.Categories ?? Array.Empty<string>()).Contains("Java")
        ).OrderBy(book => book.Title);
    }
    public IEnumerable<Book> OrdebyDescedign()
    {
        return listBooks.Where(
            book => (book.PageCount > 450)
        ).OrderByDescending(book => book.PageCount);
    }
}
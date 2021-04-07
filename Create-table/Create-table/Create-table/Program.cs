using Alba.CsConsoleFormat;
using BookClass;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Create_table
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Jack London", "Martin Eden", "Macmillan", "978-5-9925-0298-5"));
            books.Add(new Book("J. K. Rowling", "Harry Potter", "Scholastic", "978-0-4397-0818-0"));
            PrintTable(books);
        }

        public static void PrintTable<T>(IEnumerable<T> items)
        {
            Document doc = new Document();
            Grid grid = new Grid();
            var headerThickness = new LineThickness(LineWidth.Single);
            PropertyInfo[] propertyInfo = typeof(T).GetProperties();
            foreach(var item in propertyInfo)
            {
                grid.Columns.Add(new Column { Width = GridLength.Auto, Name = item.Name });
                grid.Children.Add(new Cell(item.Name) { Stroke = headerThickness });
            }

            foreach (var item in items)
            {
                foreach (var property in propertyInfo)
                {
                    Align align = Align.Right;
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(char))
                    {
                        align = Align.Left;
                    }

                    grid.Children.Add(new Cell(property.GetValue(item)) { Stroke = headerThickness, Align = align });
                }
            }
            
            doc.Children.Add(grid);

            ConsoleRenderer.RenderDocument(doc);
        }
    }
}

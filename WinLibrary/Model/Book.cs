using System.Collections.Generic;

namespace WinLibrary.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public virtual List<Book> Books { get; set; }
        public string Title { get; set; }
        public string[] Author { get; set; }
        public string Editor { get; set; }
        public string Year { get; set; }
        public string Pages { get; set; }
    }
}

using System.ComponentModel;

namespace task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input , isbn ;
            string author ,title;
            bool avaliblity;
            Library l1 = new Library();
            do
            {
                Console.WriteLine("-------Welcome To Our Library System------------");
                Console.WriteLine("Press 1  To View The Available Books : ");
                Console.WriteLine("Press 2  To Add A New Book : ");
                Console.WriteLine("Press 3  To Search For A Book : ");
                Console.WriteLine("Press 4  To Borrow An Available Book : ");
                Console.WriteLine("Press 5  To Return The Book : ");
                Console.WriteLine("Press 0  To Exit The Program: ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        l1.ViewAll();
                        break;
                    case 2:
                        Console.WriteLine("please enter isbn , author , title,availabilty : ");
                        isbn = int.Parse(Console.ReadLine());
                        author = Console.ReadLine();
                        title = Console.ReadLine();
                        avaliblity = bool.Parse(Console.ReadLine());
                        Book bInput = new(isbn, author, title, avaliblity);
                        l1.Add(bInput);
                        break;
                    case 3:
                        Console.WriteLine("Please Enter The Title of The Book : ");
                        title = Console.ReadLine();
                        l1.Search(title);
                        break;
                    case 4:
                        Console.WriteLine("Please Enter The Title of The Book : ");
                        title = Console.ReadLine();
                        l1.BorrowBook(title);
                        break;
                    case 5:
                        Console.WriteLine("Please Enter The Title of The Book : ");
                        title = Console.ReadLine();
                        l1.ReturnBook(title);
                        break;
                    default:
                        Console.WriteLine("Invalid Input Please Enter Another Input: ");
                        break;
                }
            } while (input != 0);

            Console.ReadKey();
        }
    }
    class Book
    {
        int isbn;
        string author;
        string title;
        bool availablity;
        public Book(int isbn, string author, string title, bool availablity)
        {
            this.isbn = isbn;
            this.author = author;
            this.title = title;
            this.availablity = availablity;
        }

        public int GetIsbn() { return this.isbn; }
        public string GetAuthor() { return this.author; }
        public string GetTitle() { return this.title; }
        public bool GetAvailabilty() { return this.availablity; }
        public void SetIsbn(int isbn) { this.isbn = isbn; }
        public void SetAuthor(string author) { this.author = author; }
        public void SetTitle(string title) { this.title = title; }
        public void SetAvilabilty(bool availablity) { this.availablity = availablity; }
    }
    class Library
    {
        List<Book> books = new List<Book>();
        public void Add(Book book)
        {
            if (books.Contains(book))
            {
                Console.WriteLine($"this book is already exist {book.GetTitle()}");

            }
            else
            {
                books.Add(new Book(book.GetIsbn(), book.GetAuthor(), book.GetTitle(), book.GetAvailabilty()));
                Console.WriteLine($"-----------------'{book.GetTitle()}' Added Sucessfully-----------------");
            }
        }
        public void ViewAll()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("-----------------The Liberary Is Empty-----------------");
                return;
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"Isbn:{books[i].GetIsbn()}\nTitle:{books[i].GetTitle()}\nAuthor:{books[i].GetAuthor()}\nAvailable:{books[i].GetAvailabilty()}");
                }
            }

        }
        public Book Search(string title)
        {
            Book fbook = new Book(0, " ", " ", false);
            if (books.Count == 0)
            {
                Console.WriteLine("----------Sorry Library Is Empty---------");
                return fbook;
            }
            else
            {
                int index = 0;
                int i;
                for (i = 0; i < books.Count; i++)
                {
                    if (books[i].GetTitle() == title)
                    {
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public void BorrowBook(string title)
        {
            Book book = Search(title);
            if (book.GetAvailabilty() == true)
            {
                Console.WriteLine("OK you can take it");
                book.SetAvilabilty(false);
            }
            else
            {
                Console.WriteLine("Sorry You Can Not Take It");
            }
        }
        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle() == title)
                {
                    Console.WriteLine("thank you for brining the book back");
                    books[i].SetAvilabilty(true);
                }
            }
        }
    }

}

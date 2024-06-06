namespace Indexer_delegate_assignments
{
    public delegate void mydelegate();
    class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int price { get; set; }
        public void showBookInfo()
        {
            Console.WriteLine("------------");
            Console.WriteLine("ISBN :" + ISBN);
            Console.WriteLine("Title :" + Title);
            Console.WriteLine("price :" + price);
            Console.WriteLine("------------");
        }
    }
    class Catlog
    {
        public Book[] Books { get; set; }
        public Catlog()
        {
            Books = new Book[10];// array of ref variables


        }
        public Book this[int index]
        {
            get { return Books[index]; }
            set { Books[index] = value; }
        }



    }

    internal class Program
    {
        static void Main(string[] args)
        {

            mydelegate md;

            Catlog ct = new Catlog();
            ct[0] = new Book() { ISBN = 000, price = 100, Title = "Let us C" };
            Book b1 = new Book();
            b1.ISBN = 1;
            b1.price = 200;
            b1.Title = "fundametals of  JAVA";
            ct[1] = b1;
            ct[2] = new Book();
            ct[2].ISBN = 2;
            ct[2].Title = "C#";
            ct[2].price = 250;

            for (int i = 0; i < 3; i++)
            {
                //ct[i].showBookInfo();
                md = ct[i].showBookInfo;
                md();
            }

            Console.WriteLine("Enter ISBN Number");
            int no = int.Parse(Console.ReadLine());

            bool flag = false;

            if (ct[no] != null && (no >= 0 && no < 10))
            {
                Console.WriteLine("Book information found...");
                md = ct[no].showBookInfo;
                md();
                flag = true;

            }

            if (flag == false)
            {
                Console.WriteLine("Book not found!!!");
            }

        }
    }
}
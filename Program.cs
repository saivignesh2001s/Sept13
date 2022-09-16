using System.Reflection.Metadata;
using User;

namespace Sept13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Customer name");
            customer.Cname = Console.ReadLine();
            start:
            Console.WriteLine("Enter Customer Phone no");
            customer.CPhoneno=Console.ReadLine();
            if (customer.CPhoneno == null)
            {
                Console.WriteLine("Try again");
                goto start;
            }
            Console.WriteLine("Type");
            customer.Ctype=Console.ReadLine();
            string kop = customer.Ctype;
            Searching s = new Searching();
            s.initiate();
            Console.WriteLine("Able to add the movies");
            Console.WriteLine("Enter number of movies you want to add");
            int j=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < j; i++)
            {
                s.AddMovies();
            }
            Console.WriteLine("Display movies");
            s.DisplayMovies();
           Console.WriteLine("Able to remove movies");
            s.DeleteMovies();
            Console.WriteLine("After deleting the movies");
            s.DisplayMovies();
            Console.WriteLine("Searching the movies");
            s.search();
            foreach(var item in s.Search)
            {
                Console.WriteLine($"{item.mname} {item.mlanguage} {item.mgenre} {item.mstock}");
            }
            Console.WriteLine("Add to wishlist");
            Watch m = new Watch();
        mer:
            if (kop == "Gold" && m.watchlist.Count < 3)
            {
                m.Addtowatchlist();
            }
           else if(kop == "Silver" && m.watchlist.Count < 2)
            {
                m.Addtowatchlist();
            }
          else if(kop == "Platinum" && m.watchlist.Count < 5)
            {
                m.Addtowatchlist();
            }
        else
            {
                Console.WriteLine("You could not add further");
            }
            Console.WriteLine("Do you want to continue? Enter yes");
            string dj=Console.ReadLine();
            if(dj == "yes")
            {
                goto mer;
            }
            List<Movie> l=new List<Movie>();
            foreach(var item in m.watchlist)
            {
                Console.WriteLine($"{item.Item1.mname} {item.Item1.mstock}");
                l.Add(item.Item1);
            }
            customer.addedwatchlist = l;
            mere:
            Console.WriteLine("Remove from watchlist");
            m.releaselist();
            Console.WriteLine("Do you want to continue? Enter yes");
            string jd = Console.ReadLine();
            if (jd == "yes")
            {
                goto mere;
            }
            List<Movie> kit = new List<Movie>();
            foreach (var item in m.release)
            {
                Console.WriteLine($"{item.Item1.mname} {item.Item1.mstock}");
                kit.Add(item.Item1);
                
            }
         
            customer.removedwatchlist=kit;
            Console.WriteLine("Total cost associated");
            foreach(var item in m.watchlist)
            {
                m.totalcostassociated(item.Item1.mname);
            }
            foreach (var item in m.release)
            {
                m.totalcostassociated(item.Item1.mname);
            }
            

            Console.ReadLine();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class Customer
    {
        private string cname;
        private string cphoneno;
        private string ctype;
        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }
        public string CPhoneno
        {
            get
            {
                if (cphoneno.Length == 10)
                {
                    return cphoneno;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                cphoneno = value;


            }
        }
        public string Ctype
        {
            get { return ctype; }
            set { ctype = value; }
        }
       public List<Movie> addedwatchlist
        {
            get;
            set;
        }
        public List <Movie> removedwatchlist
        {
            get;
            set;
        }

    }
    public class Movie
    {
        public string mname
        {
            get;
            set;
        }
        public string mlanguage { get; set; }
        public string mgenre { get; set; }
        public int mstock { get; set; }
        public Movie(string name, string language, string genre, int stock)
        {
            mname = name;
            mlanguage = language;
            mgenre = genre;
            mstock = stock;

        }
        public Movie()
        {

        }
    }
    public class Searching
    {
        public List<Movie> Search
        {
            get;
            set;
        }
        public static List<Movie> movies = new List<Movie>();
       
        public void initiate()
        {
            movies.Add(new Movie("Padayappa", "Tamil", "Action", 20));
            movies.Add(new Movie("Kanchana", "Tamil", "Thriller", 40));
            movies.Add(new Movie("Anandham", "Telugu", "Drama", 50));
            movies.Add(new Movie("Anjana", "Telugu", "Thriller", 60));
            movies.Add(new Movie("Atma", "Kannada", "Drama", 34));
        }
        public void search()
        {
            Console.WriteLine("Search by\n 1.Name\n 2.Language\n 3.Genre");
            int p = Convert.ToInt32(Console.ReadLine());
            switch (p)
            {
                case 1:
                    Console.WriteLine("Enter the movie name to search");
                    string q = Console.ReadLine();
                    var pt = movies.Where(pi => pi.mname == q).ToList();
                    if (pt != null)
                    {
                        Search = pt;
                    }
                    else
                    {
                        Console.WriteLine("Movie unavailable");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the movie language to search");
                    string qq = Console.ReadLine();
                    var tp = movies.Where(pi => pi.mlanguage == qq).ToList();
                    if (tp != null)
                    {
                        Search = tp;
                    }
                    else
                    {
                        Console.WriteLine("Language unavailable");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the movie genre to search");
                    string qqq = Console.ReadLine();
                    var tpp = movies.Where(pi => pi.mgenre == qqq).ToList();
                    if (tpp != null)
                    {
                        Search = tpp;
                    }
                    else
                    {
                        Console.WriteLine("Language unavailable");
                    }
                    break;

            }
        }
        public void AddMovies()
        {
            Movie m = new Movie();
            Console.WriteLine("Enter movie name");
            m.mname = Console.ReadLine();
            Console.WriteLine("Enter movie language");
            m.mlanguage = Console.ReadLine();
            Console.WriteLine("Enter movie genre");
            m.mgenre = Console.ReadLine();
            Console.WriteLine("Enter movie stock");
            m.mstock = Convert.ToInt32(Console.ReadLine());
            Tuple<string, string, string, int> mi = Tuple.Create<string, string, string, int>(m.mname, m.mlanguage, m.mgenre, m.mstock);
            Predicate<Tuple<string, string, string, int>> k = (i) =>
            {
                int flag = 0;
                foreach (var item in movies)
                {
                    if (item.mname == i.Item1 && item.mlanguage == i.Item2 && item.mgenre == i.Item3)
                    {
                        flag = 1;
                        break;
                    }

                }
                if (flag == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            if (k(mi))
            {
                Console.WriteLine("Already Exists");
            }
            else
            {
                movies.Add(m);

            }
        }
        public void DeleteMovies()
        {

            Movie md = new Movie();
            Movie m = null;
            Console.WriteLine("Enter movie name");
            md.mname = Console.ReadLine();
            Console.WriteLine("Enter movie language");
            md.mlanguage = Console.ReadLine();
            Console.WriteLine("Enter movie genre");
            md.mgenre = Console.ReadLine();
            foreach (var item in movies)
            {
                if (item.mname == md.mname && item.mlanguage == md.mlanguage && item.mgenre == md.mgenre)
                {

                    m=item;
                }

            }
            movies.Remove(m);

        }

        public void DisplayMovies()
        {
            foreach (var item in movies)
            {
                Console.WriteLine($"{item.mname} {item.mlanguage} {item.mgenre}");
            }
        }

    }
    public class Watch : Searching
    {
        public List<Tuple<Movie, DateTime>> watchlist = new List<Tuple<Movie, DateTime>>();
        public List<Tuple<Movie, char, int>> release = new List<Tuple<Movie, char, int>>();
        public List<Tuple<string, int, double>> total = new List<Tuple<string, int, double>>();
        public void Addtowatchlist()
        {
            string s = Console.ReadLine();
            var pi = movies.Where(p => p.mname == s).ToList();
            if (pi != null)
            {
                foreach (Movie item in pi)
                {

                    Console.WriteLine(item.mname);

                    movies.Remove(item);
                    item.mstock = item.mstock - 1;
                    Console.WriteLine("Enter year");
                    int yr1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter month");
                    int mon1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter date");
                    int dt1 = Convert.ToInt32(Console.ReadLine());
                    DateTime t1 = new DateTime(yr1, mon1, dt1);

                    Tuple<Movie, DateTime> ji = Tuple.Create<Movie, DateTime>(item, t1);
                    movies.Add(item);
                    watchlist.Add(ji);


                }

            }
            else
            {
                Console.WriteLine("Cannot be added");
            }

        }
        public void releaselist()
        {

            string cp = Console.ReadLine();
            Tuple<Movie, DateTime> k = null;
            foreach (var item in watchlist)
            {
                if (cp == item.Item1.mname)
                {
                    k = item;

                    movies.Remove(item.Item1);
                    item.Item1.mstock = item.Item1.mstock + 1;

                    Console.WriteLine("Enter year");
                    int yr = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter month");
                    int mon = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter date");
                    int dt = Convert.ToInt32(Console.ReadLine());
                    DateTime t = new DateTime(yr, mon, dt);
                    TimeSpan ts = t - item.Item2;
                    Console.WriteLine("c for cancel s for seen");
                    char tyj = Convert.ToChar(Console.ReadLine());
                    Tuple<Movie, char, int> poi = Tuple.Create<Movie, char, int>(item.Item1, tyj, ts.Days);
                    release.Add(poi);
                    movies.Add(item.Item1);


                }


            }
            watchlist.Remove(k);
        }
        public void totalcostassociated(string p)
        {
            int flag = 0;
            foreach (var item in release)
            {
                if (p == item.Item1.mname)
                {
                    flag = 1;
                    Console.WriteLine(item.Item1.mname);
                    Console.WriteLine("Enter the cost for one day");
                    double Cost = Convert.ToInt32(Console.ReadLine());
                    double k = 0.18 * Cost;
                    double ty = item.Item3 * 0.01 * Cost;
                    double yt = k + ty + Cost;
                    Console.WriteLine($"GST is {k}");
                    Console.WriteLine($"Bluray cost is {ty}");
                    Console.WriteLine("Total cost is" + " " + yt);
                    Tuple<string, int, double> k2 = Tuple.Create(item.Item1.mname, item.Item3, yt);

                    total.Add(k2);
                }
            }
            foreach (var item in watchlist)
            {
                if (p == item.Item1.mname)
                {
                    Console.WriteLine(item.Item1.mname);
                    Console.WriteLine("Enter the cost for one day");
                    double Cost = Convert.ToInt32(Console.ReadLine());
                    TimeSpan tu = DateTime.Now - item.Item2;
                    double k = 0.18 * Cost;
                    double ty = (tu.Days) * 0.01 * Cost;
                    double yt = k + ty + Cost;
                    Console.WriteLine($"GST is {k}");
                    Console.WriteLine($"Bluray cost is {ty}");
                    Console.WriteLine("Total cost is" + " " + yt);
                    Tuple<string, int, double> k2 = Tuple.Create(item.Item1.mname, tu.Days, yt);

                    total.Add(k2);
                }
                else if (flag != 1)
                {
                    foreach (var item1 in movies)
                    {
                        if (p == item1.mname)
                        {

                            Console.WriteLine(item1.mname);
                            Console.WriteLine("Enter the cost for one day");
                            double Cost = Convert.ToInt32(Console.ReadLine());

                            double k = 0.18 * Cost;
                            double ty = 0 * 0.01 * Cost;
                            double yt = k + ty + Cost;
                            Console.WriteLine($"GST is {k}");
                            Console.WriteLine($"Bluray cost is {ty}");
                            Console.WriteLine("Total cost is" + " " + yt);
                            Tuple<string, int, double> k2 = Tuple.Create(item.Item1.mname, 0, yt);

                            total.Add(k2);
                        }
                    }

                }
            }
        }
    }

    }

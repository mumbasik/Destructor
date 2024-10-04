using System.Xml.Linq;

namespace Destructor
{
    //N1
    class Movie: IDisposable
    {
        public string Name { get; set; }
     
        public string StudioName { get; set; }

        public string Genre { get; set; }

        public double Duration { get; set; }
        public bool disposed = false;

        public Movie(string name, string studioname, string genre, double duration) {  
        
            Name  = name;
            StudioName = studioname;
            Genre = genre;
            Duration = duration;
            disposed = true;
           
        } 

        public void Print() { 
        Console.WriteLine("Name: " + Name);
            Console.WriteLine("StudioName: " + StudioName);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Duration: " + Duration);

        
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Movie() {
            Dispose(false);
            Console.WriteLine("End of the movie");
        
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Name = null;
                    StudioName = null;
                    Genre = null;
                    Duration = 0;

                }
            }
        }
    }
    //N2
    class Performance
    {
        public string PerformanceName { get; set; }    
        public string ThreateName {  get; set; }
        public string Genre {  get; set; }  
        public double Duration { get; set; }

        public bool disposed = false;

        public List<string> ActorList { get; set; } = new List<string>();
        public Performance(string name, string tname, string genre, double duration, List<string> names) {
        
            PerformanceName = name;
            ThreateName = tname;
            Genre = genre;
            Duration = duration;
            ActorList = names;
            disposed = true;

        }
        public void Print()
        {
            Console.WriteLine("Performance name: " + PerformanceName);
            Console.WriteLine("Threate Name: " + ThreateName);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Duration: " + Duration);
            Console.WriteLine("Actors List: ");
            foreach (var actor in ActorList)
            {
                Console.WriteLine(" ) " + actor);
            }
        }




        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Performance()
        {
            Dispose(false);
            Console.WriteLine("End of the performance");

        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    PerformanceName = null;
                    ThreateName = null;
                    Genre = null;
                    Duration = 0;
                    ActorList.Clear();

                }
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //N1
            Movie obj = new Movie("Joker", "Warner Brothers", "Drama", 2.20);
            obj.Print();
            obj.Dispose();
            //N2
            List<string> Actors = new List<string> { "John", "Alex", "Sam" };

            Performance obj2 = new Performance("Vendetta", "Opera", "Drama", 20.90, Actors );
            obj2.Print();
            obj2.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

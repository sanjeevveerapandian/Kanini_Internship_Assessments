using System;
using System.Collections.Generic;

class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public  double BasePrice { get; set; }

    public Movie(string title, string genre, double basePrice)
    {
        Title = title;
        Genre = genre; 
        BasePrice = basePrice;
    }
}

class Program
{
    static void Main()
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie("Inception", "Sci-Fic", 200),
            new Movie("Interstellar","Sci-Fic", 200),
            new Movie("Avengers","Fantasy",250)
        };
        Console.WriteLine("Movie List");

        for(int i=0; i<movies.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{movies[i].Title} ({movies[i].Genre}) - Rs.{movies[i].BasePrice}");

        }
        Console.Write("\nChoose a movie (Enter Number): ");

        if(!int.TryParse(Console.ReadLine(),out int movieChoice) || movieChoice < 1 || movieChoice > movies.Count)
        {
            Console.WriteLine("Invalid movie selection.");
            return;
        }

        Movie selectedMovie = movies[movieChoice-1];

        int rows = 5;
        int cols = 5;

        string[,] seats = new string[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                seats[i, j] = "A";
            }
        }

        List<string> bookedSeats = new List<string>();

        Console.WriteLine("how many seats do you want to book?");

        if(!int.TryParse(Console.ReadLine(), out int seatCount) || seatCount <= 0)
        {
            Console.WriteLine("Invalid seat count.");
            return;
        }

        for(int s = 0; s< seatCount; s++)
        {
            DisplaySeats(seats);

            Console.WriteLine("Enter row numbber: ");

            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("Invalid row input");
                s--;
                continue;
            }

            Console.Write("Enter column number: ");
            if(!int.TryParse(Console.ReadLine(), out int col))
                {
                Console.WriteLine("invalid column input.");
                s--;
                continue;
            }

            if(row < 1 || row > rows || col < 1 || col > cols)
            {
                Console.WriteLine("invalid seat position.");
                s--;
                continue;
            }

            if (seats[row - 1,col-1] == "X")
            {
            Console.WriteLine("Seat is already booked.");
            s--;
            continue;
        }
            seats[row - 1,col-1] = "X";
            bookedSeats.Add($"Row{row} Seat {col}");
        }
        Console.WriteLine("\nFinal Seating Map:");
        DisplaySeats(seats);

        double subtotal = seatCount * selectedMovie.BasePrice;
        double discount = 0;
        double totalPrice = subtotal;

        if (seatCount >= 2)
        {
            discount = subtotal * 0.10;
            totalPrice = subtotal - discount;
        }

        Console.WriteLine("\nBOOKING RECEIPT");

        Console.WriteLine($"Movie: {selectedMovie.Title}");

        Console.WriteLine($"\nTickets Booked: {seatCount}");
        Console.WriteLine($"Price Per Ticket: Rs.{selectedMovie.BasePrice}");

        Console.WriteLine($"\nSubtotal: Rs.{subtotal}");

        if (discount > 0)
        {
            Console.WriteLine($"Discount (10%): -Rs.{discount}");
        }
        else
        {
            Console.WriteLine("Discount: Rs.0");
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine($"Total Amount: Rs.{totalPrice}");

        Console.WriteLine("\nSeats booked:");
        foreach (string seat in bookedSeats)
        {
            Console.WriteLine(seat);
        }
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();

    }
    static void DisplaySeats(string[,] seats)
    {
        Console.WriteLine("\nCurrent seating map: ");

        for(int i = 0; i < seats.GetLength(0); i++)
        {
            for (int j = 0; j < seats.GetLength(1); j++)
            {
                Console.Write($"[{seats[i,j]}]");
            }
            Console.WriteLine();

        }

    }

}
using System;
using System.Collections.Generic;

namespace ConsoleApplicationCinema
{
    class Cinema
    {
        public List<Seat> seats {get; set;}
        public int rows {get; set;}
        public int columns {get; set;}

        public Cinema(int amountOfRows, int amountOfSeats)
        {
            if (amountOfRows < 1)
            {
                Console.WriteLine("The specified amount of rows is less than 1");
            } else if (amountOfSeats < 1)
            {
                Console.WriteLine("The Specified amount of seats is less than 1");   
            } else
            {
                rows = amountOfRows;
                columns = amountOfSeats;
                seats = new List<Seat>();
                for (int i = 0; i < rows*columns; i++)
                {
                    Seat tmp;
                    if (rows * columns / 2 > i && rows*columns > 50)
                    {
                        tmp = new Seat(i+1, 12);
                    } else
                    {
                        tmp = new Seat(i+1, 10);
                    }
                    seats.Add(tmp);
                }

            }
        }

        public void ShowSeats()
        {
            int i = 1;
            foreach (var item in seats)
            {  
                if (item.reserved)
                {
                    Console.Write("R ");
                } else
                {
                    Console.Write("A ");
                }
                
                if (i % columns == 0)
                {
                    Console.Write("\n");
                }
                i++;
            }
            Console.Write ("\n");
        }

        private void AvailableSeats()
        {
            Console.WriteLine("The following seats are available: ");
            foreach (var item in seats)
            {
               if (!item.reserved)
               {
                   Console.Write(item.seatID + " ");
                }
            }
            Console.Write("\n");
        }

        public int PurchasedTickets()
        {
            int tickets = 0;
            foreach (var item in seats)
            {
                if (item.reserved)
                {
                    tickets++;
                }
            }
            return tickets;
        }

        public float PercentagePurchased()
        {
            return PurchasedTickets() / (rows*columns);
        }

        public int CurrentIncome()
        {
            int income = 0;
            foreach (var item in seats)
            {
                if (item.reserved)
                {
                   income += item.price;
                }
            }
            return income;
        }

        public int PotentialIncome()
        {
            int income = 0;
            foreach (var item in seats)
            {
                income += item.price;
            }
            return income;
        }

        public void BuyTicket(int seatNumber)
        {
            seatNumber = seatNumber -1;
            int seatRow = seatNumber / rows;

            if (seatRow > rows || seatNumber < 1)
            {
                Console.WriteLine("The requested seat does not exist");
                AvailableSeats();                
            } else
            {
                Seat seatRequested = seats[seatNumber];
                if (seatRequested.reserved)
                {
                    Console.WriteLine("The specified seat has already been booked, please try to book different seat");
                } else
                {
                    seatRequested.reserved = true;
                    seats[seatNumber] = seatRequested;
                    Console.WriteLine("The desired seat (" + (seatNumber+1) + ") has been purchased. \n");
                }
            }
        }

        public static void CinemaAppSelections()
        {
                Console.WriteLine("You have the following options:");
                Console.WriteLine("To create a cinema: insert 1");
                Console.WriteLine("To view seats and their status in the cinema: insert 2");
                Console.WriteLine("To buy a ticket for a specific seat: insert 3");
                Console.WriteLine("To output number of purchased tickets: insert 4");
                Console.WriteLine("To see percentage of occupied seats: insert 5");
                Console.WriteLine("To view the current income: insert 6");
                Console.WriteLine("To see the potential total income: insert 7");
        }

        static void Main(string[] args)
        {            
            Cinema cinema = new Cinema(1,1);
            string input = "";
            Console.WriteLine("Welcome to the backend of a Cinema App");
            CinemaAppSelections();
            while (input != "exit")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("You have chosen to create a new Cinema room");
                        Console.WriteLine("Please enter the dimensions of the room, as X Y," +
                                 " where X is amount of rows and Y amount of columns in the cinema");
                        var inputs = Console.ReadLine();
                        string[] words = inputs.Split(' ');
                        try
                        {
                            int a = Int32.Parse(words[0]);
                            int b = Int32.Parse(words[1]);
                            cinema = new Cinema(a,b);
                            Console.WriteLine("The new Cinema has now been entered. There are in total: "+ a*b +" seats \n");
                        } catch (FormatException)
                        {
                        }
                        break;
                    case "2":
                        Console.WriteLine("You have chosen to view the seats in the Cinema. A is available, R is reserved");
                        cinema.ShowSeats();
                        break;
                    case "3":
                        Console.WriteLine("You have chosen to buy tickets");
                        Console.WriteLine("Which seat do you wish to purchase? Please enter the seat number");
                        var ticketInput = Console.ReadLine();
                        try
                        {
                            int a = Int32.Parse(ticketInput);
                            cinema.BuyTicket(a);
                        } catch (FormatException)
                        {
                        }
                        break;
                    case "4":
                        Console.WriteLine("There has been purchased: " + cinema.PurchasedTickets() + " tickets\n");
                        break;
                    case "5":
                        Console.WriteLine("The percentage of occupied seats are: " + cinema.PercentagePurchased() + " %\n");
                        break;
                    case "6":
                        Console.WriteLine("The current income of the cinema is: " + cinema.CurrentIncome() +"$\n");
                        break;
                    case "7":
                        Console.WriteLine("The potential income of the cinema is: " + cinema.PotentialIncome() +"$\n");
                        break;
                    case "exit":
                        Console.WriteLine("You have decided to exit the backend of the Cinema App.");
                        Console.WriteLine("Thank you for your visit");
                        break;
                    default:
                        Console.WriteLine("I did not understand your action.");
                        CinemaAppSelections();
                        break;

                }
                    

            }

        }
    }
}

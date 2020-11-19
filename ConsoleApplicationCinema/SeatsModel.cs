using System;
using System.Collections.Generic;

namespace ConsoleApplicationCinema
{
    class Seat
    {
        public int seatID {get; set;}
        public bool reserved {get; set;}
        public int price {get; set;}

        public Seat(int ID, int cost)
        {
            seatID = ID;
            reserved = false;
            price = cost;
        }

    }
}
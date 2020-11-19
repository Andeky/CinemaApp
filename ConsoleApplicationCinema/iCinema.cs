public interface ICinema
{
    void ShowSeats();
    int PurchasedTickets();
    float PercentagePurchased();
    int CurrentIncome();
    int PotentialIncome();
    void BuyTicket(int seatNumber);
}
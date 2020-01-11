namespace Library.Models
{
    public class ReservedPublication
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
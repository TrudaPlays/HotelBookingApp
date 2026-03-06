using System;
namespace HotelBooking
{
    public sealed class Booking
    {
        //Public Variables Required by the assignment
        public string RoomNumber { get; }
        public string GuestName { get; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public Booking(string roomNumber, string guestName, DateTime checkIn,
        DateTime checkOut)
        {
            //Check if the roomNumber or guestName are null or whitespace and throw
            //an exception that they are required
        //Check if checkOut is before checkIn with <=. Throw an exception
        //if true
        //If they validate, assign the instance variables here:
}
        public void Reschedule(DateTime newIn, DateTime newOut)
        {
         //Check if the newOut DateTime is before newIn. Use <= and throw an
        //exception if true
        //If not, set the Check In and Check Out times to the new ones
}
//Create an override for ToString
//Print according to assignment guidelines: [{RoomNumber}]
//{CheckIn:MM/dd HH:mm
  //  }–{CheckOut:MM/dd HH:mm
//}
//{ GuestName}
    }
}
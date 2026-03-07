using System;

namespace HotelBooking
{
    public sealed class Booking
    {
        public string RoomNumber { get; }
        public string GuestName { get; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        // Constructor with validation
        public Booking(string roomNumber, string guestName, DateTime checkIn, DateTime checkOut)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                throw new ArgumentException("Room number is required.", nameof(roomNumber));
            }

            if (string.IsNullOrWhiteSpace(guestName))
            {
                throw new ArgumentException("Guest name is required.", nameof(guestName));
            }

            if (checkOut <= checkIn)
            {
                throw new ArgumentException("Check-out date/time must be after check-in date/time.");
            }

            // All validations passed → assign values
            RoomNumber = roomNumber.Trim();
            GuestName = guestName.Trim();
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        // Method to change booking dates (with validation)
        public void Reschedule(DateTime newCheckIn, DateTime newCheckOut)
        {
            if (newCheckOut <= newCheckIn)
            {
                throw new ArgumentException("New check-out date/time must be after new check-in date/time.");
            }

            CheckIn = newCheckIn;
            CheckOut = newCheckOut;
        }

        // Override ToString for nice display in ListView / ListBox
        public override string ToString()
        {
            // Format matches common assignment style:
            // [101] 03/15 14:00 – 03/18 11:00   John Smith

            string dateFormat = "MM/dd HH:mm";
            return $"[{RoomNumber}] {CheckIn.ToString(dateFormat)} – " + $"{CheckOut.ToString(dateFormat)}   {GuestName}";
        }
    }
}
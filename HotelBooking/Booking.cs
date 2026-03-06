using System;

namespace HotelBooking
{
    public sealed class Booking
    {
        public string RoomNumber { get; }
        public string GuestName { get; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public Booking(string roomNumber, string guestName, DateTime checkIn, DateTime checkOut)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                throw new ArgumentException("Room number is required.", nameof(roomNumber));
            }

            if (string.IsNullOrWhiteSpace(guestName))
            {
                throw new ArgumentException("Guest name is required.", nameof(guestName));
            }

            // Validate date logic
            if (checkOut <= checkIn)
            {
                throw new ArgumentException("Check-out date must be after check-in date.", nameof(checkOut));
            }

            // All validations passed → assign values
            RoomNumber = roomNumber;
            GuestName = guestName;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public void Reschedule(DateTime newIn, DateTime newOut)
        {
            if (newOut <= newIn)
            {
                throw new ArgumentException("New check-out date must be after new check-in date.", nameof(newOut));
            }

            // Update the dates
            CheckIn = newIn;
            CheckOut = newOut;
        }

        public override string ToString()
        {
            // Format: [101] 03/15 14:00–03/18 11:00 John Doe
            return $"[{RoomNumber}] {CheckIn:MM/dd HH:mm}–{CheckOut:MM/dd HH:mm} {GuestName}";
        }
    }
}
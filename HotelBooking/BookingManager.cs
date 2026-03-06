using HotelBooking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
namespace HotelBooking
{
    public sealed class BookingManager
    {
        private readonly List<Booking> _bookings = new();
        public IReadOnlyList<Booking> All() => _bookings.OrderBy(b => b.CheckIn).ToList();
        public void AddBooking(Booking b)
        {
            if (b == null)
                throw new ArgumentNullException(nameof(b));

            if (string.IsNullOrWhiteSpace(b.RoomNumber))
                throw new ArgumentException("Room number is required.", nameof(b.RoomNumber));

            if (string.IsNullOrWhiteSpace(b.GuestName))
                throw new ArgumentException("Guest name is required.", nameof(b.GuestName));

            if (b.CheckIn >= b.CheckOut)
                throw new ArgumentException("Check-out must be after check-in.");
            //Call EnsureNoOverlap. If it passes, add the booking
            EnsureNoOverlap(b.RoomNumber, b.CheckIn, b.CheckOut, except: null);

            _bookings.Add(b);
        }


        public bool CancelBooking(string roomNumber, string guestName)
        {
            // Find the exact booking (case-insensitive comparison)
            var toRemove = _bookings.FirstOrDefault(b =>
                b.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase) &&
                b.GuestName.Equals(guestName, StringComparison.OrdinalIgnoreCase));

            if (toRemove == null)
                return false;           // not found

            _bookings.Remove(toRemove);
            return true;                // successfully cancelled
        }
        public bool TryFindBooking(string roomNumber, string guestName, out Booking?
        booking)
        {
        /*check the entire list for that booking based on room number and guest
            name.
        if the reservation exists, return the booking != null*/
}
/*Create a public bool IsAvailable() pass in roomNumber and DateTime
for checkIn and checkOut
//Use a try catch block run EnsureNoOverlap. Return true if successful,
catch and return false if not*/


//!!! Helper method for you to check if a room has an overlapping
//visit.Do not modify
    private void EnsureNoOverlap(string roomNumber, DateTime checkIn, DateTime checkOut, Booking? except)
        {
            bool Overlaps(Booking a) => a.CheckIn < checkOut && checkIn <
            a.CheckOut;
            foreach (var existing in _bookings)
            {
                if (except != null && ReferenceEquals(existing, except)) continue;
                if (!existing.RoomNumber.Equals(roomNumber,
                StringComparison.OrdinalIgnoreCase)) continue;
                if (Overlaps(existing))
                {
                    throw new InvalidOperationException(
                    $"Room {roomNumber} already booked {existing.CheckIn:MM/dd/HH:mm}–{existing.CheckOut:MM/dd HH:mm}.");
                }
            }
        }
    }
}

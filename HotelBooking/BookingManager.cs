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
            //Call EnsureNoOverlap via the IsAvailable method. If it passes, add the booking

            if (IsAvailable(b.RoomNumber, b.CheckIn, b.CheckOut))
            {
                _bookings.Add(b);
            }

            else if (b == null)
                { throw new ArgumentNullException(nameof(b)); }

            else if (string.IsNullOrWhiteSpace(b.RoomNumber)) //
                { throw new ArgumentException("Room number is required.", nameof(b.RoomNumber)); }

            else if (string.IsNullOrWhiteSpace(b.GuestName)) //checks for an empty textbox
                { throw new ArgumentException("Guest name is required.", nameof(b.GuestName)); }

            else if (b.CheckIn >= b.CheckOut) //checks that the check in and check out dates aren't equal
                { throw new ArgumentException("Check-out must be after check-in."); }

            else if (b.CheckIn <= DateTime.Now) //checks to make sure that the checkin time isn't before the current date
            {
                throw new ArgumentException($"Check-In must be after {DateTime.Now}");
            }
        }


        public bool CancelBooking(string roomNumber, string guestName)
        {
            // Find the exact booking (case-insensitive comparison)
            var toRemove = _bookings.FirstOrDefault(b =>
                b.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase) &&
                b.GuestName.Equals(guestName, StringComparison.OrdinalIgnoreCase));

            if (toRemove == null)
            {
                return false;// not found
            }
            else
            {
                _bookings.Remove(toRemove);
                return true;// successfully cancelled
            }
        }

        public bool TryFindBooking(string roomNumber, string guestName, out Booking?
        booking)
        {
            booking = _bookings.FirstOrDefault(b =>
            b.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase) &&
            b.GuestName.Equals(guestName, StringComparison.OrdinalIgnoreCase));

            return booking != null;
        }
        /*Created a public bool IsAvailable() passes in roomNumber and DateTime
        for checkIn and checkOut
        //Used a try catch block run EnsureNoOverlap. Returns true if successful,
        catch and returns false if not*/

        public bool IsAvailable(string roomNumber, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                EnsureNoOverlap(roomNumber, checkIn, checkOut, except: null);
                return true;   // no exception = available
            }
            catch (InvalidOperationException)
            {
                return false;  // overlap found
            }
        }

        //method to reschedule booking
        public void RescheduleBooking(string roomNumber, string guestName, DateTime newCheckIn, DateTime newCheckOut)
        {
            // Find the booking to reschedule
            if (!TryFindBooking(roomNumber, guestName, out Booking? booking) || booking == null)
            {
                throw new InvalidOperationException($"No booking found for guest '{guestName}' in room '{roomNumber}'.");
            }

            // Check for overlap with OTHER bookings (exclude this one)
            EnsureNoOverlap(roomNumber, newCheckIn, newCheckOut, except: booking);

            // If no overlap → apply the change
            booking.Reschedule(newCheckIn, newCheckOut);
        }


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

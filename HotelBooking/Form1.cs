using HotelBooking;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelBooking
{
    public partial class MainForm : Form
    {
        private readonly BookingManager booking_manager = new BookingManager();

        public MainForm()
        {
            InitializeComponent();

            checkInTime.Format = DateTimePickerFormat.Short;
            checkOutTime.Format = DateTimePickerFormat.Short;

        }

        private void RefreshBookingsList()
        {
            var bookings = booking_manager.All();
            listBookings.Items.Clear();

            foreach (var booking in bookings)
            {
                listBookings.Items.Add(booking.ToString());
            }
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty; //reset my message box to empty
            labelMessage.BackColor = Color.White;

            try
            {
                // Create Booking – constructor will validate dates and trim strings
                var booking = new Booking(
                    roomNumber: roomNumber.Text,
                    guestName: guestName.Text,
                    checkIn: checkInTime.Value,
                    checkOut: checkOutTime.Value
                );

                // Attempt to add the booking – will throw on overlap or other issues
                booking_manager.AddBooking(booking);

                // Success
                labelMessage.Text = "Booking added successfully!";
                labelMessage.BackColor = Color.LightGreen;

                // Clear input fields after successful booking
                roomNumber.Clear();
                guestName.Clear();
                checkInTime.Value = DateTime.Today;
                checkOutTime.Value = DateTime.Today.AddDays(1);

                RefreshBookingsList();
            }
            catch (ArgumentException ex)
            {
                //validation fails, missing fields, invalid dates etc
                labelMessage.Text = ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
            catch (InvalidOperationException ex)
            {
                //room overlap, the room is already booked
                labelMessage.Text = ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
            catch (Exception ex)
            {
                //unexpected problems that i didn't catch earlier
                labelMessage.Text = "Unexpected error: " + ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }

        }

        private void btnExit_Click(object sender, EventArgs e) //exits the booking manager
        {
            Close();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            // Clears all user-entered data
            roomNumber.Text = string.Empty;
            guestName.Text = string.Empty;

            // Resets the dates to today → tomorrow
            checkInTime.Value = DateTime.Today;
            checkOutTime.Value = DateTime.Today.AddDays(1);

            // Reset feedback area
            labelMessage.Text = "Form cleared – enter new booking details.";
            labelMessage.BackColor = Color.FromArgb(240, 240, 240);

            // focuses on first input field: guestName
            guestName.Focus();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty; //reset my message box to empty
            labelMessage.BackColor = Color.White;

            try
            {
                string room = roomNumber.Text.Trim();
                string guest = guestName.Text.Trim();

                if (string.IsNullOrWhiteSpace(room))
                {
                    throw new ArgumentException("Room number is required to cancel a booking.");
                }

                if (string.IsNullOrWhiteSpace(guest))
                {
                    throw new ArgumentException("Guest name is required to cancel a booking.");
                }

                bool cancelled = booking_manager.CancelBooking(room, guest);

                if (cancelled)
                {
                    labelMessage.Text = $"Booking for {guest} in room {room} was successfully cancelled.";
                    labelMessage.BackColor = Color.LightGreen;

                    // Clear the input fields after success
                    roomNumber.Clear();
                    guestName.Clear();

                    // Optional: reset dates too
                    checkInTime.Value = DateTime.Today;
                    checkOutTime.Value = DateTime.Today.AddDays(1);

                    guestName.Focus();

                    RefreshBookingsList();
                }
                else
                {
                    // Not found → friendly message
                    labelMessage.Text = $"No booking found for {guest} in room {room}.";
                    labelMessage.BackColor = Color.LightYellow;   // warning color, not error
                }
            }
            catch (ArgumentException ex)
            {
                // Missing room or guest name
                labelMessage.Text = ex.Message;
                labelMessage.BackColor = Color.LightYellow;
            }
            catch (Exception ex)
            {
                // Anything unexpected
                labelMessage.Text = "Error during cancellation: " + ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty;
            labelMessage.BackColor = SystemColors.Window;

            try
            {
                var bookings = booking_manager.All();

                listBookings.Items.Clear();

                if (bookings.Count == 0)
                {
                    labelMessage.Text = "No current bookings.";
                    labelMessage.BackColor = Color.LightYellow;
                    return;
                }

                foreach (var b in bookings)
                {
                    listBookings.Items.Add(b.ToString());
                }

                labelMessage.Text = $"Showing {bookings.Count} booking{(bookings.Count != 1 ? "s" : "")}.";
                labelMessage.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error loading bookings: " + ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
        }

        private void btnRescheduleBooking_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty;
            labelMessage.BackColor = SystemColors.Window;

            try
            {
                string room = roomNumber.Text.Trim();
                string guest = guestName.Text.Trim();

                // Basic input checks
                if (string.IsNullOrWhiteSpace(room))
                {
                    throw new ArgumentException("Room number is required to reschedule.");
                }

                if (string.IsNullOrWhiteSpace(guest))
                {
                    throw new ArgumentException("Guest name is required to reschedule.");
                }

                //new values for the rescheduled booking
                DateTime newCheckIn = checkInTime.Value;
                DateTime newCheckOut = checkOutTime.Value;


            }
            catch
            {

            }

        }
    }
}
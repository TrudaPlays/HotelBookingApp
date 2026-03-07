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
using System.IO;
using File = System.IO.File;

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

        //logging file path
        private string GetLogFilePath()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path.Combine(desktop, "log.txt");
        }

        //appending the log to the txt file
        private void LogSuccess(string message)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string line = $"[{timestamp}] {message}{Environment.NewLine}";

                string path = GetLogFilePath();
                File.AppendAllText(path, line);
            }
            catch
            {
                // Silent fail – doesn't crash the app if desktop write fails
            }
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
                    checkIn: checkInTime.Value.Date,
                    checkOut: checkOutTime.Value.Date
                );

                // Attempt to add the booking – will throw on overlap or other issues
                booking_manager.AddBooking(booking);

                // Success
                RefreshBookingsList();
                LogSuccess($"New booking created: Room {booking.RoomNumber}, Guest {booking.GuestName}, {booking.CheckIn:yyyy-MM-dd HH:mm} – {booking.CheckOut:yyyy-MM-dd HH:mm}");
                labelMessage.Text = "Booking added successfully!";
                labelMessage.BackColor = Color.LightGreen;

                // Clear input fields after successful booking
                roomNumber.Clear();
                guestName.Clear();
                checkInTime.Value = DateTime.Today;
                checkOutTime.Value = DateTime.Today.AddDays(1);
  
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
                    LogSuccess($"Booking cancelled: Room {room}, Guest {guest}");
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
                LogSuccess($"Viewed all bookings ({bookings.Count} entries)");
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
                DateTime newCheckIn = checkInTime.Value.Date;
                DateTime newCheckOut = checkOutTime.Value.Date;

                // Quick client-side date check (optional but improves UX)
                if (newCheckOut <= newCheckIn)
                {
                    throw new ArgumentException("New check-out must be after new check-in.");
                }

                // Perform the reschedule
                booking_manager.RescheduleBooking(room, guest, newCheckIn, newCheckOut);

                // Success
                labelMessage.Text = $"Booking for {guest} in room {room} has been rescheduled successfully.";
                labelMessage.BackColor = Color.LightGreen;

                //clears the inputs
                roomNumber.Clear();
                guestName.Clear();
                checkInTime.Value = DateTime.Today;
                checkOutTime.Value = DateTime.Today.AddDays(1);

                // refreshes the list to show updated dates
                RefreshBookingsList();
                LogSuccess($"Booking rescheduled: Room {room}, Guest {guest}, New dates {newCheckIn:yyyy-MM-dd HH:mm} – {newCheckOut:yyyy-MM-dd HH:mm}");

            }
            catch (ArgumentException ex)
            {
                // Validation errors (missing fields, invalid dates)
                labelMessage.Text = ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
            catch (InvalidOperationException ex)
            {
                // Not found or overlap
                labelMessage.Text = ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Unexpected error during reschedule: " + ex.Message;
                labelMessage.BackColor = Color.LightPink;
            }

        }
    }
}
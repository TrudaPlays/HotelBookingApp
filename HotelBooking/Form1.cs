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

                // ────────────────────────────────────────────────
                // If you later want to show the new booking immediately:
                // RefreshListView();   // ← we'll implement this later
                // ────────────────────────────────────────────────
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
                labelMessage.BackColor  = Color.LightPink;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
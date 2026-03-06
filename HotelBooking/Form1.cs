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
        private readonly BookingManager manager = new BookingManager();

        public MainForm()
        {
            InitializeComponent();

        }


    }
}
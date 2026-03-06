namespace HotelBooking
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnViewBookings = new Button();
            btnCancelBooking = new Button();
            btnBookRoom = new Button();
            btnExit = new Button();
            labelGuestName = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            labelRoomNumber = new Label();
            labelCheckIn = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            labelCheckOut = new Label();
            listBookings = new ListView();
            labelMessage = new Label();
            SuspendLayout();
            // 
            // btnViewBookings
            // 
            btnViewBookings.Location = new Point(238, 263);
            btnViewBookings.Name = "btnViewBookings";
            btnViewBookings.Size = new Size(211, 34);
            btnViewBookings.TabIndex = 0;
            btnViewBookings.Text = "View All Bookings";
            btnViewBookings.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(491, 263);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(169, 34);
            btnCancelBooking.TabIndex = 1;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            // 
            // btnBookRoom
            // 
            btnBookRoom.Location = new Point(38, 263);
            btnBookRoom.Name = "btnBookRoom";
            btnBookRoom.Size = new Size(152, 34);
            btnBookRoom.TabIndex = 2;
            btnBookRoom.Text = "Book Room";
            btnBookRoom.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(548, 371);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 42);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // labelGuestName
            // 
            labelGuestName.AutoSize = true;
            labelGuestName.Location = new Point(38, 67);
            labelGuestName.Name = "labelGuestName";
            labelGuestName.Size = new Size(109, 25);
            labelGuestName.TabIndex = 4;
            labelGuestName.Text = "Guest Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(153, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(491, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 7;
            // 
            // labelRoomNumber
            // 
            labelRoomNumber.AutoSize = true;
            labelRoomNumber.Location = new Point(355, 67);
            labelRoomNumber.Name = "labelRoomNumber";
            labelRoomNumber.Size = new Size(130, 25);
            labelRoomNumber.TabIndex = 6;
            labelRoomNumber.Text = "Room Number";
            // 
            // labelCheckIn
            // 
            labelCheckIn.AutoSize = true;
            labelCheckIn.Location = new Point(38, 146);
            labelCheckIn.Name = "labelCheckIn";
            labelCheckIn.Size = new Size(122, 25);
            labelCheckIn.TabIndex = 8;
            labelCheckIn.Text = "Check In Time";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(185, 141);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(185, 197);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(300, 31);
            dateTimePicker2.TabIndex = 11;
            // 
            // labelCheckOut
            // 
            labelCheckOut.AutoSize = true;
            labelCheckOut.Location = new Point(38, 202);
            labelCheckOut.Name = "labelCheckOut";
            labelCheckOut.Size = new Size(137, 25);
            labelCheckOut.TabIndex = 10;
            labelCheckOut.Text = "Check Out Time";
            // 
            // listBookings
            // 
            listBookings.Location = new Point(238, 326);
            listBookings.Name = "listBookings";
            listBookings.Size = new Size(182, 146);
            listBookings.TabIndex = 12;
            listBookings.UseCompatibleStateImageBehavior = false;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(38, 380);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 25);
            labelMessage.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 494);
            Controls.Add(labelMessage);
            Controls.Add(listBookings);
            Controls.Add(dateTimePicker2);
            Controls.Add(labelCheckOut);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelCheckIn);
            Controls.Add(textBox2);
            Controls.Add(labelRoomNumber);
            Controls.Add(textBox1);
            Controls.Add(labelGuestName);
            Controls.Add(btnExit);
            Controls.Add(btnBookRoom);
            Controls.Add(btnCancelBooking);
            Controls.Add(btnViewBookings);
            Name = "MainForm";
            Text = "HotelBooking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnViewBookings;
        private Button btnCancelBooking;
        private Button btnBookRoom;
        private Button btnExit;
        private Label labelGuestName;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label labelRoomNumber;
        private Label labelCheckIn;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label labelCheckOut;
        private ListView listBookings;
        private Label labelMessage;
    }
}

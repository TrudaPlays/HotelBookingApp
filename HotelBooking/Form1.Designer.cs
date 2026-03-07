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
            guestName = new TextBox();
            roomNumber = new TextBox();
            labelRoomNumber = new Label();
            labelCheckIn = new Label();
            checkInTime = new DateTimePicker();
            checkOutTime = new DateTimePicker();
            labelCheckOut = new Label();
            listBookings = new ListView();
            labelMessage = new Label();
            btnClearForm = new Button();
            btnRescheduleBooking = new Button();
            SuspendLayout();
            // 
            // btnViewBookings
            // 
            btnViewBookings.Location = new Point(267, 263);
            btnViewBookings.Name = "btnViewBookings";
            btnViewBookings.Size = new Size(211, 34);
            btnViewBookings.TabIndex = 0;
            btnViewBookings.Text = "View All Bookings";
            btnViewBookings.UseVisualStyleBackColor = true;
            btnViewBookings.Click += btnViewBookings_Click;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(38, 326);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(169, 34);
            btnCancelBooking.TabIndex = 1;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnBookRoom
            // 
            btnBookRoom.Location = new Point(38, 263);
            btnBookRoom.Name = "btnBookRoom";
            btnBookRoom.Size = new Size(152, 34);
            btnBookRoom.TabIndex = 2;
            btnBookRoom.Text = "Book Room";
            btnBookRoom.UseVisualStyleBackColor = true;
            btnBookRoom.Click += btnBookRoom_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(645, 433);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 42);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
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
            // guestName
            // 
            guestName.Location = new Point(153, 61);
            guestName.Name = "guestName";
            guestName.Size = new Size(150, 31);
            guestName.TabIndex = 5;
            // 
            // roomNumber
            // 
            roomNumber.Location = new Point(491, 61);
            roomNumber.Name = "roomNumber";
            roomNumber.Size = new Size(150, 31);
            roomNumber.TabIndex = 7;
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
            // checkInTime
            // 
            checkInTime.Location = new Point(185, 141);
            checkInTime.Name = "checkInTime";
            checkInTime.Size = new Size(300, 31);
            checkInTime.TabIndex = 9;
            // 
            // checkOutTime
            // 
            checkOutTime.Location = new Point(185, 197);
            checkOutTime.Name = "checkOutTime";
            checkOutTime.Size = new Size(300, 31);
            checkOutTime.TabIndex = 11;
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
            listBookings.FullRowSelect = true;
            listBookings.GridLines = true;
            listBookings.Location = new Point(513, 197);
            listBookings.MultiSelect = false;
            listBookings.Name = "listBookings";
            listBookings.Size = new Size(483, 208);
            listBookings.TabIndex = 12;
            listBookings.UseCompatibleStateImageBehavior = false;
            listBookings.View = View.List;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(38, 380);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 25);
            labelMessage.TabIndex = 13;
            // 
            // btnClearForm
            // 
            btnClearForm.Location = new Point(513, 433);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(112, 34);
            btnClearForm.TabIndex = 14;
            btnClearForm.Text = "Clear Form";
            btnClearForm.UseVisualStyleBackColor = true;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // btnRescheduleBooking
            // 
            btnRescheduleBooking.Location = new Point(272, 326);
            btnRescheduleBooking.Name = "btnRescheduleBooking";
            btnRescheduleBooking.Size = new Size(206, 34);
            btnRescheduleBooking.TabIndex = 15;
            btnRescheduleBooking.Text = "Reschedule Booking";
            btnRescheduleBooking.UseVisualStyleBackColor = true;
            btnRescheduleBooking.Click += btnRescheduleBooking_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.HotPink;
            ClientSize = new Size(1008, 494);
            Controls.Add(btnRescheduleBooking);
            Controls.Add(btnClearForm);
            Controls.Add(labelMessage);
            Controls.Add(listBookings);
            Controls.Add(checkOutTime);
            Controls.Add(labelCheckOut);
            Controls.Add(checkInTime);
            Controls.Add(labelCheckIn);
            Controls.Add(roomNumber);
            Controls.Add(labelRoomNumber);
            Controls.Add(guestName);
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
        private TextBox guestName;
        private TextBox roomNumber;
        private Label labelRoomNumber;
        private Label labelCheckIn;
        private DateTimePicker checkInTime;
        private DateTimePicker checkOutTime;
        private Label labelCheckOut;
        private ListView listBookings;
        private Label labelMessage;
        private Button btnClearForm;
        private Button btnRescheduleBooking;
    }
}

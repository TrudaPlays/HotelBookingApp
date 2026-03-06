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
            SuspendLayout();
            // 
            // btnViewBookings
            // 
            btnViewBookings.Location = new Point(449, 263);
            btnViewBookings.Name = "btnViewBookings";
            btnViewBookings.Size = new Size(211, 34);
            btnViewBookings.TabIndex = 0;
            btnViewBookings.Text = "View All Bookings";
            btnViewBookings.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(238, 263);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnBookRoom);
            Controls.Add(btnCancelBooking);
            Controls.Add(btnViewBookings);
            Name = "MainForm";
            Text = "HotelBooking";
            ResumeLayout(false);
        }

        #endregion

        private Button btnViewBookings;
        private Button btnCancelBooking;
        private Button btnBookRoom;
        private Button btnExit;
    }
}

“How did creating a graphical interface change how you thought about user interaction and error handling?”

Creating a graphical interface was number 1 very fun! I enjoy a blend of graphical and coding, and this winform project
was just that. User interaction was in a way much more simple to implement as I knew exactly where to put it:
the btn_clicked event handlers. I knew that when the button was clicked, an event would fire and the code would try
to do a set thing, such as book a room, reschedule a booking, cancel a booking and view all the bookings. By enclosing
what i wanted the button to do in a try/catch block i could try to add the booking for example, and then catch
exceptions depending on whether the guestName is blank, the booking is overlapping etc...
By using OOP and encapsulation, I was able to mess around with exception handling and throwing in each method without worrying
about the entire code getting mussed up if i forgot to add the right exception throwing in the right place.
Particularly in this code I learned the importance of making sure there is a final else block in the sequence of if/elseif/else 
blocks that sift through different errors. Without a final else block, my code did indeed throw the right exceptions and execute
the right code, but it didn't print the correct error message to my message textbox!

using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(Guid BookingId) : ICommand;
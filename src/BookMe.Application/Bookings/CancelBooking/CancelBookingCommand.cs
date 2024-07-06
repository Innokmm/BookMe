using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Bookings.CancelBooking;

public record CancelBookingCommand(Guid BookingId) : ICommand;
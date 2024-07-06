using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Bookings.CompleteBooking;

public record CompleteBookingCommand(Guid BookingId) : ICommand;
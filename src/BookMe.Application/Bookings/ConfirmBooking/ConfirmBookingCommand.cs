using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Bookings.ConfirmBooking;

public sealed record ConfirmBookingCommand(Guid BookingId) : ICommand;
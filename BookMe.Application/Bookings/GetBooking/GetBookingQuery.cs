using System.Runtime.InteropServices.JavaScript;
using BookMe.Application.Abstractions.Messaging;

namespace BookMe.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
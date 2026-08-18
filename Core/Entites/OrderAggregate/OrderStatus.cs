namespace Core.Entites.OrderAggregate;

public enum OrderStatus
{
    Pending,
    PaymentReceived,
    PaymentFailed,
    PaymentMismatch,
    Refunded
}
namespace Shipping.Domain.Enums
{
    public enum PriorityLevel
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
    public enum UserType
    {
        Customer = 1,
        Manager,
        Staff
    }

    public enum ShipmentStatus
    {
        Draft = 1,
        Delivering,
        Delivered,
        returned,
    }
}

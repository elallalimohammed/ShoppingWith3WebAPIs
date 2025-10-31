using PaymentsWebAPI.Models;

namespace PaymentsWebAPI.Repositories
{
    public class PaymentRepository
    {
        
            private static readonly List<Payment> _payments = new();

            public Payment PerformPayment(Payment payment)
            {
                payment.Id = _payments.Count + 1;
                payment.Success = true; // simulate successful payment
                _payments.Add(payment);
                return payment;
            }
    }
    
}

namespace ConsoleApp.TestExample
{
    public class PaymentHandler
    {
        private CardPaymentSystem system;

        PaymentHandler(CardPaymentSystem system)
        {
            this.system = system;
        }
        
        public bool HasFunds(float amount)
        {
            if (system.Saldo >= amount)
                return true;
            return false;
        }
    }

    public class CardPaymentSystem
    {
        public float Saldo { get; }
    }
}
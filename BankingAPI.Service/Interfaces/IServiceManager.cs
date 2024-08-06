namespace BankingAPI.Service.Interfaces
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        ICustomerService CustomerService { get; }
        ITransactionService TransactionService { get; }
        ICreditCardService CreditCardService { get; }
        IDebitCardService DebitCardService { get; }
    }
}

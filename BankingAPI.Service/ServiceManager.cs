using BankingAPI.Service.Interfaces;

namespace BankingAPI.Service
{
    public class ServiceManager : IServiceManager
    {
        #region Service fields
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;
        private readonly ICreditCardService _creditCardService;
        private readonly IDebitCardService _debitCardService;
        #endregion
        public ServiceManager(IAccountService accountService, ICustomerService customerService, ITransactionService transactionService, ICreditCardService creditCardService, IDebitCardService debitCardService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionService = transactionService;
            _creditCardService = creditCardService;
            _debitCardService = debitCardService;
        }
        #region Service properties
        public IAccountService AccountService => _accountService;
        public ICustomerService CustomerService => _customerService;
        public ITransactionService TransactionService => _transactionService;
        public ICreditCardService CreditCardService => _creditCardService;
        public IDebitCardService DebitCardService => _debitCardService;
        #endregion
    }
}

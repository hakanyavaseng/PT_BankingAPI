using AutoMapper;
using BankingAPI.Core.DTOs.Transactions;
using BankingAPI.Core.Entities;
using BankingAPI.Core.Enums;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TransactionService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<int> CreateTransactionAsync(CreateTranscationDto transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            if (transaction.CreditCardId != null && transaction.DebitCardId != null)
                throw new ArgumentException("Transaction cannot have both CreditCardId and DebitCardId");

            if (transaction.CreditCardId == null && transaction.DebitCardId == null)
                throw new ArgumentException("Transaction must have either CreditCardId or DebitCardId");

            if (transaction.Amount <= 0)
                throw new ArgumentException("Amount must be greater than 0");

            CardType cardType;
            TransactionType transactionType;

            // Determine card type and validate
            if (transaction.CreditCardId > 0)
            {
                var creditCard = await _repositoryManager.GetReadRepository<CreditCard>().GetAsync(p => p.Id == transaction.CreditCardId);
                if (creditCard == null)
                    throw new ArgumentException("Credit Card not found");
                if (!creditCard.IsActive)
                    throw new ArgumentException("Credit Card is not active");
                cardType = CardType.Credit;
            }
            else
            {
                var debitCard = await _repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.Id == transaction.DebitCardId, include: a => a.Include(a => a.Account));
                if (debitCard == null)
                    throw new ArgumentException("Debit Card not found");
                if (!debitCard.IsActive)
                    throw new ArgumentException("Debit Card is not active");
                cardType = CardType.Debit;
            }

            // Determine transaction type
            transactionType = transaction.TransactionType switch
            {
                "Income" => TransactionType.Income,
                "Outcome" => TransactionType.Outcome,
                _ => throw new ArgumentException("Invalid Transaction Type")
            };

            var newTransaction = new Transaction
            {
                CardType = cardType.ToString(),
                TransactionType = transactionType.ToString(),
                DebitCardId = transaction.DebitCardId,
                CreditCardId = transaction.CreditCardId,
                Amount = transaction.Amount,
                Description = transaction.Description,
                TransactionDate = DateTime.UtcNow
            };

            await using var transactionScope = await _repositoryManager.DbContext.Database.BeginTransactionAsync();

            try
            {
                await _repositoryManager.GetWriteRepository<Transaction>().AddAsync(newTransaction);

                if (await _repositoryManager.DbContext.SaveChangesAsync() > 0)
                {
                    if (cardType == CardType.Debit)
                    {
                        var debitCard = await _repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.Id == transaction.DebitCardId, include: a => a.Include(a => a.Account), enableTracking: true);
                        if (debitCard == null)
                            throw new Exception("Debit Card not found during balance update");

                        if (transactionType == TransactionType.Outcome)
                        {
                            if (debitCard.Account.Balance < transaction.Amount)
                                throw new ArgumentException("Debit Card limit exceeded");

                            debitCard.Account.Balance -= (long)transaction.Amount;
                        }
                        else
                        {
                            debitCard.Account.Balance += (long)transaction.Amount;
                        }
                    }
                    else
                    {
                        var creditCard = await _repositoryManager.GetReadRepository<CreditCard>().GetAsync(p => p.Id == transaction.CreditCardId, enableTracking: true);
                        if (creditCard == null)
                            throw new Exception("Credit Card not found during limit update");

                        if (transactionType == TransactionType.Outcome)
                        {
                            if (creditCard.Limit < transaction.Amount)
                                throw new ArgumentException("Credit Card limit exceeded");

                            creditCard.Limit -= transaction.Amount;
                        }
                        else
                        {
                            creditCard.Limit += transaction.Amount;
                        }
                    }

                    await _repositoryManager.DbContext.SaveChangesAsync();
                    await transactionScope.CommitAsync();

                    return newTransaction.Id;
                }
                else
                {
                    throw new Exception("An error occurred while saving changes");
                }
            }
            catch (Exception)
            {
                await transactionScope.RollbackAsync();
                throw;
            }
        }

      
        public async Task<ListTranscationDto> GetTransactionByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid transaction id");

            Transaction? transaction = await _repositoryManager.GetReadRepository<Transaction>().GetAsync(p => p.Id.Equals(id));
            if (transaction == null)
                throw new Exception("Transaction not found");

            var dto = new ListTranscationDto()
            {
                Id = transaction.Id,
                CardType = transaction.CardType,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                Description = transaction.Description,
                DebitCardId = transaction.DebitCardId,
                CreditCardId = transaction.CreditCardId,
                TransactionDate = transaction.TransactionDate
            };

            return dto;

        }

        public async Task<IEnumerable<ListTranscationDto>> GetTransactionsAsync()
        {
            IList<Transaction> transactions = await _repositoryManager.GetReadRepository<Transaction>().GetAllAsync();
            List<ListTranscationDto> dtos = new();

            foreach(var transcation in transactions)
            {
                dtos.Add(new ListTranscationDto()
                {
                    Id = transcation.Id,
                    CardType = transcation.CardType,
                    TransactionType = transcation.TransactionType,
                    Amount = transcation.Amount,
                    Description = transcation.Description,
                    DebitCardId = transcation.DebitCardId,
                    CreditCardId = transcation.CreditCardId,
                    TransactionDate = transcation.TransactionDate
                });
            }

            return dtos;
        }

        public Task<bool> UpdateTransactionAsync(UpdateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}

using AutoMapper;
using BankingAPI.Core.DTOs.Cards.CreditCards;
using BankingAPI.Core.Entities;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Helpers;
using BankingAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BankingAPI.Service.Concretes
{
    public class CreditCartService : ICreditCardService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        public CreditCartService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }
        public async Task<int> CreateCreditCardAsync(CreateCreditCardDto creditCard)
        {
            if (creditCard is null)
                throw new Exception("Credit card is null");

            if (creditCard.CustomerId <= 0)
                throw new Exception("Invalid customer id");

            Customer? customer = await repositoryManager.GetReadRepository<Customer>().GetAsync(p => p.Id.Equals(creditCard.CustomerId));
            if (customer is null)
                throw new Exception("Customer not found with given customer id");

            //Credit card informations
            string cardNumber = CardGenerator.GenerateNumber(16);
            while (await repositoryManager.GetReadRepository<CreditCard>().GetAsync(p => p.CardNumber.Equals(cardNumber)) is not null)
                cardNumber = CardGenerator.GenerateNumber(16);


            string cvv = CardGenerator.GenerateNumber(3);
            string expirationDate = CardGenerator.GenerateExpirationDate();

            CreditCard card = new CreditCard
            {
                CardNumber = cardNumber,
                CVV = Convert.ToInt16(cvv),
                ExpiryMonth = Convert.ToInt16(expirationDate.Split(".")[0]),
                ExpiryYear = Convert.ToInt16(expirationDate.Split(".")[1]),
                CustomerId = creditCard.CustomerId,
                Limit = customer.RiskLimit
            };

            await repositoryManager.GetWriteRepository<CreditCard>().AddAsync(card);
            return await repositoryManager.SaveAsync();
        }

        public async Task<bool> DeleteCreditCardAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid credit card id");

            var creditCard = await repositoryManager.GetReadRepository<CreditCard>().GetAsync(p => p.Id.Equals(id));
            if (creditCard is null)
                throw new Exception("Credit card not found");

            await repositoryManager.GetWriteRepository<CreditCard>().DeleteAsync(creditCard);
            return await repositoryManager.SaveAsync() > 0;
        }

        public async Task<ListCreditCardDto> GetCreditCardByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid credit card id");

            var creditCard = await repositoryManager.GetReadRepository<CreditCard>().GetAsync(p => p.Id.Equals(id));
            if (creditCard is null)
                throw new Exception("Credit card not found");
            return mapper.Map<ListCreditCardDto>(creditCard);
        }

        public async Task<IEnumerable<ListCreditCardDto>> GetCreditCardsAsync()
        {
            IList<CreditCard> creditCards = await repositoryManager.GetReadRepository<CreditCard>().GetAllAsync(include: p => p.Include(c => c.Customer));
            return mapper.Map<IEnumerable<ListCreditCardDto>>(creditCards);
        }

        public Task<bool> UpdateCreditCardAsync(UpdateCreditCardDto creditCard)
        {
            throw new NotImplementedException();
        }
    }
}

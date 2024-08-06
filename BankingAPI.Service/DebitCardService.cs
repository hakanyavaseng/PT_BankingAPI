using AutoMapper;
using BankingAPI.Core.DTOs.Cards.DebitCards;
using BankingAPI.Core.Entities;
using BankingAPI.Data.Repositories.Interfaces;
using BankingAPI.Service.Helpers;
using BankingAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Service
{
    public class DebitCartService : IDebitCardService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        public DebitCartService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }
        public async Task<int> CreateDebitCardAsync(CreateDebitCardDto dto)
        {
            if (dto is null)
                throw new Exception("Debit card is null");

            if (dto.CustomerId <= 0)
                throw new Exception("Invalid customer id");

            Customer? customer = await repositoryManager.GetReadRepository<Customer>().GetAsync(p => p.Id.Equals(dto.CustomerId));
            if (customer is null)
                throw new Exception("Customer not found with given customer id");

            //Credit card informations
            string cardNumber = CardGenerator.GenerateNumber(16);
            while (await repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.CardNumber.Equals(cardNumber)) is not null)
                cardNumber = CardGenerator.GenerateNumber(16);
            string cvv = CardGenerator.GenerateNumber(3);
            string expirationDate = CardGenerator.GenerateExpirationDate();

            DebitCard card = new DebitCard
            {
                CardNumber = cardNumber,
                CardHolderName = customer.FullName,
                CVV = Convert.ToInt16(cvv),
                ExpiryDate = new DateTime(Convert.ToInt16(expirationDate.Split(".")[1]), Convert.ToInt16(expirationDate.Split(".")[0]), 1),
                CustomerId = dto.CustomerId,
                AccountId = dto.AccountId,
                Limit = customer.RiskLimit
            };

            await repositoryManager.GetWriteRepository<DebitCard>().AddAsync(card);
            return await repositoryManager.SaveAsync();
        }

        public async Task<bool> DeleteDebitCardAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid debit card id");

            var DebitCard = await repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.Id.Equals(id));
            if (DebitCard is null)
                throw new Exception("Debit card not found");

            await repositoryManager.GetWriteRepository<DebitCard>().DeleteAsync(DebitCard);
            return await repositoryManager.SaveAsync() > 0;
        }

        public async Task<ListDebitCardDto> GetDebitCardByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid debit card id");

            var DebitCard = await repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.Id.Equals(id));
            if (DebitCard is null)
                throw new Exception("Debit card not found");
            return mapper.Map<ListDebitCardDto>(DebitCard);
        }

        public async Task<IEnumerable<ListDebitCardDto>> GetDebitCardsAsync()
        {
            IList<DebitCard> DebitCards = await repositoryManager.GetReadRepository<DebitCard>().GetAllAsync(include: p => p.Include(c => c.Customer).Include(a => a.Account));
            return mapper.Map<IEnumerable<ListDebitCardDto>>(DebitCards);
        }

        public async Task<bool> UpdateDebitCardAsync(UpdateDebitCardDto dto)
        {
            if (dto.Id <= 0)
                throw new Exception("Invalid debit card id");

            if(dto.CustomerId <= 0)
                throw new Exception("Invalid customer id");

            if(dto.AccountId <= 0)
                throw new Exception("Invalid account id");

            var cardToUpdate = await repositoryManager.GetReadRepository<DebitCard>().GetAsync(p => p.Id.Equals(dto.Id));

            mapper.Map(dto, cardToUpdate);
            await repositoryManager.GetWriteRepository<DebitCard>().UpdateAsync(cardToUpdate);
            return await repositoryManager.SaveAsync() > 0;
        }
    }
}

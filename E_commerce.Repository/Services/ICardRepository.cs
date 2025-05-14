using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface ICardRepository
{
    Task<long> InsertCardAsync(Card card);
    Task<List<Card>> SelectCardsByCustomerId(long customerId);
    Task<Card?> SelectSelectedCardByCustomerId(long customerId);
    Task AssignCardAsSelectedAsync(long cardId);
    Task AssignCardAsNotSelectedAsync(long cardId);
    Task DeleteCardAsync(long cardId);
}
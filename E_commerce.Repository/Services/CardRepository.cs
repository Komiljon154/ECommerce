using E_commerce.Dal;
using E_commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class CardRepository : ICardRepository
{
    private readonly MainContext MainContext;

    public CardRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public Task AssignCardAsNotSelectedAsync(long cardId)
    {
        throw new NotImplementedException();
    }

    public Task AssignCardAsSelectedAsync(long cardId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCardAsync(long cardId)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertCardAsync(Card card)
    {
        throw new NotImplementedException();
    }

    public Task<List<Card>> SelectCardsByCustomerId(long customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<Card?> SelectSelectedCardByCustomerId(long customerId)
    {
        var card = await MainContext.Cards.
                            FirstOrDefaultAsync(c => c.CustomerId == customerId && c.SelectedForPayment == true);
        return card;
    }
}

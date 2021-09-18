using MTGCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCollection.Interfaces
{
    public interface ICardServices
    {
        Task<Card> BuscarCard(string nome);
        Task<Card> BuscarDetalhes(string nome);
    }
}

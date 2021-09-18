using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MTGCollection.Interfaces;
using MTGCollection.Models;
using MTGCollection.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCollection.Services
{
    public class CardServices : ICardServices
    {
        private readonly ICardService _cardService;

        public CardServices(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<Card> BuscarCard(string nome)
        {
            var card = new Card();
            var cardDetails = await _cardService
                 .Where(x => x.Language, "Portuguese (Brazil)")
                 .Where(x => x.Name, nome)
                 .AllAsync();

            if (cardDetails.IsSuccess && cardDetails.Value.Count > 0)
            {
                var returnedCard = cardDetails.Value.FirstOrDefault();

                card.ManaCost = returnedCard.ManaCost;
                card.Description = returnedCard.OriginalText;
                card.Lore = returnedCard.Flavor;
                card.Collection = returnedCard.SetName;
                card.Power = returnedCard.Power;
                card.Toughness = returnedCard.Toughness;
                card.Image = RetornaMultiverseId(returnedCard.ForeignNames, returnedCard);
                card.Color = returnedCard.IsMultiColor ? EnumColors.Multicolor : returnedCard.IsColorless ? EnumColors.Colorless : (EnumColors)Enum.Parse(typeof(EnumColors), returnedCard.Colors[0], true);
                card.Loyalty = Convert.ToInt32(returnedCard.Loyalty) > 0 ? Convert.ToInt32(returnedCard.Loyalty) : 0;
                card.Type = (EnumTypes)Enum.Parse(typeof(EnumTypes), returnedCard.Types[0], true);   
            }

            return card;
        }

        private string RetornaMultiverseId(List<IForeignName> lista, ICard card)
        {
            var resultado = lista.Where(x => x.Language.Contains("Portuguese") && x.MultiverseId != null).Any() ? lista.Where(x => x.Language.Contains("Portuguese")).Select(x => x.MultiverseId).FirstOrDefault() : Convert.ToInt32(card.MultiverseId);
            
            if (!resultado.HasValue)
                return "../images/back.jpg";

            return string.Format("https://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card", resultado);
        }

        public async Task<Card> BuscarDetalhes(string nome)
        {
            throw new NotImplementedException();
        }
    }
}

using MTGCollection.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTGCollection.Models
{
    public class Card
    {
        public Card()
        {
            Id = Guid.NewGuid(); ;
        }

        public string FormatarCustoDeMana(string manaCost)
        {
            if (!string.IsNullOrEmpty(manaCost))
            {
                var listaCustoConvertido = string.Empty;
                var tipos = manaCost.Split("{").Where(x => x.Length > 0);
                var tiposFormatados = tipos.Select(x => x.Replace("}", ""));
                foreach (var t in tiposFormatados)
                {
                    int number;
                    if (int.TryParse(t, out number))
                        listaCustoConvertido += $"<span class='mana small s{number}'></span>";
                    else
                        listaCustoConvertido += $"<span class='mana small s{t.ToLower()}'></span>";
                }
                return listaCustoConvertido;    
            }
            return string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } // Nome da Carta.
        public string ManaCost { get; set; } //Custo de Mana Convertido.
        public EnumTypes Type { get; set; } // Tipo Ex: Criatura.
        public CardSubType SubType { get; set; } // SubTipo Ex: Dragão.
        public string Description { get; set; } // Efeitos da Carta.
        public string Lore { get; set; } //Text box com história sobre a carta.
        public string Collection { get; set; } //Coleção/Expansão.
        public string Power { get; set; } //Poder/Ataque/Dano.
        public string Toughness { get; set; }   //Dureza/Resistencia/Vida.
        public EnumColors Color { get; set; } //Cor.
        public int Loyalty { get; set; } //Lealdade => Planeswalker's.
        public string Side { get; set; } //Identificador de lado ex: A ou B Para cartas com multiplas faces.
        public List<Card> OtherFaceCards { get; set; } //Outras face da carta caso seja de multiplas faces.
        public string Image { get; set; } //Link de imagem da Carta (Buscar do Serviço).
        public string CustoManaConvertido { get { return FormatarCustoDeMana(ManaCost); } }


    }
}

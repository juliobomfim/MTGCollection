using System;

namespace MTGCollection.Models
{
    public class CardSubType
    {
        public CardSubType()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

namespace MTGCollection.Models.ViewModels
{
    public class ModalViewModel
    {
        public ModalViewModel(string type)
        {
            Type = type;
        }

        public ModalViewModel(string type, Card card)
        {
            Type = type;
            Card = card;
        }

        public string Type { get; set; } = "";
        public Card Card { get; set; } = new Card { Name = "" };

    }
}

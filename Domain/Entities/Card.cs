using Domain.Entities;
using Domain.Enum;


namespace Domain.Entities

{
    public class Card:Entity
    {
        public Card( ){}

        public Card(string value, Nipe nipe)
        {
            
            Value = value;
            Nipe = nipe;
        }
        public string Value { get; set; }
        public Nipe Nipe { get; set; }

        
    }
}

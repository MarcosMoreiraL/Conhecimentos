using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    abstract class PlayingCard
    {
        public abstract string Type { get; set; }
        public abstract int Value { get; set; }
        public abstract string Suit { get; set; }
    }

    class HoylePlayingCard : PlayingCard
    {
        private string type, suit;
        private int value;

        public HoylePlayingCard(string suit, int value)
        {
            this.type = "Hoyle";
            this.suit = suit;
            this.value = value;
        }

        public override string Type
        {
            get => type;
            set => type = value;
        }

        public override int Value
        {
            get => value;
            set => this.value = value;
        }

        public override string Suit
        {
            get => suit;
            set => suit = value;
        }
    }

    class CongressPlayingCard : PlayingCard
    {
        private string type, suit;
        private int value;

        public CongressPlayingCard(string suit, int value)
        {
            this.type = "Congress";
            this.suit = suit;
            this.value = value;
        }

        public override string Type
        {
            get => type;
            set => type = value;
        }

        public override int Value
        {
            get => value;
            set => this.value = value;
        }

        public override string Suit
        {
            get => suit;
            set => suit = value;
        }
    }

    abstract class CardFactory
    {
        public abstract PlayingCard GetPlayingCard();
    }

    class HoyleFactory : CardFactory
    {
        private string type, suit;
        private int value;

        public HoyleFactory(string suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override PlayingCard GetPlayingCard()
        {
            return new HoylePlayingCard(suit, value);
        }
    }

    class CongressFactory : CardFactory
    {
        private string type, suit;
        private int value;

        public CongressFactory(string suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override PlayingCard GetPlayingCard()
        {
            return new CongressPlayingCard(suit, value);
        }
    }

    public class Factory
    {
        public static void CardFactoryTest()
        {
            CardFactory factory = null;
            Console.WriteLine("Enter the type of card you would like to create");
            string card = Console.ReadLine();

            switch (card.ToLower())
            {
                case "hoyle":
                    factory = new HoyleFactory("spades", 5);
                    break;
                case "congress":
                    factory = new CongressFactory("hearts", 10);
                    break;
                default:
                    Console.WriteLine("Invalid type!");
                    Console.ReadKey();
                    return;
            }

            PlayingCard playingCard = factory.GetPlayingCard();
            Console.WriteLine("Card type: {0}\nCard value: {1}\n Card suit: {2}\n", playingCard.Type, playingCard.Value, playingCard.Suit);
            Console.ReadKey();
        }
    }
}

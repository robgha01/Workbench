using System;
using System.Collections.Generic;
using System.Linq;

namespace Workbench.Models
{
    public class Card : ICard
    {
        public string Image { get; set; }
        public CardTitlePart[] Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
    }

    public interface ICard
    {
        string Image { get; }
        CardTitlePart[] Title { get; }
        string Text { get; }
        string Link { get; }
    }

    public class CardBuilder : ICardBuilder
    {
        protected List<ICard> Cards;

        public CardBuilder()
        {
            Cards = new List<ICard>();
        }

        public ICardBuilder Card(Action<INewCardExpressionBuilder> cardExpression)
        {
            var newCardExpression = new NewCardExpressionBuilder();
            cardExpression(newCardExpression);
            Cards.Add(newCardExpression.currentCard);

            return this;
        }

        public IEnumerable<ICard> Build()
        {
            return Cards;
        }
    }

    public class NewCardExpressionBuilder : INewCardExpressionBuilder
    {
        public Card currentCard { get; set; } = new Card();

        public INewCardExpressionBuilder Image(string source)
        {
            currentCard.Image = source;
            return this;
        }

        public INewCardExpressionBuilder Text(string text)
        {
            currentCard.Text = text;
            return this;
        }

        public INewCardExpressionBuilder Title(string title, params string[] colors)
        {
            var titleParts = new List<CardTitlePart>();
            for (var i = 0; i < title.Length; i++)
            {
                titleParts.Add(new CardTitlePart(title[i], colors.Length - 1 < i ? string.Empty : colors[i]));
            }

            currentCard.Title = titleParts.ToArray();
            return this;
        }

        public INewCardExpressionBuilder Link(string link)
        {
            currentCard.Link = link;
            return this;
        }
    }

    public class CardTitlePart
    {
        public CardTitlePart(char character, string color)
        {
            Character = character;
            Color = color;
        }

        public char Character { get; }
        public string Color { get; }
    }

    public interface ICardBuilder
    {
        ICardBuilder Card(Action<INewCardExpressionBuilder> card);
        IEnumerable<ICard> Build();
    }

    public interface INewCardExpressionBuilder
    {
        INewCardExpressionBuilder Image(string source);
        INewCardExpressionBuilder Title(string title, params string[] colors);
        INewCardExpressionBuilder Text(string text);
        INewCardExpressionBuilder Link(string link);
    }
}
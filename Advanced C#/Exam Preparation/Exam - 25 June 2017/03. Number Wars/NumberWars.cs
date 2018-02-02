using System;
using System.Collections.Generic;
using System.Linq;

public class NumberWars
{
    public static void Main()
    {
        Queue<Card> first = GetCards();

        Queue<Card> second = GetCards();

        int turnCounter = 0;
        while (true)
        {
            if (first.Count == 0 || second.Count == 0 || turnCounter >= 1000000)
            {
                break;
            }

            Card firstPlayerCard = first.Dequeue();
            Card secondPlayerCard = second.Dequeue();


            if (firstPlayerCard.CardNumber > secondPlayerCard.CardNumber)
            {
                AddCard(ref first, firstPlayerCard, secondPlayerCard);
            }
            else if (secondPlayerCard.CardNumber > firstPlayerCard.CardNumber)
            {
                AddCard(ref second, firstPlayerCard, secondPlayerCard);
            }
            else if (firstPlayerCard.CardNumber == secondPlayerCard.CardNumber)
            {
                List<Card> firstPlayerMoreCards = new List<Card>();
                List<Card> secondPlayerMoreCards = new List<Card>();


                bool isDraw = true;
                while (isDraw)
                {
                    if (first.Count == 0 && second.Count == 0)
                    {
                        break;
                    }

                    firstPlayerMoreCards.AddRange(GetThreeCards(ref first));
                    secondPlayerMoreCards.AddRange(GetThreeCards(ref second));

                    int firstSumOfLetters = LetterValue(firstPlayerMoreCards);

                    int secondSumOfLetters = LetterValue(secondPlayerMoreCards);

                    if (firstSumOfLetters > secondSumOfLetters)
                    {
                        AddAllCards(ref first, firstPlayerMoreCards, secondPlayerMoreCards, firstPlayerCard, secondPlayerCard);
                        isDraw = false;
                    }
                    else if (secondSumOfLetters > firstSumOfLetters)
                    {
                        AddAllCards(ref second, firstPlayerMoreCards, secondPlayerMoreCards, firstPlayerCard, secondPlayerCard);
                        isDraw = false;
                    }
                }

                if (isDraw)
                {
                    Console.WriteLine($"Draw after {turnCounter + 1} turns");
                }
            }

            turnCounter++;
        }

        if (turnCounter == 1000000)
        {
            if (first.Count > second.Count)
                Console.WriteLine($"First player wins after {turnCounter} turns");
            if (first.Count < second.Count)
                Console.WriteLine($"Second player wins after {turnCounter} turns");
            return;
        }

        if (first.Count != 0) Console.WriteLine($"First player wins after {turnCounter} turns");
        if (second.Count != 0) Console.WriteLine($"Second player wins after {turnCounter} turns");
    }

    public static void AddCard(ref Queue<Card> deck, Card firstCard, Card secondCard)
    {
        if (firstCard.CardNumber > secondCard.CardNumber)
        {
            deck.Enqueue(firstCard);
            deck.Enqueue(secondCard);
        }
        else
        {
            deck.Enqueue(secondCard);
            deck.Enqueue(firstCard);
        }
    }

    public static void AddAllCards(ref Queue<Card> deck, List<Card> firstCards, List<Card> secondCards, Card firstPlayerCard, Card secondPlayerCard)
    {
        firstCards.Add(firstPlayerCard);
        firstCards.Add(secondPlayerCard);
        firstCards.AddRange(secondCards);

        foreach (var card in firstCards.OrderByDescending(n => n.CardNumber))
        {
            deck.Enqueue(card);
        }
    }

    private static int LetterValue(List<Card> cards)
    {
        int sum = 0;
        foreach (var card in cards)
        {
            sum += card.CardLetter;
        }

        return sum;
    }

    public static List<Card> GetThreeCards(ref Queue<Card> deck)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < 3; i++)
        {
            if (deck.Count == 0)
            {
                break;
            }
            cards.Add(deck.Dequeue());
        }

        return cards;
    }

    private static Queue<Card> GetCards()
    {
        List<string> input = Console.ReadLine().Trim()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Queue<Card> cards = new Queue<Card>();

        foreach (var card in input)
        {
            cards.Enqueue(new Card(card));
        }

        return cards;
    }
}

public class Card
{
    public int CardNumber { get; set; }
    public int CardLetter { get; set; }

    public Card(string card)
    {
        CardLetter = (int)card.Last() - 96;
        CardNumber = int.Parse(card.Substring(0, card.Length - 1));
    }
}

using P04_CustomEnumAttribute.Attributes;

namespace P04_CustomEnumAttribute.Enums
{
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}
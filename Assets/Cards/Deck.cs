using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    [Header("Deck Properties")]
    public List<Card> cards = new List<Card>();
    private const int DECK_SIZE = 10;
    
    private List<Card> drawPile = new List<Card>();
    
    void Awake()
    {
        if (cards.Count != DECK_SIZE)
        {
            Debug.LogError($"Deck must contain exactly {DECK_SIZE} cards!");
        }
        InitializeDeck();
    }
    
    public void InitializeDeck()
    {
        // Copie toutes les cartes dans la pile de pioche
        drawPile = new List<Card>(cards);
        ShuffleDeck();
    }
    
    public void ShuffleDeck()
    {
        // Mélange la pile de pioche en utilisant l'algorithme Fisher-Yates
        int n = drawPile.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card temp = drawPile[k];
            drawPile[k] = drawPile[n];
            drawPile[n] = temp;
        }
    }
    
    public Card DrawCard()
    {
        if (drawPile.Count == 0)
        {
            Debug.LogWarning("No cards left to draw!");
            return null;
        }
        
        Card drawnCard = drawPile[0];
        drawPile.RemoveAt(0);
        return drawnCard;
    }
    
    public int GetRemainingCards()
    {
        return drawPile.Count;
    }
    
    public bool AddCardToDeck(Card card)
    {
        if (cards.Count < DECK_SIZE)
        {
            cards.Add(card);
            return true;
        }
        Debug.LogWarning("Deck is full! Must contain exactly 10 cards.");
        return false;
    }
} 
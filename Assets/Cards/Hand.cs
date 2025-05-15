using UnityEngine;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    [Header("Hand Properties")]
    private const int MAX_HAND_SIZE = 5;
    private const int MAX_PROGRAMMED_CARDS = 3;
    public Transform cardParent; // L'objet parent où les cartes seront placées visuellement
    public float cardSpacing = 1.5f; // Espacement entre les cartes
    
    private List<Card> cardsInHand = new List<Card>();
    private List<(Card card, Vector2Int position)> programmedCards = new List<(Card, Vector2Int)>();
    private Deck deck; // Référence au deck
    
    void Start()
    {
        deck = Object.FindAnyObjectByType<Deck>();
        if (deck == null)
        {
            Debug.LogError("No Deck found in the scene!");
        }
    }
    
    public bool AddCard(Card card)
    {
        if (cardsInHand.Count >= MAX_HAND_SIZE)
        {
            Debug.LogWarning("Hand is full!");
            return false;
        }
        
        cardsInHand.Add(card);
        UpdateCardPositions();
        return true;
    }
    
    public void DrawInitialHand()
    {
        for (int i = 0; i < MAX_HAND_SIZE; i++)
        {
            DrawCard();
        }
    }
    
    public void DrawCard()
    {
        if (deck != null && cardsInHand.Count < MAX_HAND_SIZE)
        {
            Card drawnCard = deck.DrawCard();
            if (drawnCard != null)
            {
                AddCard(drawnCard);
            }
        }
    }
    
    public void RemoveCard(Card card)
    {
        if (cardsInHand.Contains(card))
        {
            cardsInHand.Remove(card);
            // La carte est simplement retirée de la main
            UpdateCardPositions();
        }
    }
    
    public bool ProgramCard(Card card, Vector2Int targetPosition)
    {
        if (!cardsInHand.Contains(card))
        {
            Debug.LogWarning("This card is not in your hand!");
            return false;
        }
        
        if (programmedCards.Count >= MAX_PROGRAMMED_CARDS)
        {
            Debug.LogWarning("Maximum number of programmed cards reached!");
            return false;
        }
        
        cardsInHand.Remove(card);
        programmedCards.Add((card, targetPosition));
        card.OnCardProgrammed(targetPosition);
        UpdateCardPositions();
        return true;
    }
    
    public void CancelProgrammedCard(Card card)
    {
        var programmedCard = programmedCards.Find(pc => pc.card == card);
        if (programmedCard.card != null)
        {
            programmedCards.Remove(programmedCard);
            card.CancelPreview();
            AddCard(card);
        }
    }
    
    public void ExecuteProgrammedCards()
    {
        foreach (var (card, position) in programmedCards)
        {
            // La logique d'exécution sera gérée par le GameManager
            Debug.Log($"Executing card {card.cardName} at position {position}");
        }
        programmedCards.Clear();
    }
    
    private void UpdateCardPositions()
    {
        if (cardParent == null) return;
        
        // Calcule la position de départ pour centrer les cartes
        float startX = -(cardsInHand.Count - 1) * cardSpacing / 2f;
        
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            Card card = cardsInHand[i];
            if (card != null)
            {
                Vector3 newPosition = new Vector3(startX + i * cardSpacing, 0, 0);
                card.transform.SetParent(cardParent);
                card.transform.localPosition = newPosition;
                card.transform.localRotation = Quaternion.identity;
            }
        }
    }
    
    public int GetCardCount()
    {
        return cardsInHand.Count;
    }
    
    public List<Card> GetCardsInHand()
    {
        return new List<Card>(cardsInHand);
    }
    
    public List<(Card card, Vector2Int position)> GetProgrammedCards()
    {
        return new List<(Card, Vector2Int)>(programmedCards);
    }
} 
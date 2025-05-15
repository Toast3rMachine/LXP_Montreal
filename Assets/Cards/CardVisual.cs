using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardVisual : MonoBehaviour
{
    [Header("UI References")]
    public Image cardBackground;
    public Image cardArtImage;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI damageText;
    
    [Header("Layout Settings")]
    public float cardWidth = 400f;
    public float cardHeight = 600f;
    
    private Card card;
    
    void Start()
    {
        // Récupère le composant Card
        card = GetComponent<Card>();
        if (card != null)
        {
            UpdateVisuals();
        }
    }
    
    public void UpdateVisuals()
    {
        if (card == null) return;
        
        // Met à jour le nom
        if (cardNameText != null)
        {
            cardNameText.text = card.cardName;
        }
        
        // Met à jour la description
        if (descriptionText != null)
        {
            descriptionText.text = card.description;
        }
        
        // Met à jour les dégâts
        if (damageText != null)
        {
            damageText.text = card.damage.ToString();
        }
        
        // Met à jour l'image si disponible
        if (cardArtImage != null && card.cardArt != null)
        {
            cardArtImage.sprite = card.cardArt;
        }
    }
    
    // Appelé quand les valeurs sont modifiées dans l'inspecteur
    void OnValidate()
    {
        if (card != null)
        {
            UpdateVisuals();
        }
    }
} 
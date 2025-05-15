using UnityEngine;

public class TestCard : MonoBehaviour
{
    void Start()
    {
        Card card = GetComponent<Card>();
        if (card != null)
        {
            // Pattern en croix
            card.SetAttackPattern(new string[] {
                " X ",  // Première ligne
                "XXX",  // Deuxième ligne
                " X "   // Troisième ligne
            });
            
            // Configuration de base de la carte
            card.cardName = "Cross Strike";
            card.description = "Frappe en croix qui inflige des dégâts dans un motif en +";
            card.damage = 5;
        }
    }
} 
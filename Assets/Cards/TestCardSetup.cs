using UnityEngine;

public class TestCardSetup : MonoBehaviour
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
        }
    }
} 
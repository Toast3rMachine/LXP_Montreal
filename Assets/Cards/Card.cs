using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card Properties")]
    public string cardName;
    [TextArea(2, 3)]
    public string description;
    
    [Header("Card Stats")]
    public int damage;
    public bool[,] attackPattern = new bool[3,3]; // Représente le pattern d'attaque sur la grille 3x3
    
    [Header("Visual Elements")]
    public Sprite cardArt;
    public Color patternColor = Color.red; // Couleur pour visualiser le pattern
    
    // Variables pour la prévisualisation
    private GameObject[,] previewTiles;
    private bool isPreviewActive = false;
    
    void Awake()
    {
        // Initialise le tableau de prévisualisation
        previewTiles = new GameObject[3,3];
        
        // Initialise un pattern de test en croix par défaut
        SetAttackPattern(new string[] {
            " X ",  // Première ligne
            "XXX",  // Deuxième ligne
            " X "   // Troisième ligne
        });
        
        // Configuration de base de la carte
        if (string.IsNullOrEmpty(cardName))
        {
            cardName = "Cross Strike";
            description = "Frappe en croix qui inflige des dégâts dans un motif en +";
            damage = 5;
        }
    }
    
    // Méthode appelée quand la carte est programmée pour être jouée
    public virtual void OnCardProgrammed(Vector2Int targetPosition)
    {
        Debug.Log($"Card {cardName} programmed at position {targetPosition}");
    }
    
    // Méthode pour prévisualiser l'effet de la carte sur la grille
    public virtual void PreviewEffect(Vector2Int targetPosition)
    {
        if (isPreviewActive) CancelPreview();
        
        // Crée la prévisualisation du pattern d'attaque
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (attackPattern[x,y])
                {
                    // Créer un visuel pour chaque case affectée
                    GameObject previewTile = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    previewTile.transform.position = new Vector3(targetPosition.x + x - 1, 0.1f, targetPosition.y + y - 1);
                    previewTile.transform.rotation = Quaternion.Euler(90, 0, 0);
                    
                    // Appliquer la couleur de prévisualisation
                    Renderer renderer = previewTile.GetComponent<Renderer>();
                    Material material = new Material(Shader.Find("Standard"));
                    material.color = new Color(patternColor.r, patternColor.g, patternColor.b, 0.5f);
                    renderer.material = material;
                    
                    previewTiles[x,y] = previewTile;
                }
            }
        }
        
        isPreviewActive = true;
    }
    
    // Méthode pour annuler la prévisualisation
    public virtual void CancelPreview()
    {
        if (!isPreviewActive) return;
        
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (previewTiles[x,y] != null)
                {
                    Destroy(previewTiles[x,y]);
                    previewTiles[x,y] = null;
                }
            }
        }
        
        isPreviewActive = false;
    }
    
    // Méthode utilitaire pour définir facilement le pattern d'attaque
    public void SetAttackPattern(string[] pattern)
    {
        if (pattern.Length != 3 || pattern[0].Length != 3)
        {
            Debug.LogError("Invalid pattern format. Must be 3x3");
            return;
        }
        
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                attackPattern[x,y] = pattern[2-y][x] == 'X';
            }
        }
    }
} 
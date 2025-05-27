using UnityEngine;

public class CardAttack : MonoBehaviour
{
    public bool[] attackPattern;
    public GameObject spellPrefab;
    public bool isThrow;
    public float moveSpeed = 10f;

    [SerializeField] private Attack attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        if (CameraManager.instance.phaseCarte) return;
        
        attack.addToCardList(this);
    }
}

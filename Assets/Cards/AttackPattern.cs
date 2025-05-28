using UnityEngine;

public class CardAttack : MonoBehaviour
{
    public bool[] attackPattern;
    public GameObject spellPrefab;
    public bool isThrow;
    public float moveSpeed = 10f;

    [SerializeField] private Attack attack;

    void OnMouseDown()
    {
        if (CameraManager.instance.phaseCarte) return;
        
        attack.addToCardList(this);
    }
}

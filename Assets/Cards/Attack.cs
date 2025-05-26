using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    // public GameObject card;
    public Transform platform;
    public GameObject spellPrefab;
    public GameObject player;
    public bool isThrow;

    [SerializeField] CardAttack cardAttack;

    private GameObject[] tiles;
    private GameObject spell;
    private float moveSpeed = 10f;
    private bool isSpellcast;

    private float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        if (spell != null && isSpellcast && isThrow)
        {
            spell.transform.Translate(Vector3.right *  Time.deltaTime * moveSpeed);
            if (spell.transform.position.x > platform.GetChild(4).transform.position.x)
            {
                Destroy(spell);
                isSpellcast = false;
            }
        }
        else if (isSpellcast && !isThrow)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1.5f)
            {
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag(spellPrefab.tag);
                foreach(GameObject obj in allObjects) {
                    Destroy(obj);
                }
                isSpellcast = false;
                elapsedTime = 0;
            }
        }
    }

    void OnMouseDown()
    {
        if (!isSpellcast && isThrow)
        {
            spell = Instantiate(spellPrefab,  new Vector3(0.5f, 2f, 0f), Quaternion.identity);
            spell.transform.position += player.transform.position;
            isSpellcast = true;
        }
        else
        {
            isSpellcast = true;
            for (int i =0; i < cardAttack.attackPattern.Length; i++)
            {
                if (cardAttack.attackPattern[i])
                {
                    spell = Instantiate(spellPrefab, platform.GetChild(i).position, Quaternion.identity);
                    spell.transform.position += new Vector3(0f, 2f, 0f);
                }
            }
        }
    }
}

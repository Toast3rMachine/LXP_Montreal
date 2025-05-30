using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    // public GameObject card;
    public Transform platform;
    public GameObject player;
    public bool reverse;
    
    //[SerializeField] CardAttack cardAttack;
    private List<CardAttack> cardOrder;
    private CardAttack card;

    private GameObject[] tiles;
    private GameObject spell;
    private bool isSpellcast;
    private bool spellInInvocation;

    private int index;
    private float elapsedTime;

    void Start()
    {
        cardOrder = new List<CardAttack>();
        index = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!CameraManager.instance.phaseCarte) return;

        if (!spellInInvocation && cardOrder.Count != 0)
        {
            CastSpellInList();
        }
        
        if (spell != null && isSpellcast && card.isThrow)
        {
            if (reverse)
            {
                spell.transform.Translate(Vector3.left *  Time.deltaTime * card.moveSpeed);
                if (spell.transform.position.x < platform.GetChild(3).transform.position.x)
                {
                    Destroy(spell);
                    isSpellcast = false;
                    spellInInvocation = false;
                    index += 1;
                }
            }
            else
            {
                spell.transform.Translate(Vector3.right *  Time.deltaTime * card.moveSpeed);
                if (spell.transform.position.x > platform.GetChild(5).transform.position.x)
                {
                    Destroy(spell);
                    isSpellcast = false;
                    spellInInvocation = false;
                    index += 1;
                }
            }
        }
        else if (isSpellcast && !card.isThrow)
        {
            
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1.5f)
            {
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag(card.spellPrefab.tag);
                foreach(GameObject obj in allObjects) {
                    Destroy(obj);
                }
                isSpellcast = false;
                spellInInvocation = false;
                elapsedTime = 0;
                index += 1;
            }
        }
        
        if (index > cardOrder.Count - 1)
        {
            cardOrder.Clear();
            index = 0;
        }
    }

    

    void CastSpellInList()
    {
        spellInInvocation = true;
        if (!isSpellcast && cardOrder[index].isThrow)
        {
            if (reverse)
            {
                spell = Instantiate(cardOrder[index].spellPrefab,  new Vector3(-2f, 2f, 0f), Quaternion.identity);
            }
            else
            {
                spell = Instantiate(cardOrder[index].spellPrefab,  new Vector3(2f, 2f, 0f), Quaternion.identity);
            }
            spell.transform.position += player.transform.position;
            isSpellcast = true;
        }
        else
        {
            for (int j = 0; j < cardOrder[index].attackPattern.Length; j++)
            {
                if (cardOrder[index].attackPattern[j])
                {
                    spell = Instantiate(cardOrder[index].spellPrefab, platform.GetChild(j).position, Quaternion.identity);
                    spell.transform.position += new Vector3(0f, 2f, 0f);
                }
            }
            isSpellcast = true;
        }

        card = cardOrder[index];
        StartCoroutine(Wait());
    }

    public void addToCardList(CardAttack cardAttack)
    {
        if (cardOrder.Count < 3)
        {
            cardOrder.Add(cardAttack);
            Debug.Log("Sort Ajouté  à la liste des sorts: " + cardOrder.Count);
        }
        else
        {
            Debug.Log("Nombre de sorts maximal atteint");
        }
        
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}

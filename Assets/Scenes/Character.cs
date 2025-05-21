using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Transform movePoint;
    public GameObject[] tiles;

    private int index;
    private int indexH = 1;
    private int indexV = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movePoint.parent = null;
        index = (indexH % 3) + (indexV * 3);
        transform.position = tiles[index].transform.position; // Mets le joueur au centre de la grille
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if ( (indexH + (int) Input.GetAxisRaw("Horizontal") >=0) && (indexH + (int) Input.GetAxisRaw("Horizontal") <= 2))
                {
                    indexH += (int) Input.GetAxisRaw("Horizontal");
                    index = (indexH % 3) + (indexV * 3);
                    movePoint.position = tiles[index].transform.position;
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            } else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if ( (indexV + (int) Input.GetAxisRaw("Vertical") >= 0) && (indexV + (int) Input.GetAxisRaw("Vertical") <= 2))
                indexV += (int) Input.GetAxisRaw("Vertical");
                index = (indexH % 3) + (indexV * 3);
                movePoint.position = tiles[index].transform.position;
                movePoint.position += new Vector3(0f, 1f, 0f);
            }
        }
    }
}
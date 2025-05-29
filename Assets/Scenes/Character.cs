using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Transform movePoint;
    public GameObject[] tiles;
    public bool arrows;

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

        if (!CameraManager.instance.phaseCarte) return;
        
        if (arrows)
        {
            ArrowControl();
        }
        else
        {
            ZsqdControl();
        }
    }

    void ArrowControl()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if ( indexH + (int) Input.GetAxisRaw("Horizontal") >=0 && indexH + (int) Input.GetAxisRaw("Horizontal") <= 2)
                {
                    indexH += (int) Input.GetAxisRaw("Horizontal");
                    index = (indexH % 3) + (indexV * 3);
                    movePoint.position = tiles[index].transform.position;
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            } else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                if ( (indexV + (int) Input.GetAxisRaw("Vertical") >= 0) && (indexV + (int) Input.GetAxisRaw("Vertical") <= 2))
                {
                    indexV += (int) Input.GetAxisRaw("Vertical");
                    index = (indexH % 3) + (indexV * 3);
                    movePoint.position = tiles[index].transform.position;
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
                
            }
        }
    }

    void ZsqdControl()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if ( indexH + (int) Input.GetAxisRaw("Horizontal") >=0 && indexH + (int) Input.GetAxisRaw("Horizontal") <= 2)
                {
                    indexH += (int) Input.GetAxisRaw("Horizontal");
                    index = (indexH % 3) + (indexV * 3);
                    movePoint.position = tiles[index].transform.position;
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            } else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if ( (indexV + (int) Input.GetAxisRaw("Vertical") >= 0) && (indexV + (int) Input.GetAxisRaw("Vertical") <= 2))
                {
                    indexV += (int) Input.GetAxisRaw("Vertical");
                    index = (indexH % 3) + (indexV * 3);
                    movePoint.position = tiles[index].transform.position;
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
                
            }
        }
    }
}
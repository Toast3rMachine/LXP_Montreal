using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public GameObject cameraEsquive;
    public GameObject cameraCarte;

    public bool phaseCarte;
    private float timer = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cameraEsquive.SetActive(true);
        InvokeRepeating ("ChangeCamera", 0, timer);
    }

    // Update is called once per frame
    void Update()
    {
        // yield return new WaitForSeconds(3);
    }

    void ChangeCamera()
    {
        if(phaseCarte)
        {
            cameraEsquive.SetActive(false);
            cameraCarte.SetActive(true);
            phaseCarte = !phaseCarte;
            timer = 5f;
        }
        else
        {
            cameraEsquive.SetActive(true);
            cameraCarte.SetActive(false);
            phaseCarte = !phaseCarte;
            timer = 30f;
        }
    }
}

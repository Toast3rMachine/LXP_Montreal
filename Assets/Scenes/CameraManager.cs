using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public GameObject cameraEsquive;
    public GameObject cameraCarte;

    public bool phaseCarte;
    private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cameraEsquive.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        if (seconds == 5 && phaseCarte)
        {
            ChangeCamera();
            elapsedTime = 0;
        } else if (seconds == 30 && !phaseCarte)
        {
            ChangeCamera();
            elapsedTime = 0;
        }
    }

    void ChangeCamera()
    {
        if(phaseCarte)
        {
            cameraEsquive.SetActive(false);
            cameraCarte.SetActive(true);
            phaseCarte = !phaseCarte;
        }
        else
        {
            cameraEsquive.SetActive(true);
            cameraCarte.SetActive(false);
            phaseCarte = !phaseCarte;
        }
    }
}

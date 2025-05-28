using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public GameObject cameraEsquive;
    public GameObject cameraCarte;
    public bool phaseCarte;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject readyButton;
    [SerializeField] ReadyButton canvas; //* En réalité c'est le canvas car c'est lui qui a le script "Ready Button"

    private float elapsedTime;
    private float remainingTime = 30;

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
        remainingTime -= Time.deltaTime;

        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int secondsRemaining = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{00}", secondsRemaining);
        if (seconds == 5 && phaseCarte)
        {
            ChangeCamera();
            elapsedTime = 0;
            timerText.enabled = true;
            readyButton.SetActive(true);
            remainingTime = 30;
        } else if ((canvas.ready || seconds == 30) && !phaseCarte)
        {
            ChangeCamera();
            elapsedTime = 0;
            timerText.enabled = false;
            readyButton.SetActive(false);
            canvas.ready = false;
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

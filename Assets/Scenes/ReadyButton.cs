using UnityEngine;

public class ReadyButton : MonoBehaviour
{
    public bool ready;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetReady()
    {
        ready = true;
        Debug.Log("Ready");
    }
}

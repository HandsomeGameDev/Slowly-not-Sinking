using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 300;
    public TextMeshProUGUI TimerText;
    public int minutes = 0;
    public int seconds = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        minutes = (int)timeRemaining / 60;
        seconds = (int)timeRemaining % 60;
        TimerText.text = $"{minutes.ToString("00")} : {seconds.ToString("00")}";
        if(minutes == 0 && seconds == 0)
        {
            //Kill the player
            
        }
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 300;
    public TextMeshProUGUI TimerText;
    public int minutes = 0;
    public int seconds = 0;
    public Volume volume;
    public ColorAdjustments ColAdj;
    public GameObject TimerUI;
    public GameObject LoseUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        minutes = (int)timeRemaining / 60;
        seconds = (int)timeRemaining % 60;
        TimerText.text = $"{minutes.ToString("0")} : {seconds.ToString("00")}";
        if(minutes == 0 && seconds == 0)
        {
            //Kill the player
            TimerUI.SetActive(false);
            LoseUI.SetActive(true);
            if(volume.profile.TryGet(out ColAdj)){
                ColAdj.colorFilter.value = new Color32(0, 0, 0, 0);
            }
        }
    }
}

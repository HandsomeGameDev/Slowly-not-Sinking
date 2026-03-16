using UnityEngine;

public class ReadyScript : MonoBehaviour
{
    public GameObject InstrUI;
    public GameObject StartUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartUI.SetActive(false);
        InstrUI.SetActive(true);
    }
}

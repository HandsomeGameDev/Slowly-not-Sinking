using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameInit()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToIntro : MonoBehaviour
{
    public static void ResetGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}

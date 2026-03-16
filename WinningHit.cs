using UnityEngine;
using System.Collections;

public class WinningHit : MonoBehaviour
{
    public GameObject WinningUI;
    public GameObject TimeUI;
    public GameObject InstruUI;
    public bool hasWon = false;
    public SwimmingMovement swimmingScript;
    public Buoyancy buoyancy;
    public Rigidbody rbPlayer;

    void OnTriggerEnter(Collider collider){
        WinningUI.SetActive(true);
        TimeUI.SetActive(false);
        InstruUI.SetActive(false);
        swimmingScript.allowSwimming = false;
        buoyancy.enableBuoyancy = false;
        rbPlayer.linearVelocity = Vector3.zero;
        hasWon = true;
        StartCoroutine(SendToIntro());
    }

    IEnumerator SendToIntro()
    {
        yield return new WaitForSeconds(5f);
        BackToIntro.ResetGame();
    }
}

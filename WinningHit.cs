using UnityEngine;

public class WinningHit : MonoBehaviour
{
    public GameObject WinningUI;
    public GameObject TimeUI;

    void OnTriggerEnter(Collider collider){
        WinningUI.SetActive(true);
        TimeUI.SetActive(false);
        InputScript.InputSysAc.Disable();
    }
}

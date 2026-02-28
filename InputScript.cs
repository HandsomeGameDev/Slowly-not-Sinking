using UnityEngine;

public class InputScript : MonoBehaviour
{
    public static InputSystemActions InputSysAc;

    void Awake()
    {
        InputSysAc = new InputSystemActions();
        InputSysAc.Enable();
        InputSysAc.Player.Enable();
    }
}

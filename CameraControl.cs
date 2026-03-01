using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float Xsensitivity = 0.1f;
    public float Ysensitivity = 0.1f;
    public float XRotationAmount = 31.4f;
    public float YRotationAmount = 0.0f;
    public float ZRotationAmount = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        YRotationAmount = this.transform.eulerAngles.y;
        XRotationAmount = this.transform.eulerAngles.x;
        ZRotationAmount = this.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = Mouse.current.delta.ReadValue();
        //read value from mouse input, idk what mouse is but it works ig
        YRotationAmount += delta.x * Xsensitivity;
        XRotationAmount -= delta.y * Ysensitivity;
        XRotationAmount = Mathf.Clamp(XRotationAmount, -90.0f, 90.0f);
        //same, but for the rotation around the x-axis and moves the camera up and down
        this.transform.parent.rotation = Quaternion.Euler(0, YRotationAmount, 0);
        this.transform.localRotation = Quaternion.Euler(XRotationAmount, 0, 0);
    }
}

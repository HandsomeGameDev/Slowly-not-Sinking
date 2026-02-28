using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float Xsensitivity = 0.1f;
    public float Ysensitivity = 0.1f;
    public float XRotationAmount = 31.4f;
    public float YRotationAmount = 0f;
    public float ZRotationAmount = 0f;
    public float FwdAmt = 1f;
    public Animator animator;
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
        this.transform.position = animator.GetBoneTransform(HumanBodyBones.Head).position;
        this.transform.position += transform.forward * FwdAmt;
        Vector2 delta = Mouse.current.delta.ReadValue();
        //read value from mouse input, idk what mouse is but it works ig
        YRotationAmount += delta.x * Xsensitivity;
        YRotationAmount = Mathf.Clamp(YRotationAmount, -55, 55);
        //this will be the number to rotate around the y-axis and not let it go under -70, nor over 70.
        XRotationAmount -= (delta.y * Ysensitivity);
        XRotationAmount = Mathf.Clamp(XRotationAmount, -30, 55);
        //same, but for the rotation around the x-axis and moves the camera up and down
        this.transform.rotation = Quaternion.Euler(XRotationAmount, YRotationAmount, ZRotationAmount);
    }
}

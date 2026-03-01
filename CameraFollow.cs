using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //this is the subject you are following
    public Transform parent; //set this as the parent to the camera(or parent to the parent camera(recomended))

    public Vector3 offset; //is is the offset to the character(recomend leaving this as zero for most uses)

    public float highVerticalLimit = 60.0f;//this is the limit for how high you want to allow the camera to rotate
    public float lowVerticalLimit = -60.0f;//this is the limit for how low you want to allow the camera to rotate

    private float xRotation = 0.0f; //this tracks the rotation of the objects x axis

    void start()
    {
        Vector3 startRotation = transform.localEulerAngles; //this grabs the camera's current rotation when you start
        xRotation = startRotation.x;

        if (xRotation > 180.0f) //this accounts for some unity nonsense
        {
            xRotation -= 360.0f;
        }
    }

    void LateUpdate()
    {
        parent.position = target.position + offset; //moves the camera to the offset of the target's position
        parent.Rotate(0.0f, Input.GetAxis("Horizontal2"), 0.0f); //rotates the camera by the input of the xAxis of the mouse

        xRotation = Mathf.Clamp(xRotation - Input.GetAxis("Vertical2"), lowVerticalLimit, highVerticalLimit); //finds the new rotation of x by changing the current rotation by your input then clamping it so it can't go above or below the set vertical limts

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f); //and this sets the new rotation by the new xRotation
    }
}

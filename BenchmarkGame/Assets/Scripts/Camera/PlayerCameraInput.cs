using UnityEngine;

public class PlayerCameraInput : MonoBehaviour, ICameraInput
{
    public float GetInputX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetInputY()
    {
        return Input.GetAxis("Mouse Y");
    }
}

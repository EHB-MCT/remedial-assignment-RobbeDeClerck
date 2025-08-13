using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerMovementInput
{
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    public Vector2 GetMovementInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }

    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(jumpKey);
    }

    public bool IsRunning()
    {
        return Input.GetKey(runKey);
    }
}

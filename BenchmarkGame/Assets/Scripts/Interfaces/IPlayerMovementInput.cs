using UnityEngine;

public interface IPlayerMovementInput
{
    Vector2 GetMovementInput(); // X = horizontal, Y = vertical
    bool IsJumpPressed();
    bool IsRunning();
}

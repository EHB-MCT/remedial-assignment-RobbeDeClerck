using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Input")]
    public MonoBehaviour inputProvider;
    private ICameraInput cameraInput;

    [Header("Sensitivity")]
    public float sensitivityX = 3f;
    public float sensitivityY = 3f;
    public float sensitivityTotal = 1f;

    [Header("Pitch Limits")]
    public float minPitch = -85f;
    public float maxPitch = 90f;

    [Header("References")]
    [Tooltip("Reference to the player's body/root object (rotates on Y axis)")]
    public Transform playerBody;

    [Header("Settings")]
    public bool lockCursor = true;
    public bool isActive = true;

    private float pitch = 0f;

    private void Awake()
    {
        cameraInput = inputProvider as ICameraInput;

        if (cameraInput == null)
        {
            Debug.LogError("Input Provider does not implement ICameraInput.");
        }
    }

    void Start()
    {
        if (lockCursor)
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
#endif
        }
    }

    void Update()
    {
        if (!isActive || playerBody == null) return;

        float mouseX = cameraInput.GetInputX() * sensitivityX * sensitivityTotal;
        float mouseY = cameraInput.GetInputY() * sensitivityY * sensitivityTotal;

        // Yaw - rotate the player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Pitch - rotate the camera vertically (this object)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}

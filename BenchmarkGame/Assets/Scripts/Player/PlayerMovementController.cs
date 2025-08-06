using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Input")]
    public MonoBehaviour inputProvider; // Must implement IPlayerMovementInput
    private IPlayerMovementInput playerInput;

    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Headbob Settings")]
    public Transform cameraHolder;
    public float headbobAmplitude = 0.05f;
    public float headbobFrequency = 8f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private float headbobTimer = 0f;
    private Vector3 cameraStartLocalPos;

    [Header("Audio")]
    public PlayerFootstepManager footstepManager;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = inputProvider as IPlayerMovementInput;

        if (playerInput == null)
            Debug.LogError("Input Provider does not implement IPlayerMovementInput.");
    }

    private void Start()
    {
        if (cameraHolder != null)
            cameraStartLocalPos = cameraHolder.localPosition;
    }

    private void Update()
    {
        if (playerInput == null) return;

        // --- Ground check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // --- Movement input
        Vector2 input = playerInput.GetMovementInput();
        Vector3 move = (transform.right * input.x + transform.forward * input.y).normalized;
        float speed = playerInput.IsRunning() ? runSpeed : walkSpeed;

        // --- Apply movement (horizontal only, no momentum)
        controller.Move(move * speed * Time.deltaTime);

        // --- Jump
        if (playerInput.IsJumpPressed() && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(new Vector3(0f, velocity.y, 0f) * Time.deltaTime);

        // --- Headbob
        HandleHeadbob(move, speed);

        // --- Footstep Manager
        bool isMoving = input.magnitude > 0.1f;
        footstepManager?.HandleFootsteps(isMoving, playerInput.IsRunning());
    }

    private void HandleHeadbob(Vector3 move, float speed)
    {
        if (cameraHolder == null) return;

        if (controller.isGrounded && move.magnitude > 0.1f)
        {
            headbobTimer += Time.deltaTime * headbobFrequency * (speed / walkSpeed);
            float bob = Mathf.Sin(headbobTimer) * headbobAmplitude;
            cameraHolder.localPosition = cameraStartLocalPos + new Vector3(0, bob, 0);
        }
        else
        {
            // Return to original position when not moving
            cameraHolder.localPosition = Vector3.Lerp(cameraHolder.localPosition, cameraStartLocalPos, Time.deltaTime * 6f);
        }
    }
}

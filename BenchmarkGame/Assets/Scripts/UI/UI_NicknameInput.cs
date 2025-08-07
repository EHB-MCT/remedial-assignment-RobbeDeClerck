using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NicknameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button confirmButton;
    private GameObject player;
    private PlayerMovementController movementController;
    private PlayerCameraController cameraController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            movementController = player.GetComponent<PlayerMovementController>();
            cameraController = player.GetComponentInChildren<PlayerCameraController>();

            if (movementController != null)
                movementController.enabled = false;

            if (cameraController != null)
                cameraController.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inputField.ActivateInputField();

        if (confirmButton != null)
            confirmButton.onClick.AddListener(OnConfirmNickname);
    }

    public void OnConfirmNickname()
    {
        string nickname = inputField.text.Trim();

        if (string.IsNullOrEmpty(nickname))
        {
            Debug.LogWarning("Nickname is empty.");
            return;
        }

        DataTrackingManager.Instance.SetNickname(nickname);
        gameObject.SetActive(false);

        if (movementController != null)
            movementController.enabled = true;

        if (cameraController != null)
            cameraController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

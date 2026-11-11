using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerUiManager : NetworkBehaviour
{

    private Canvas playerCanvas;
    public bool isActive;
    private InputAction escInput;


    public override void OnNetworkSpawn()
    {
        playerCanvas = GetComponentInChildren<Canvas>();
        playerCanvas.gameObject.SetActive(false);
        isActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Start()
    {
        escInput = InputSystem.actions.FindAction("Esc");
    }

    private void Update()
    {
        if (escInput.WasPressedThisFrame())
        {
            if (isActive)
            {
                playerCanvas.gameObject.SetActive(false);
                isActive = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                playerCanvas.gameObject.SetActive(true);
                isActive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void ContinueButton()
    {
        playerCanvas.gameObject.SetActive(false);
        isActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

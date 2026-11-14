using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerUiManager : NetworkBehaviour
{

    private Canvas playerCanvas;
    public bool isActive;
    private InputAction escInput;
    [SerializeField] private TMP_Text sessionCodeText;


    public override void OnNetworkSpawn()
    {
        playerCanvas = GetComponentInChildren<Canvas>();
        playerCanvas.gameObject.SetActive(false);
        sessionCodeText.text = Connect.SessionCode;
        isActive = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(LoadSessionCode());
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

    private IEnumerator LoadSessionCode()
    {
        while (string.IsNullOrEmpty(Connect.SessionCode))
        {
            yield return null;
        }

        sessionCodeText.text = Connect.SessionCode;
    }
}

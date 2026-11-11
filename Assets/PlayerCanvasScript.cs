using UnityEngine;

public class PlayerCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject escPlayerUI;

    void Start()
    {

    }

    void Update()
    {
    }

    public void ContinueButton ()
    {
        escPlayerUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

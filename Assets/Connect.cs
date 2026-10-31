using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Multiplayer;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    [SerializeField]private Button hostButton;
    [SerializeField]private Button clientButton;
    [SerializeField]private TMP_InputField roomCodeInput;
    [SerializeField]private GameObject menuUi;
    [SerializeField]private GameObject loadingPanel;


    private async void Start()
    {
        var options = new InitializationOptions()
       .SetProfile("player" + Random.Range(0, 100000));
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        hostButton.onClick.AddListener(HostButtonOnClick);
        clientButton.onClick.AddListener(ClientButtonOnClick);
    }

    private async void HostButtonOnClick()
    {
        loadingPanel.SetActive(true);
        var joinCode = await StartSessionAsHost();
        menuUi.SetActive(false);
    }

    private async void ClientButtonOnClick()
    {
        loadingPanel.SetActive(true);
        await JoinSessionAsClient();
        menuUi.SetActive(false);
    }
    private async Task<string> StartSessionAsHost()
    {
        var options = new SessionOptions
        {
            MaxPlayers = 2
        }.WithRelayNetwork();
        var session = await MultiplayerService.Instance.CreateSessionAsync(options);
        Debug.Log("Kód: " + session.Code);
        return session.Code;
    }

    private async Task JoinSessionAsClient()
    {
        await MultiplayerService.Instance.JoinSessionByCodeAsync(roomCodeInput.text);
    }
}

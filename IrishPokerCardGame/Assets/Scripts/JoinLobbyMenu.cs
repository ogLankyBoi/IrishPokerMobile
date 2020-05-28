using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerIrishPoker networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
    [SerializeField] private TMP_InputField ipAddressInputField = null;
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button joinButton = null;

    private void Start()
    {
        SetIpAddress();
    }

    private void OnEnable()
    {
        NetworkManagerIrishPoker.OnClientConnected += HandleClientConnected;
        NetworkManagerIrishPoker.OnClientDisconnected += HandleClientDisconnected;
    }

    // Used to enable the Join Button if there is text in both ip and name textboxes
    public void SetIpAddress()
    {
        joinButton.interactable = !string.IsNullOrEmpty(ipAddressInputField.text) && !string.IsNullOrEmpty(nameInputField.text);
    }

    public void JoinLobby()
    {
        string ipAddress = ipAddressInputField.text;
        Debug.Log(ipAddress);

        networkManager.networkAddress = ipAddress;
        networkManager.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected()
    {
        joinButton.interactable = true;
        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
    }

    private void HandleClientDisconnected()
    {
        joinButton.interactable = true;
    }

}

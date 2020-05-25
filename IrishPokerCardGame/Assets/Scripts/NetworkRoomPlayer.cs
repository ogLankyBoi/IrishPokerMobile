using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class NetworkRoomPlayer : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[4];
    [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[4];
    [SerializeField] private Button startGameButton = null;

    /*
    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayNamep = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;
    */

    public bool isLeader;

    public bool IsLeader
    {
        set
        {
            isLeader = value;
            startGameButton.gameObject.SetActive(value);
        }
    }

    private NetworkManagerIrishPoker room;
    private NetworkManagerIrishPoker Room
    {
        get
        {
            if(room != null) { return room; }
            return room = NetworkManager.singleton as NetworkManagerIrishPoker;
        }
    }
}

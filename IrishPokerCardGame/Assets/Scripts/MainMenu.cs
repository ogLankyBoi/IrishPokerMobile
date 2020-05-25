using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerIrishPoker networkManager = null;

    public void HostLobby()
    {
        SceneManager.LoadScene("WaitLobby");
        networkManager.StartHost();
    }

}

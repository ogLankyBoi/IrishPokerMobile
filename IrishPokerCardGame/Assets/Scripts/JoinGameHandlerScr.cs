using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGameHandlerScr : MonoBehaviour
{
    public SceneChanger sceneChanger;

    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("PlayMenu");
    }

    public void OnJoinButton()
    {
        sceneChanger.SceneLoad("LobbyOnline");
    }
}

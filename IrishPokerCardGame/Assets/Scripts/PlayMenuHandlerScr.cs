using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandlerScr : MonoBehaviour
{
    public SceneChanger sceneChanger;

    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }

    public void OnLocalButton()
    {
        sceneChanger.SceneLoad("LocalPlayMenu");
    }

    public void OnCreateButton()
    {
        sceneChanger.SceneLoad("CreateOnlineGame");
    }

    public void OnJoinButton()
    {
        sceneChanger.SceneLoad("JoinOnlineGame");
    }
}

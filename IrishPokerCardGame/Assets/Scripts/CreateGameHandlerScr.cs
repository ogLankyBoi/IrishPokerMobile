using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameHandlerScr : MonoBehaviour
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

    public void OnCreateButton()
    {
        sceneChanger.SceneLoad("LobbyOnline");
    }
}

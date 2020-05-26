using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandlerScr : MonoBehaviour
{
    public SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSoloButton()
    {
        sceneChanger.SceneLoad("LocalPlayMenu");
    }

    public void OnCreateButton()
    {
        print("2");
    }

    public void OnJoinButton()
    {
        print("3");
    }

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }
}

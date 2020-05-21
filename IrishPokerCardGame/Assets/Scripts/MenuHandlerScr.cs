using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandlerScr : MonoBehaviour
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

    public void OnPlayButton()
    {
        sceneChanger.SceneLoad("PlayMenu");
    }

    public void OnSettingsButton()
    {
        print("2");
    }

    public void OnHowToButton()
    {
        print("3");
    }
}

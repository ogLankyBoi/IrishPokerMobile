using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayHandlerScr : MonoBehaviour
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

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningHandlerScr : MonoBehaviour
{
    public SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    public void OnAgreeButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }
}

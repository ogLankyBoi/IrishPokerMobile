using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalPlayMenuHandlerScr : MonoBehaviour
{
    public SceneChanger sceneChanger;

    public GameObject player1Name;
    public GameObject player2Name;
    public GameObject player3Name;
    public GameObject player4Name;
    public GameObject player5Name;
    public GameObject player6Name;

    public int players = 2;

    // Start is called before the first frame update
    void Start()
    {
        AssignObjects();
    }

    public void AssignObjects()
    {
        sceneChanger = GetComponent<SceneChanger>();
        player1Name = GameObject.Find("Player1Name");
        player2Name = GameObject.Find("Player2Name");
        player3Name = GameObject.Find("Player3Name");
        player4Name = GameObject.Find("Player4Name");
        player5Name = GameObject.Find("Player5Name");
        player6Name = GameObject.Find("Player6Name");

        player3Name.SetActive(false);
        player4Name.SetActive(false);
        player5Name.SetActive(false);
        player6Name.SetActive(false);
    }

    public void OnAddPlayerButton()
    {
        switch (players)
        {
            case 2:
                player3Name.SetActive(true);
                players++;
                break;
            case 3:
                player4Name.SetActive(true);
                players++;
                break;
            case 4:
                player5Name.SetActive(true);
                players++;
                break;
            case 5:
                player6Name.SetActive(true);
                players++;
                break;
            default:
                break;
        }
    }

    public void OnRemovePlayerButton()
    {
        switch (players)
        {
            case 3:
                player3Name.SetActive(false);
                players--;
                break;
            case 4:
                player4Name.SetActive(false);
                players--;
                break;
            case 5:
                player5Name.SetActive(false);
                players--;
                break;
            case 6:
                player6Name.SetActive(false);
                players--;
                break;
            default:
                break;
        }
    }

    public void OnStartGameButton()
    {
        switch (players)
        {
            case 2:
                sceneChanger.SceneLoad("Local2PGame");
                break;
            case 3:
                sceneChanger.SceneLoad("Local3PGame");
                break;
            case 4:
                sceneChanger.SceneLoad("Local4PGame");
                break;
            case 5:
                sceneChanger.SceneLoad("Local5PGame");
                break;
            default:
                //sceneChanger.SceneLoad("Local6PGame");
                break;
        }
    }

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("PlayMenu");
    }
}
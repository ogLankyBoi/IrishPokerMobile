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
    public GameObject player7Name;
    public GameObject player8Name;

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
        player7Name = GameObject.Find("Player7Name");
        player8Name = GameObject.Find("Player8Name");

        player3Name.SetActive(false);
        player4Name.SetActive(false);
        player5Name.SetActive(false);
        player6Name.SetActive(false);
        player7Name.SetActive(false);
        player8Name.SetActive(false);
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
            case 6:
                player7Name.SetActive(true);
                players++;
                break;
            case 7:
                player8Name.SetActive(true);
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
            case 7:
                player7Name.SetActive(false);
                players--;
                break;
            case 8:
                player8Name.SetActive(false);
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
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "")
                {
                    sceneChanger.SceneLoad("Local2PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            case 3:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local3PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            case 4:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "" && player4Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local4PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            case 5:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "" && player4Name.GetComponent<InputField>().text != "" && player5Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local5PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            case 6:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "" && player4Name.GetComponent<InputField>().text != "" && player5Name.GetComponent<InputField>().text != "" && player6Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local6PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            case 7:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "" && player4Name.GetComponent<InputField>().text != "" && player5Name.GetComponent<InputField>().text != "" && player6Name.GetComponent<InputField>().text != "" && player7Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local7PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
            default:
                if (player1Name.GetComponent<InputField>().text != "" && player2Name.GetComponent<InputField>().text != "" && player3Name.GetComponent<InputField>().text != "" && player4Name.GetComponent<InputField>().text != "" && player5Name.GetComponent<InputField>().text != "" && player6Name.GetComponent<InputField>().text != "" && player7Name.GetComponent<InputField>().text != "" && player8Name.GetComponent<InputField>().text != "")
                {
                    //sceneChanger.SceneLoad("Local8PGame");
                }
                else
                {
                    print("One or more player names are missing.");
                }
                break;
        }
    }

    public void OnBackButton()
    {
        sceneChanger.SceneLoad("PlayMenu");
    }
}
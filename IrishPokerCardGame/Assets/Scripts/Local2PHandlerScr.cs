using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Local2PHandlerScr : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public SceneChanger sceneChanger;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };

    public List<string> deck;
    public List<string> restOfDeck;
    public List<int> cardValue;
    public List<int> cardDrinks;

    public int round = 1;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public GameObject dialogueText;
    public GameObject dialogueBox;
    public GameObject inGameOptions;

    // Start is called before the first frame update
    void Start()
    {
        setUpGameComponents();
        setUpButtons();
        deck = GenerateDeck();
        ShuffleDeck(deck);
        cardValue = AssignCardValues(deck);
        cardDrinks = AssignCardDrinks(deck);
        Deal();
    }

    public void setUpGameComponents()
    {
        sceneChanger = GetComponent<SceneChanger>();
        dialogueText = GameObject.Find("DialogueText");
        dialogueBox = GameObject.Find("DialogBox");
        inGameOptions = GameObject.Find("InGameOptions");
        inGameOptions.SetActive(false);
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(v + s);
            }
        }

        return newDeck;
    }

    void ShuffleDeck<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    public static List<int> AssignCardValues(List<string> thisDeck)
    {
        List<int> cardValues = new List<int>();

        for (int i = 0; i < 52; i++)
        {
            string cardName = thisDeck[i];
            char value = cardName[0];
            switch (value)
            {
                case '2':
                    cardValues.Add(2);
                    break;
                case '3':
                    cardValues.Add(3);
                    break;
                case '4':
                    cardValues.Add(4); ;
                    break;
                case '5':
                    cardValues.Add(5);
                    break;
                case '6':
                    cardValues.Add(6);
                    break;
                case '7':
                    cardValues.Add(7);
                    break;
                case '8':
                    cardValues.Add(8);
                    break;
                case '9':
                    cardValues.Add(9);
                    break;
                case 'T':
                    cardValues.Add(10);
                    break;
                case 'J':
                    cardValues.Add(11);
                    break;
                case 'Q':
                    cardValues.Add(12);
                    break;
                case 'K':
                    cardValues.Add(13);
                    break;
                default:
                    cardValues.Add(14);
                    break;
            }
        }

        return cardValues;
    }

    public static List<int> AssignCardDrinks(List<string> thisDeck)
    {
        List<int> cardDrink = new List<int>();

        for (int i = 0; i < 52; i++)
        {
            string cardName = thisDeck[i];
            char value = cardName[0];
            switch (value)
            {
                case '2':
                    cardDrink.Add(2);
                    break;
                case '3':
                    cardDrink.Add(3);
                    break;
                case '4':
                    cardDrink.Add(4); ;
                    break;
                case '5':
                    cardDrink.Add(5);
                    break;
                case '6':
                    cardDrink.Add(6);
                    break;
                case '7':
                    cardDrink.Add(7);
                    break;
                case '8':
                    cardDrink.Add(8);
                    break;
                case '9':
                    cardDrink.Add(9);
                    break;
                case 'T':
                    cardDrink.Add(10);
                    break;
                case 'J':
                    cardDrink.Add(10);
                    break;
                case 'Q':
                    cardDrink.Add(10);
                    break;
                case 'K':
                    cardDrink.Add(10);
                    break;
                default:
                    cardDrink.Add(11);
                    break;
            }
        }

        return cardDrink;
    }

    void Deal()
    {
        float xOffset = 0;
        for (int i = 0; i < 4; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(160 + xOffset, 200, 0), Quaternion.identity);
            newCard.name = deck[i];

            xOffset = xOffset + 250;
        }
        xOffset = 0;
        for (int i = 4; i < 8; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(390 + xOffset, 2000, 0), Quaternion.identity);
            newCard.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            newCard.name = deck[i];
            xOffset = xOffset + 100;
        }
        for (int i = 8; i < 52; i++)
        {
            restOfDeck.Add(deck[i]);
        }
    }

    public void setUpButtons()
    {
        button1 = GameObject.Find("Button1");
        button2 = GameObject.Find("Button2");
        button3 = GameObject.Find("Button3");
        button4 = GameObject.Find("Button4");

        button3.SetActive(false);
        button4.SetActive(false);
        button1.GetComponentInChildren<Text>().text = "Red";
        button2.GetComponentInChildren<Text>().text = "Black";

    }



    public void OnInGameSettingsButton()
    {

        dialogueBox.SetActive(false);
        inGameOptions.SetActive(true);

    }

    public void OnCloseOptionsButton()
    {
        dialogueBox.SetActive(true);
        inGameOptions.SetActive(false);
    }

    public void OnLeaveGameButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }

}

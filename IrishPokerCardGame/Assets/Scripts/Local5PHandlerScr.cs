using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Local5PHandlerScr : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public SceneChanger sceneChanger;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
    public string[] currentBusCards;
    public int[] currentBusValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public List<string> deck;
    public List<string> restOfDeck;
    public List<string> busDeck;
    public List<int> cardValue;

    public int round = 1;
    public int player = 1;
    public int busRound = 1;
    public int busDeckPlaceholder = 10;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject continueButton;
    public GameObject higherButton;
    public GameObject lowerButton;

    public GameObject dialogueText;
    public GameObject dialogueBox;
    public GameObject inGameOptions;
    public GameObject rideBusBox;
    public GameObject rideBusText;
    public GameObject busTieBox;
    public GameObject playerMarkerRed;
    public GameObject playerMarkerBlue;
    public GameObject playerMarkerGreen;
    public GameObject playerMarkerYellow;
    public GameObject playerMarkerPurple;

    // Start is called before the first frame update
    void Start()
    {
        setUpGameComponents();
        setUpButtons();
        deck = GenerateDeck();
        ShuffleDeck(deck);
        cardValue = AssignCardValues(deck);
        Deal();
    }

    public void setUpGameComponents()
    {
        sceneChanger = GetComponent<SceneChanger>();
        dialogueText = GameObject.Find("DialogueText");
        dialogueBox = GameObject.Find("DialogBox");
        inGameOptions = GameObject.Find("InGameOptions");
        inGameOptions.SetActive(false);
        rideBusText = GameObject.Find("RideBusText");
        rideBusBox = GameObject.Find("RideBusBox");
        rideBusBox.SetActive(false);
        busTieBox = GameObject.Find("BusTieBox");
        busTieBox.SetActive(false);
        playerMarkerRed = GameObject.Find("PlayerColorMarkerRed");
        playerMarkerBlue = GameObject.Find("PlayerColorMarkerBlue");
        playerMarkerGreen = GameObject.Find("PlayerColorMarkerGreen");
        playerMarkerYellow = GameObject.Find("PlayerColorMarkerYellow");
        playerMarkerPurple = GameObject.Find("PlayerColorMarkerPurple");
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


    void Deal()
    {
        float xOffset = 0;
        float zOffset = 0;
        float yOffset = 0;
        for (int i = 0; i < 4; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(160 + xOffset, 200, zOffset), Quaternion.identity);
            newCard.name = deck[i];

            xOffset = xOffset + 250;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        yOffset = 0;
        for (int i = 4; i < 8; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(20, 790 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset - 80;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        yOffset = 0;
        for (int i = 8; i < 12; i++)
        {

            GameObject newCard = Instantiate(cardPrefab, new Vector3(20, 1490 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset - 80;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        yOffset = 0;
        for (int i = 12; i < 16; i++)
        {

            GameObject newCard = Instantiate(cardPrefab, new Vector3(1060, 1250 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset + 80;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        yOffset = 0;
        for (int i = 16; i < 20; i++)
        {

            GameObject newCard = Instantiate(cardPrefab, new Vector3(1060, 550 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset + 80;
            zOffset--;
        }
        for (int i = 20; i < 52; i++)
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
        continueButton = GameObject.Find("ContinueButton");
        higherButton = GameObject.Find("HigherButton");
        lowerButton = GameObject.Find("LowerButton");

        button3.SetActive(false);
        button4.SetActive(false);
        continueButton.SetActive(false);
        higherButton.SetActive(false);
        lowerButton.SetActive(false);
        button1.GetComponentInChildren<Text>().text = "Red";
        button2.GetComponentInChildren<Text>().text = "Black";

    }

    public void OnButton1()
    {
        switch (round)
        {
            case 1:
                redOrBlack(1);
                break;
            case 2:
                higherOrLower(1);
                break;
            case 3:
                outOrIn(1);
                break;
            case 4:
                whatSuit(1);
                break;
            case 5:
                StartCoroutine(decideWhoRidesBus());
                break;
            default:
                sceneChanger.SceneLoad("Local5PGame");
                break;
        }
    }

    public void OnButton2()
    {
        switch (round)
        {
            case 1:
                redOrBlack(2);
                break;
            case 2:
                higherOrLower(2);
                break;
            case 3:
                outOrIn(2);
                break;
            case 4:
                whatSuit(2);
                break;
            default:
                sceneChanger.SceneLoad("MainMenu");
                break;
        }
    }

    public void OnButton3()
    {
        whatSuit(3);
    }

    public void OnButton4()
    {
        whatSuit(4);
    }

    public void redOrBlack(int buttonNum)
    {
        if (player == 1)
        {
            GameObject.Find(deck[0]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[0][1] == 'D' || deck[0][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[0][1] == 'C' || deck[0][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 2)
        {
            GameObject.Find(deck[4]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[4][1] == 'D' || deck[4][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[4][1] == 'C' || deck[4][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 3)
        {
            GameObject.Find(deck[8]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[8][1] == 'D' || deck[8][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[8][1] == 'C' || deck[8][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 4)
        {
            GameObject.Find(deck[12]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[12][1] == 'D' || deck[12][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[12][1] == 'C' || deck[12][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 5)
        {
            GameObject.Find(deck[16]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[16][1] == 'D' || deck[16][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[16][1] == 'C' || deck[16][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out two drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink two times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Higher";
            button2.GetComponentInChildren<Text>().text = "Lower";
            continueButton.SetActive(true);
        }
    }

    public void higherOrLower(int buttonNum)
    {
        if (player == 1)
        {
            GameObject.Find(deck[1]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (cardValue[0] < cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[0] < cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }

        else if (player == 2)
        {
            GameObject.Find(deck[5]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (cardValue[4] < cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[4] < cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 3)
        {
            GameObject.Find(deck[9]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (cardValue[8] < cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[8] > cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[8] > cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[8] < cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 4)
        {
            GameObject.Find(deck[13]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (cardValue[12] < cardValue[13])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[12] > cardValue[13])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[12] > cardValue[13])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[12] < cardValue[13])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 5)
        {
            GameObject.Find(deck[17]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (cardValue[16] < cardValue[17])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[16] > cardValue[17])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[16] > cardValue[17])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out four drinks.";
                }
                else if (cardValue[16] < cardValue[17])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink four times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Outside";
            button2.GetComponentInChildren<Text>().text = "Inside";
            continueButton.SetActive(true);
        }
    }

    public void outOrIn(int buttonNum)
    {
        int highCard;
        int lowCard;
        if (player == 1)
        {
            GameObject.Find(deck[2]).GetComponent<Seeable>().faceUp = true;

            if (cardValue[0] >= cardValue[1])
            {
                highCard = cardValue[0];
                lowCard = cardValue[1];
            }
            else
            {
                highCard = cardValue[1];
                lowCard = cardValue[0];
            }

            if (buttonNum == 1)
            {
                if (cardValue[2] > highCard || cardValue[2] < lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[2] < highCard && cardValue[2] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 2)
        {
            GameObject.Find(deck[6]).GetComponent<Seeable>().faceUp = true;

            if (cardValue[4] >= cardValue[5])
            {
                highCard = cardValue[4];
                lowCard = cardValue[5];
            }
            else
            {
                highCard = cardValue[5];
                lowCard = cardValue[4];
            }

            if (buttonNum == 1)
            {
                if (cardValue[6] > highCard || cardValue[6] < lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[6] < highCard && cardValue[6] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 3)
        {
            GameObject.Find(deck[10]).GetComponent<Seeable>().faceUp = true;

            if (cardValue[8] >= cardValue[9])
            {
                highCard = cardValue[8];
                lowCard = cardValue[9];
            }
            else
            {
                highCard = cardValue[9];
                lowCard = cardValue[8];
            }

            if (buttonNum == 1)
            {
                if (cardValue[10] > highCard || cardValue[10] < lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[10] == highCard || cardValue[10] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[10] < highCard && cardValue[10] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[10] == highCard || cardValue[10] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 4)
        {
            GameObject.Find(deck[14]).GetComponent<Seeable>().faceUp = true;

            if (cardValue[12] >= cardValue[13])
            {
                highCard = cardValue[12];
                lowCard = cardValue[13];
            }
            else
            {
                highCard = cardValue[13];
                lowCard = cardValue[12];
            }

            if (buttonNum == 1)
            {
                if (cardValue[14] > highCard || cardValue[14] < lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[14] == highCard || cardValue[14] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[14] < highCard && cardValue[14] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[14] == highCard || cardValue[14] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 5)
        {
            GameObject.Find(deck[18]).GetComponent<Seeable>().faceUp = true;

            if (cardValue[16] >= cardValue[17])
            {
                highCard = cardValue[16];
                lowCard = cardValue[17];
            }
            else
            {
                highCard = cardValue[17];
                lowCard = cardValue[16];
            }

            if (buttonNum == 1)
            {
                if (cardValue[18] > highCard || cardValue[18] < lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[18] == highCard || cardValue[18] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[18] < highCard && cardValue[18] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out six drinks.";
                }
                else if (cardValue[18] == highCard || cardValue[18] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink twelve times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink six times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Hearts";
            button2.GetComponentInChildren<Text>().text = "Diamonds";
            button3.GetComponentInChildren<Text>().text = "Clubs";
            button4.GetComponentInChildren<Text>().text = "Spades";
            continueButton.SetActive(true);
        }
    }

    public void whatSuit(int buttonNum)
    {
        if (player == 1)
        {
            GameObject.Find(deck[3]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[3][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[3][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[3][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[3][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 2)
        {
            GameObject.Find(deck[7]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[7][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[7][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[7][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[7][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 3)
        {
            GameObject.Find(deck[11]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[11][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[11][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[11][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[11][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 4)
        {
            GameObject.Find(deck[15]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[15][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[15][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[15][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[15][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            continueButton.SetActive(true);
        }
        else if (player == 5)
        {
            GameObject.Find(deck[19]).GetComponent<Seeable>().faceUp = true;

            if (buttonNum == 1)
            {
                if (deck[19][1] == 'H')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[19][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[19][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[19][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Give out eight drinks.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink eight times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Yes";
            button2.GetComponentInChildren<Text>().text = "Exit Game";
            continueButton.SetActive(true);
        }
    }

    IEnumerator decideWhoRidesBus()
    {
        dialogueBox.SetActive(false);
        List<string> player1Cards = new List<string>();
        List<string> player2Cards = new List<string>();
        List<string> player3Cards = new List<string>();
        List<string> player4Cards = new List<string>();
        List<string> player5Cards = new List<string>();
        round++;

        for (int i = 0; i < 4; i++)
        {
            player1Cards.Add(deck[i]);
        }
        for (int i = 4; i < 8; i++)
        {
            player2Cards.Add(deck[i]);
        }
        for (int i = 8; i < 12; i++)
        {
            player3Cards.Add(deck[i]);
        }
        for (int i = 12; i < 16; i++)
        {
            player4Cards.Add(deck[i]);
        }
        for (int i = 16; i < 20; i++)
        {
            player5Cards.Add(deck[i]);
        }

        for (int i = 20; i < 52; i++)
        {
            GameObject middleCard = Instantiate(cardPrefab, new Vector3(540, 960, 0), Quaternion.identity);
            middleCard.name = deck[i];
            middleCard.GetComponent<Seeable>().faceUp = true;
            yield return new WaitForSeconds(0.8f);
            for (int j = 0; j < 20; j++)
            {
                if (deck[i][0] == deck[j][0] && GameObject.Find(deck[j]) != null)
                {
                    Destroy(GameObject.Find(deck[j]));
                    if (j <= 3)
                    {
                        player1Cards.Remove(deck[j]);
                    }
                    else if (j >= 4 && j <= 7)
                    {
                        player2Cards.Remove(deck[j]);
                    }
                    else if (j >= 8 && j <= 11)
                    {
                        player3Cards.Remove(deck[j]);
                    }
                    else if (j >= 12 && j <= 15)
                    {
                        player4Cards.Remove(deck[j]);
                    }
                    else if (j >= 16)
                    {
                        player5Cards.Remove(deck[j]);
                    }
                }
            }
            if ((player1Cards.Count == 0 && player2Cards.Count == 0 && player3Cards.Count == 0 && player4Cards.Count == 0 && player5Cards.Count == 0) || i == 51)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                StartCoroutine(BusTie());
                break;
            }
            else if (player1Cards.Count == 0 && player2Cards.Count == 0 && player3Cards.Count == 0 && player4Cards.Count == 0)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                dialogueText.GetComponent<Text>().text = "Purple is riding the bus, are you ready?";
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                dialogueBox.SetActive(true);
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                break;
            }
            else if (player1Cards.Count == 0 && player2Cards.Count == 0 && player3Cards.Count == 0 && player5Cards.Count == 0)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                dialogueText.GetComponent<Text>().text = "Yellow is riding the bus, are you ready?";
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                dialogueBox.SetActive(true);
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                break;
            }
            else if (player1Cards.Count == 0 && player2Cards.Count == 0 && player4Cards.Count == 0 && player5Cards.Count == 0)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                dialogueText.GetComponent<Text>().text = "Green is riding the bus, are you ready?";
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                dialogueBox.SetActive(true);
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                break;
            }
            else if (player1Cards.Count == 0 && player3Cards.Count == 0 && player4Cards.Count == 0 && player5Cards.Count == 0)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                dialogueText.GetComponent<Text>().text = "Blue is riding the bus, are you ready?";
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                dialogueBox.SetActive(true);
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                break;
            }
            else if (player2Cards.Count == 0 && player3Cards.Count == 0 && player4Cards.Count == 0 && player5Cards.Count == 0)
            {
                Destroy(GameObject.Find(deck[i]));
                for (int j = 0; j < 20; j++)
                {
                    Destroy(GameObject.Find(deck[j]));
                }
                dialogueText.GetComponent<Text>().text = "Red is riding the bus, are you ready?";
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                dialogueBox.SetActive(true);
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                break;
            }
            Destroy(GameObject.Find(deck[i]));
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator BusTie()
    {
        int playerBus = 0;
        busTieBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        List<string> tieDeck;
        tieDeck = GenerateDeck();
        ShuffleDeck(tieDeck);
        for (int i = 0; i < 52; i++)
        {
            if (i == 0 || i == 5 || i == 10 || i == 15 || i == 20 || i == 25 || i == 30 || i == 35 || i == 40 || i == 45 || i == 50)
            {
                GameObject tieCard = Instantiate(cardPrefab, new Vector3(540, 300, 0), Quaternion.identity);
                tieCard.name = tieDeck[i];
                if (i != 0)
                {
                    Destroy(GameObject.Find(tieDeck[i - 5]));
                }
            }
            else if (i == 1 || i == 6 || i == 11 || i == 16 || i == 21 || i == 26 || i == 31 || i == 36 || i == 41 || i == 46 || i == 51)
            {
                GameObject tieCard = Instantiate(cardPrefab, new Vector3(180, 680, 0), Quaternion.identity);
                tieCard.name = tieDeck[i];
                if (i != 1)
                {
                    Destroy(GameObject.Find(tieDeck[i - 5]));
                }
            }
            else if (i == 2 || i == 7 || i == 12 || i == 17 || i == 22 || i == 27 || i == 32 || i == 37 || i == 42 || i == 47 || i == 52)
            {
                GameObject tieCard = Instantiate(cardPrefab, new Vector3(180, 1400, 0), Quaternion.identity);
                tieCard.name = tieDeck[i];
                if (i != 2)
                {
                    Destroy(GameObject.Find(tieDeck[i - 5]));
                }
            }
            else if (i == 3 || i == 8 || i == 13 || i == 18 || i == 23 || i == 28 || i == 33 || i == 38 || i == 43 || i == 48)
            {
                GameObject tieCard = Instantiate(cardPrefab, new Vector3(900, 1400, 0), Quaternion.identity);
                tieCard.name = tieDeck[i];
                if (i != 3)
                {
                    Destroy(GameObject.Find(tieDeck[i - 5]));
                }
            }
            else
            {
                GameObject tieCard = Instantiate(cardPrefab, new Vector3(900, 680, 0), Quaternion.identity);
                tieCard.name = tieDeck[i];
                if (i != 4)
                {
                    Destroy(GameObject.Find(tieDeck[i - 5]));
                }
            }
            GameObject.Find(tieDeck[i]).GetComponent<Seeable>().faceUp = true;
            yield return new WaitForSeconds(0.8f);
            if (tieDeck[i][0] == 'A')
            {
                playerMarkerRed.SetActive(false);
                playerMarkerBlue.SetActive(false);
                playerMarkerGreen.SetActive(false);
                playerMarkerYellow.SetActive(false);
                playerMarkerPurple.SetActive(false);
                if (i == 0 || i == 5 || i == 10 || i == 15 || i == 20 || i == 25 || i == 30 || i == 35 || i == 40 || i == 45 || i == 50)
                {
                    dialogueText.GetComponent<Text>().text = "Red is riding the bus, are you ready?";
                }
                else if (i == 1 || i == 6 || i == 11 || i == 16 || i == 21 || i == 26 || i == 31 || i == 36 || i == 41 || i == 46 || i == 51)
                {
                    dialogueText.GetComponent<Text>().text = "Blue is riding the bus, are you ready?";
                }
                else if (i == 2 || i == 7 || i == 12 || i == 17 || i == 22 || i == 27 || i == 32 || i == 37 || i == 42 || i == 47 || i == 52)
                {
                    dialogueText.GetComponent<Text>().text = "Green is riding the bus, are you ready?";
                }
                else if (i == 3 || i == 8 || i == 13 || i == 18 || i == 23 || i == 28 || i == 33 || i == 38 || i == 43 || i == 48)
                {
                    dialogueText.GetComponent<Text>().text = "Yellow is riding the bus, are you ready?";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Purple is riding the bus, are you ready?";
                }
                continueButton.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(false);
                if (i > 3)
                {
                    for (int j = i - 4; j <= i; j++)
                    {
                        Destroy(GameObject.Find(tieDeck[j]));
                    }
                }
                else if (i == 3)
                {
                    Destroy(GameObject.Find(tieDeck[i]));
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                    Destroy(GameObject.Find(tieDeck[i - 2]));
                    Destroy(GameObject.Find(tieDeck[i - 3]));
                }
                else if (i == 2)
                {
                    Destroy(GameObject.Find(tieDeck[i]));
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                    Destroy(GameObject.Find(tieDeck[i - 2]));
                }
                else if (i == 1)
                {
                    Destroy(GameObject.Find(tieDeck[i]));
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                }
                else
                {
                    Destroy(GameObject.Find(tieDeck[i]));
                }
                busTieBox.SetActive(false);
                dialogueBox.SetActive(true);
                break;
            }
        }
    }

    public void RideTheBus()
    {

        busDeck = GenerateDeck();
        ShuffleDeck(busDeck);
        SetUpBus();
        currentBusCards = new string[] { busDeck[0], busDeck[1], busDeck[2], busDeck[3], busDeck[4], busDeck[5], busDeck[6], busDeck[7], busDeck[8], busDeck[9], busDeck[10] };

        for (int i = 0; i < 11; i++)
        {
            switch (currentBusCards[i][0])
            {
                case '2':
                    currentBusValues[i] = 2;
                    break;
                case '3':
                    currentBusValues[i] = 3;
                    break;
                case '4':
                    currentBusValues[i] = 4;
                    break;
                case '5':
                    currentBusValues[i] = 5;
                    break;
                case '6':
                    currentBusValues[i] = 6;
                    break;
                case '7':
                    currentBusValues[i] = 7;
                    break;
                case '8':
                    currentBusValues[i] = 8;
                    break;
                case '9':
                    currentBusValues[i] = 9;
                    break;
                case 'T':
                    currentBusValues[i] = 10;
                    break;
                case 'J':
                    currentBusValues[i] = 11;
                    break;
                case 'Q':
                    currentBusValues[i] = 12;
                    break;
                case 'K':
                    currentBusValues[i] = 13;
                    break;
                default:
                    currentBusValues[i] = 14;
                    break;
            }
        }

        higherButton.SetActive(true);
        lowerButton.SetActive(true);
        rideBusBox.SetActive(true);
    }

    void SetUpBus()
    {

        for (int i = 0; i < 11; i++)
        {
            if (i == 0)
            {
                GameObject busCard = Instantiate(cardPrefab, new Vector3(200, 1550, 0), Quaternion.identity);
                busCard.name = busDeck[i];
                busCard.GetComponent<Seeable>().faceUp = true;
            }
            else if (i <= 4)
            {
                GameObject busCard = Instantiate(cardPrefab, new Vector3(180 + (i - 1) * 240, 500, 0), Quaternion.identity);
                busCard.name = busDeck[i];
            }
            else if (i <= 7)
            {
                GameObject busCard = Instantiate(cardPrefab, new Vector3(300 + (i - 5) * 240, 850, 0), Quaternion.identity);
                busCard.name = busDeck[i];
            }
            else if (i <= 9)
            {
                GameObject busCard = Instantiate(cardPrefab, new Vector3(420 + (i - 8) * 240, 1200, 0), Quaternion.identity);
                busCard.name = busDeck[i];
            }
            else if (i <= 10)
            {
                GameObject busCard = Instantiate(cardPrefab, new Vector3(540, 1550, 0), Quaternion.identity);
                busCard.name = busDeck[i];
            }
        }
    }

    public void ResetBus()
    {
        if (busRound + busDeckPlaceholder <= 51)
        {
            for (int i = 0; i < busRound; i++)
            {
                Destroy(GameObject.Find(currentBusCards[i]));
            }
            GameObject.Find(currentBusCards[busRound]).transform.position = new Vector3(200, 1550, 0);
            currentBusCards[0] = currentBusCards[busRound];
            for (int i = 1; i <= busRound; i++)
            {
                if (i == 0)
                {
                    GameObject busCard = Instantiate(cardPrefab, new Vector3(200, 1550, 0), Quaternion.identity);
                    busCard.name = busDeck[busDeckPlaceholder + i];
                    busCard.GetComponent<Seeable>().faceUp = true;
                }
                else if (i <= 4)
                {
                    GameObject busCard = Instantiate(cardPrefab, new Vector3(180 + (i - 1) * 240, 500, 0), Quaternion.identity);
                    busCard.name = busDeck[busDeckPlaceholder + i];
                }
                else if (i <= 7)
                {
                    GameObject busCard = Instantiate(cardPrefab, new Vector3(300 + (i - 5) * 240, 850, 0), Quaternion.identity);
                    busCard.name = busDeck[busDeckPlaceholder + i];
                }
                else if (i <= 9)
                {
                    GameObject busCard = Instantiate(cardPrefab, new Vector3(420 + (i - 8) * 240, 1200, 0), Quaternion.identity);
                    busCard.name = busDeck[busDeckPlaceholder + i];
                }
                else if (i <= 10)
                {
                    GameObject busCard = Instantiate(cardPrefab, new Vector3(540, 1550, 0), Quaternion.identity);
                    busCard.name = busDeck[busDeckPlaceholder + i];
                }
                currentBusCards[i] = busDeck[busDeckPlaceholder + i];
            }
            busDeckPlaceholder = busDeckPlaceholder + busRound;
            busRound = 1;
            for (int i = 0; i < 11; i++)
            {
                switch (currentBusCards[i][0])
                {
                    case '2':
                        currentBusValues[i] = 2;
                        break;
                    case '3':
                        currentBusValues[i] = 3;
                        break;
                    case '4':
                        currentBusValues[i] = 4;
                        break;
                    case '5':
                        currentBusValues[i] = 5;
                        break;
                    case '6':
                        currentBusValues[i] = 6;
                        break;
                    case '7':
                        currentBusValues[i] = 7;
                        break;
                    case '8':
                        currentBusValues[i] = 8;
                        break;
                    case '9':
                        currentBusValues[i] = 9;
                        break;
                    case 'T':
                        currentBusValues[i] = 10;
                        break;
                    case 'J':
                        currentBusValues[i] = 11;
                        break;
                    case 'Q':
                        currentBusValues[i] = 12;
                        break;
                    case 'K':
                        currentBusValues[i] = 13;
                        break;
                    default:
                        currentBusValues[i] = 14;
                        break;
                }
            }
        }
        else
        {
            StartCoroutine(LostTheBus());
        }
    }

    public void OnHigherButton()
    {
        GameObject.Find(currentBusCards[busRound]).GetComponent<Seeable>().faceUp = true;
        if (currentBusValues[busRound] > currentBusValues[busRound - 1])
        {
            busRound++;
            rideBusText.GetComponent<Text>().text = "Correct!";
            if (busRound == 11)
            {
                StartCoroutine(WonTheBus());
            }
        }
        else if (currentBusValues[busRound] < currentBusValues[busRound - 1])
        {
            if (busRound <= 4)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 1 times.";
            }
            else if (busRound <= 7)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 2 times.";
            }
            else if (busRound <= 9)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 3 times.";
            }
            else if (busRound <= 10)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 4 times.";
            }
            ResetBus();
        }
        else
        {
            if (busRound <= 4)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 2 times.";
            }
            else if (busRound <= 7)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 4 times.";
            }
            else if (busRound <= 9)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 6 times.";
            }
            else if (busRound <= 10)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 8 times.";
            }
            ResetBus();
        }
    }

    public void OnLowerButton()
    {
        GameObject.Find(currentBusCards[busRound]).GetComponent<Seeable>().faceUp = true;
        if (currentBusValues[busRound] < currentBusValues[busRound - 1])
        {
            busRound++;
            rideBusText.GetComponent<Text>().text = "Correct!";
            if (busRound == 11)
            {
                StartCoroutine(WonTheBus());
            }
        }
        else if (currentBusValues[busRound] > currentBusValues[busRound - 1])
        {
            if (busRound <= 4)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 1 times.";
            }
            else if (busRound <= 7)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 2 times.";
            }
            else if (busRound <= 9)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 3 times.";
            }
            else if (busRound <= 10)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 4 times.";
            }
            ResetBus();
        }
        else
        {
            if (busRound <= 4)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 2 times.";
            }
            else if (busRound <= 7)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 4 times.";
            }
            else if (busRound <= 9)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 6 times.";
            }
            else if (busRound <= 10)
            {
                rideBusText.GetComponent<Text>().text = "Wrong. Drink 8 times.";
            }
            ResetBus();
        }
    }

    IEnumerator WonTheBus()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 11; i++)
        {
            Destroy(GameObject.Find(currentBusCards[i]));
        }
        higherButton.SetActive(false);
        lowerButton.SetActive(false);
        rideBusBox.SetActive(false);

        dialogueText.GetComponent<Text>().text = "You beat the bus! Play again?";
        dialogueBox.SetActive(true);
        continueButton.SetActive(false);
        round++;
        button1.SetActive(true);
        button2.SetActive(true);

    }

    IEnumerator LostTheBus()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 11; i++)
        {
            Destroy(GameObject.Find(currentBusCards[i]));
        }
        higherButton.SetActive(false);
        lowerButton.SetActive(false);
        rideBusBox.SetActive(false);
        dialogueText.GetComponent<Text>().text = "You lost the bus! You are terrible! Play again?";
        dialogueBox.SetActive(true);
        continueButton.SetActive(false);
        round++;
        button1.SetActive(true);
        button2.SetActive(true);

    }

    public void ChangeCardRotation()
    {
        if (player == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerRed.transform.Rotate(0f, 0f, 90f);
            playerMarkerBlue.transform.Rotate(0f, 0f, 90f);
        }
        else if (player == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            for (int i = 16; i < 20; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerRed.transform.Rotate(0f, 0f, 90f);
            playerMarkerPurple.transform.Rotate(0f, 0f, 90f);
        }
        else if (player == 3)
        {
            for (int i = 4; i < 12; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerGreen.transform.Rotate(0f, 0f, 90f);
            playerMarkerBlue.transform.Rotate(0f, 0f, 90f);
        }
        else if (player == 4)
        {
            for (int i = 8; i < 16; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerGreen.transform.Rotate(0f, 0f, 90f);
            playerMarkerYellow.transform.Rotate(0f, 0f, 90f);
        }
        else if (player == 5)
        {
            for (int i = 12; i < 20; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerPurple.transform.Rotate(0f, 0f, 90f);
            playerMarkerYellow.transform.Rotate(0f, 0f, 90f);
        }
    }

    public void ChangeCardPlacements()
    {
        Vector3 tempPlayerMarkerPosition = playerMarkerRed.transform.position;
        playerMarkerRed.transform.position = playerMarkerPurple.transform.position;
        playerMarkerPurple.transform.position = playerMarkerYellow.transform.position;
        playerMarkerYellow.transform.position = playerMarkerGreen.transform.position;
        playerMarkerGreen.transform.position = playerMarkerBlue.transform.position;
        playerMarkerBlue.transform.position = tempPlayerMarkerPosition;

        Vector3 tempCardPosition = GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[0]).transform.position = new Vector3(GameObject.Find(deck[16]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[16]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[16]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[16]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[16]).transform.position = new Vector3(GameObject.Find(deck[12]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[12]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[12]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[16]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[12]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[12]).transform.position = new Vector3(GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[12]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[8]).transform.position = new Vector3(GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[4]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[1]).transform.position = new Vector3(GameObject.Find(deck[17]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[17]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[17]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[17]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[17]).transform.position = new Vector3(GameObject.Find(deck[13]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[13]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[13]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[17]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[13]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[13]).transform.position = new Vector3(GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[13]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[9]).transform.position = new Vector3(GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[5]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[2]).transform.position = new Vector3(GameObject.Find(deck[18]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[18]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[18]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[18]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[18]).transform.position = new Vector3(GameObject.Find(deck[14]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[14]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[14]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[18]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[14]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[14]).transform.position = new Vector3(GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[14]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[10]).transform.position = new Vector3(GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[6]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[3]).transform.position = new Vector3(GameObject.Find(deck[19]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[19]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[19]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[19]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[19]).transform.position = new Vector3(GameObject.Find(deck[15]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[15]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[15]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[19]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[15]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[15]).transform.position = new Vector3(GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[15]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[11]).transform.position = new Vector3(GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[7]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
    }

    public void OnContinueButton()
    {
        if (round <= 5)
        {
            if (player == 5)
            {
                round++;
                player = 1;
            }
            else if (player == 1 || player == 2 || player == 3 || player == 4)
            {
                player++;
            }
            button1.SetActive(true);
            button2.SetActive(true);
            if (round == 4)
            {
                button3.SetActive(true);
                button4.SetActive(true);
            }
            ChangeCardPlacements();
            ChangeCardRotation();
            continueButton.SetActive(false);
            if (round == 1)
            {
                dialogueText.GetComponent<Text>().text = "Red or black?";
            }
            else if (round == 2)
            {
                dialogueText.GetComponent<Text>().text = "Higher or lower?";
            }
            else if (round == 3)
            {
                dialogueText.GetComponent<Text>().text = "Outside or inside?";
            }
            else if (round == 4)
            {
                dialogueText.GetComponent<Text>().text = "What suit?";
            }
            else if (round == 5)
            {
                dialogueText.GetComponent<Text>().text = "Ready to decide who is riding the bus?";
            }
        }

        if (round == 6)
        {
            dialogueBox.SetActive(false);
            RideTheBus();
        }
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

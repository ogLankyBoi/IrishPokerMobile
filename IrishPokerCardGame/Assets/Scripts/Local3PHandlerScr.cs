﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Local3PHandlerScr : MonoBehaviour
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
    public GameObject inGameSettingsButton;

    public GameObject dialogueText;
    public GameObject dialogueBox;
    public GameObject inGameOptions;
    public GameObject rideBusBox;
    public GameObject rideBusText;
    public GameObject busTieBox;
    public GameObject playerMarkerRed;
    public GameObject playerMarkerBlue;
    public GameObject playerMarkerGreen;
    public GameObject playerScore1Text;
    public GameObject playerScore2Text;
    public GameObject playerScore3Text;
    public int playerScore1Val = 0;
    public int playerScore2Val = 0;
    public int playerScore3Val = 0;
    public GameObject scoreBackground1;
    public GameObject scoreBackground2;
    public GameObject scoreBackground3;

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
        playerScore1Text = GameObject.Find("PlayerScore1");
        playerScore2Text = GameObject.Find("PlayerScore2");
        playerScore3Text = GameObject.Find("PlayerScore3");
        scoreBackground1 = GameObject.Find("ScoreBackground1");
        scoreBackground2 = GameObject.Find("ScoreBackground2");
        scoreBackground3 = GameObject.Find("ScoreBackground3");
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
            GameObject newCard = Instantiate(cardPrefab, new Vector3(80, 1200 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset - 120;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        yOffset = 0;
        for (int i = 8; i < 12; i++)
        {
            
            GameObject newCard = Instantiate(cardPrefab, new Vector3(1000, 840 + yOffset, zOffset), Quaternion.identity);
            newCard.name = deck[i];
            GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);

            yOffset = yOffset + 120;
            zOffset--;
        }
        for (int i = 12; i < 52; i++)
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
        inGameSettingsButton = GameObject.Find("InGameSettingsButton");

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
                sceneChanger.SceneLoad("Local3PGame");
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[0][1] == 'C' || deck[0][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[4][1] == 'C' || deck[4][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[8][1] == 'C' || deck[8][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets a point.";
                    playerScore1Val++;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val++;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get a point.";
                    playerScore3Val++;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[0] < cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();

                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();

                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[4] < cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else if (cardValue[8] > cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();

                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[8] > cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets two points.";
                    playerScore1Val = playerScore1Val + 2;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 2;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else if (cardValue[8] < cardValue[9])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get two points.";
                    playerScore3Val = playerScore3Val + 2;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore1Val = playerScore1Val + 6;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[2] < highCard && cardValue[2] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore1Val = playerScore1Val + 6;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore2Val = playerScore2Val + 6;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[6] < highCard && cardValue[6] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore2Val = playerScore2Val + 6;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else if (cardValue[10] == highCard || cardValue[10] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore3Val = playerScore3Val + 6;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[10] < highCard && cardValue[10] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets three points.";
                    playerScore1Val = playerScore1Val + 3;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 3;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else if (cardValue[10] == highCard || cardValue[10] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. You get six points.";
                    playerScore3Val = playerScore3Val + 6;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get three points.";
                    playerScore3Val = playerScore3Val + 3;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[3][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[3][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[3][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[7][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[7][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[7][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
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
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[11][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[11][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[11][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! Everyone else gets four points.";
                    playerScore1Val = playerScore1Val + 4;
                    playerScore1Text.GetComponent<Text>().text = playerScore1Val.ToString();
                    playerScore2Val = playerScore2Val + 4;
                    playerScore2Text.GetComponent<Text>().text = playerScore2Val.ToString();
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. You get four points.";
                    playerScore3Val = playerScore3Val + 4;
                    playerScore3Text.GetComponent<Text>().text = playerScore3Val.ToString();
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
        round++;
        dialogueBox.SetActive(false);
        scoreBackground1.SetActive(false);
        scoreBackground2.SetActive(false);
        scoreBackground3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 12; i++)
        {
            Destroy(GameObject.Find(deck[i]));
        }
        if ((playerScore1Val == playerScore2Val && playerScore1Val == playerScore3Val) || (playerScore1Val == playerScore2Val && playerScore1Val > playerScore3Val) || (playerScore1Val == playerScore3Val && playerScore1Val > playerScore2Val) || (playerScore3Val == playerScore2Val && playerScore2Val > playerScore1Val))
        {
            StartCoroutine(BusTie());
        }
        else
        {
            playerMarkerRed.SetActive(false);
            playerMarkerBlue.SetActive(false);
            playerMarkerGreen.SetActive(false);
            RideTheBus();
        }
    }

    IEnumerator BusTie()
    {
        busTieBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        List<string> tieDeck;
        tieDeck = GenerateDeck();
        ShuffleDeck(tieDeck);
        if (playerScore1Val == playerScore2Val && playerScore1Val == playerScore3Val)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24 || i == 27 || i == 30 || i == 33 || i == 36 || i == 39 || i == 42 || i == 45 || i == 48 || i == 51)
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(540, 300, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                    if (i != 0)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 3]));
                    }
                }
                else if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25 || i == 28 || i == 31 || i == 34 || i == 37 || i == 40 || i == 43 || i == 46 || i == 49 || i == 52)
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(180, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                    if (i != 1)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 3]));
                    }
                }
                else
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(900, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                    if (i != 2)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 3]));
                    }
                }
                GameObject.Find(tieDeck[i]).GetComponent<Seeable>().faceUp = true;
                yield return new WaitForSeconds(0.8f);
                if (tieDeck[i][0] == 'A')
                {
                    playerMarkerRed.SetActive(false);
                    playerMarkerBlue.SetActive(false);
                    playerMarkerGreen.SetActive(false);
                    if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24 || i == 27 || i == 30 || i == 33 || i == 36 || i == 39 || i == 42 || i == 45 || i == 48 || i == 51)
                    {
                        dialogueText.GetComponent<Text>().text = "Red is riding the bus, are you ready?";
                    }
                    else if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25 || i == 28 || i == 31 || i == 34 || i == 37 || i == 40 || i == 43 || i == 46 || i == 49 || i == 52)
                    {
                        dialogueText.GetComponent<Text>().text = "Blue is riding the bus, are you ready?";
                    }
                    else
                    {
                        dialogueText.GetComponent<Text>().text = "Green is riding the bus, are you ready?";
                    }
                    continueButton.SetActive(true);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    if (i > 1)
                    {
                        for (int j = i - 3; j <= i; j++)
                        {
                            Destroy(GameObject.Find(tieDeck[j]));
                        }
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
        else if (playerScore1Val == playerScore2Val && playerScore1Val > playerScore3Val)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i % 2 == 0)
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(540, 500, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                else
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(180, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                GameObject.Find(tieDeck[i]).GetComponent<Seeable>().faceUp = true;
                yield return new WaitForSeconds(0.8f);
                if (tieDeck[i][0] == 'A')
                {
                    if (i % 2 == 0)
                    {
                        dialogueText.GetComponent<Text>().text = "Red is riding the bus, are you ready?";
                    }
                    else
                    {
                        dialogueText.GetComponent<Text>().text = "Blue is riding the bus, are you ready?";
                    }
                    continueButton.SetActive(true);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    playerMarkerRed.SetActive(false);
                    playerMarkerBlue.SetActive(false);
                    playerMarkerGreen.SetActive(false);
                    if (i > 0)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 1]));
                    }
                    Destroy(GameObject.Find(tieDeck[i]));
                    busTieBox.SetActive(false);
                    dialogueBox.SetActive(true);
                    break;
                }
                if (i > 0)
                {
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                }
            }
        }
        else if (playerScore1Val == playerScore3Val && playerScore1Val > playerScore2Val)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i % 2 == 0)
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(540, 500, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                else
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(900, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                GameObject.Find(tieDeck[i]).GetComponent<Seeable>().faceUp = true;
                yield return new WaitForSeconds(0.8f);
                if (tieDeck[i][0] == 'A')
                {
                    if (i % 2 == 0)
                    {
                        dialogueText.GetComponent<Text>().text = "Red is riding the bus, are you ready?";
                    }
                    else
                    {
                        dialogueText.GetComponent<Text>().text = "Green is riding the bus, are you ready?";
                    }
                    continueButton.SetActive(true);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    playerMarkerRed.SetActive(false);
                    playerMarkerBlue.SetActive(false);
                    playerMarkerGreen.SetActive(false);
                    if (i > 0)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 1]));
                    }
                    Destroy(GameObject.Find(tieDeck[i]));
                    busTieBox.SetActive(false);
                    dialogueBox.SetActive(true);
                    break;
                }
                if (i > 0)
                {
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                }
            }
        }
        else if (playerScore2Val == playerScore3Val && playerScore2Val > playerScore1Val)
        {
            for (int i = 0; i < 52; i++)
            {
                if (i % 2 == 0)
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(180, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                else
                {
                    GameObject tieCard = Instantiate(cardPrefab, new Vector3(900, 1050, 0), Quaternion.identity);
                    tieCard.name = tieDeck[i];
                }
                GameObject.Find(tieDeck[i]).GetComponent<Seeable>().faceUp = true;
                yield return new WaitForSeconds(0.8f);
                if (tieDeck[i][0] == 'A')
                {
                    if (i % 2 == 0)
                    {
                        dialogueText.GetComponent<Text>().text = "Blue is riding the bus, are you ready?";
                    }
                    else
                    {
                        dialogueText.GetComponent<Text>().text = "Green is riding the bus, are you ready?";
                    }
                    continueButton.SetActive(true);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    playerMarkerRed.SetActive(false);
                    playerMarkerBlue.SetActive(false);
                    playerMarkerGreen.SetActive(false);
                    if (i > 0)
                    {
                        Destroy(GameObject.Find(tieDeck[i - 1]));
                    }
                    Destroy(GameObject.Find(tieDeck[i]));
                    busTieBox.SetActive(false);
                    dialogueBox.SetActive(true);
                    break;
                }
                if (i > 0)
                {
                    Destroy(GameObject.Find(tieDeck[i - 1]));
                }
            }
        }
    }

    public void RideTheBus()
    {
        inGameSettingsButton.SetActive(true);
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
            rideBusText.GetComponent<Text>().text = "Wrong. Try again.";
            ResetBus();
        }
        else
        {
            rideBusText.GetComponent<Text>().text = "Wrong. Try again.";
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
            rideBusText.GetComponent<Text>().text = "Wrong. Try again.";
            ResetBus();
        }
        else
        {
            rideBusText.GetComponent<Text>().text = "Wrong. Try again.";
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
        Dictionary<string, int> scores = new Dictionary<string, int>
        {
            ["Red"] = playerScore1Val,
            ["Blue"] = playerScore2Val,
            ["Green"] = playerScore3Val,
        };
        List<int> playerScores = new List<int>();
        List<string> playerName = new List<string>();
        List<int> playerRank = new List<int>();
        playerScores.Add(playerScore1Val);
        playerScores.Add(playerScore2Val);
        playerScores.Add(playerScore3Val);
        playerScores.Sort((a, b) => a.CompareTo(b));
        int pastScore = 0;

        int rank = 0;
        foreach (var value in playerScores)
        {
            foreach (var k in scores.Keys)
            {
                if (pastScore == value)
                {
                    break;
                }
                if (scores[k] == value)
                {
                    playerName.Add(k);
                    playerRank.Add(rank);
                }
            }
            pastScore = value;
            rank++;
        }
        string[] playerNames = playerName.ToArray();
        int[] playerRanks = playerRank.ToArray();
        dialogueText.GetComponent<Text>().text = "You beat the bus!\n\nPlayer Rankings\n" + playerNames[0] + " : " + playerRanks[0] + "\n" + playerNames[1] + " : " + playerRanks[1] + "\n" + playerNames[2] + " : " + playerRanks[2] + "\n\n Play again?";
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
            for (int i = 8; i < 12; i++)
            {
                GameObject.Find(deck[i]).transform.Rotate(0f, 0f, 90f);
            }
            playerMarkerRed.transform.Rotate(0f, 0f, 90f);
            playerMarkerGreen.transform.Rotate(0f, 0f, 90f);
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
    }

    public void ChangeCardPlacements()
    {
        Vector3 tempPlayerMarkerPosition = playerMarkerRed.transform.position;
        playerMarkerRed.transform.position = playerMarkerGreen.transform.position;
        playerMarkerGreen.transform.position = playerMarkerBlue.transform.position;
        playerMarkerBlue.transform.position = tempPlayerMarkerPosition;

        Vector3 tempScorePosition = scoreBackground1.transform.position;
        scoreBackground1.transform.position = scoreBackground3.transform.position;
        scoreBackground3.transform.position = scoreBackground2.transform.position;
        scoreBackground2.transform.position = tempScorePosition;

        Vector3 tempCardPosition = GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[0]).transform.position = new Vector3(GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[8]).transform.position = new Vector3(GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[8]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[4]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[1]).transform.position = new Vector3(GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[9]).transform.position = new Vector3(GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[9]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[5]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[2]).transform.position = new Vector3(GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[10]).transform.position = new Vector3(GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[10]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[6]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;

        tempCardPosition = GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[3]).transform.position = new Vector3(GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[11]).transform.position = new Vector3(GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[11]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[7]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
    }

    public void OnContinueButton()
    {
        if (round <= 5)
        {
            if (player == 3)
            {
                round++;
                player = 1;
            }
            else if (player == 1 || player == 2)
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
                if (playerScore1Val > playerScore2Val && playerScore1Val > playerScore3Val)
                {
                    dialogueText.GetComponent<Text>().text = "Red lost! Ready to ride the bus?";
                }
                else if (playerScore2Val > playerScore1Val && playerScore2Val > playerScore3Val)
                {
                    dialogueText.GetComponent<Text>().text = "Blue lost! Ready to ride the bus?";
                }
                else if (playerScore3Val > playerScore1Val && playerScore3Val > playerScore2Val)
                {
                    dialogueText.GetComponent<Text>().text = "Green lost! Ready to ride the bus?";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "It's a tie! Ready to decide who is riding the bus?";
                }
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

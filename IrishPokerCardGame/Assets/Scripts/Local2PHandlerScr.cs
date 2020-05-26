﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Local2PHandlerScr : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public SceneChanger sceneChanger;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

    public List<string> deck;
    public List<string> restOfDeck;
    public List<int> cardValue;
    public List<int> cardDrinks;

    public int round = 1;
    public int player = 1;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject continueButton;

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
        float zOffset = 0;
        for (int i = 0; i < 4; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(160 + xOffset, 200, zOffset), Quaternion.identity);
            newCard.name = deck[i];

            xOffset = xOffset + 250;
            zOffset--;
        }
        xOffset = 0;
        zOffset = 0;
        for (int i = 4; i < 8; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(720 - xOffset, 1900, zOffset), Quaternion.identity);
            newCard.name = deck[i];

            xOffset = xOffset + 120;
            zOffset--;
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
        continueButton = GameObject.Find("ContinueButton");

        button3.SetActive(false);
        button4.SetActive(false);
        continueButton.SetActive(false);
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
            default:
                sceneChanger.SceneLoad("Local2PGame");
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[0] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[0][1] == 'C' || deck[0][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[0] + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[4] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[4][1] == 'C' || deck[4][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[4] + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[1] + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[1] * 2 + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[0] > cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[0] < cardValue[1])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[1] + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[1] * 2 + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[1] + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[1] * 2 + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[4] > cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[4] < cardValue[5])
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[5] + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[5] * 2 + " times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Outside";
            button2.GetComponentInChildren<Text>().text = "Inside";
            continueButton.SetActive(true);
        }
    }

    public void outOrIn (int buttonNum)
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[2] * 2 + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[2] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[2] < highCard && cardValue[2] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[2] == highCard || cardValue[2] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[2] * 2 + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[2] + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[6] * 2 + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[6] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (cardValue[6] < highCard && cardValue[6] > lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else if (cardValue[6] == highCard || cardValue[6] == lowCard)
                {
                    dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + cardDrinks[6] * 2 + " times.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[6] + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[3] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[3][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[3] + " times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[3][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[3] + " times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[3][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[3] + " times.";
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
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[7] + " times.";
                }
            }
            else if (buttonNum == 2)
            {
                if (deck[7][1] == 'D')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[7] + " times.";
                }
            }
            else if (buttonNum == 3)
            {
                if (deck[7][1] == 'C')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[7] + " times.";
                }
            }
            else if (buttonNum == 4)
            {
                if (deck[7][1] == 'S')
                {
                    dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink.";
                }
                else
                {
                    dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + cardDrinks[7] + " times.";
                }
            }
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button1.GetComponentInChildren<Text>().text = "Yes";
            button2.GetComponentInChildren<Text>().text = "Exit";
            continueButton.SetActive(true);
        }
    }

    public void ChangeCardPlacements()
    {

        Vector3 tempCardPosition = GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[0]).transform.position = new Vector3(GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[0]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[4]).transform.position = new Vector3(tempCardPosition.x,tempCardPosition.y,tempCardPosition.z);
        GameObject.Find(deck[4]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
        tempCardPosition = GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[1]).transform.position = new Vector3(GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[1]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[5]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[5]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
        tempCardPosition = GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[2]).transform.position = new Vector3(GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[2]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[6]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[6]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
        tempCardPosition = GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[3]).transform.position = new Vector3(GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.x, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.y, GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos.z);
        GameObject.Find(deck[3]).GetComponent<TransformCardPosition>().cardPos = GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos;
        GameObject.Find(deck[7]).transform.position = new Vector3(tempCardPosition.x, tempCardPosition.y, tempCardPosition.z);
        GameObject.Find(deck[7]).GetComponent<TransformCardPosition>().cardPos = tempCardPosition;
    }

    public void OnContinueButton()
    {
        if (player == 2)
        {
            round++;
            player--;
        }
        else if (player == 1)
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
            dialogueText.GetComponent<Text>().text = "Play again?";
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

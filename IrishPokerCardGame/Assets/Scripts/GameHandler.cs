using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };

    public List<string> deck;
    public List<string> restOfDeck;
    public int round = 1;
    public int card1Value;
    public int card2Value;
    public int card3Value;
    public int card4Value;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public GameObject dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        startPlaying();
    }

    // Update is called once per frame

    public void startPlaying()
    {
        dialogueText = GameObject.Find("DialogueText");
        setUpButtons();
        deck = GenerateDeck();
        ShuffleDeck(deck);
        Deal();
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

    void Deal()
    {
        float xOffset = 0;
        for(int i = 0; i < 4; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(160 + xOffset, 200, 0), Quaternion.identity);
            newCard.name = deck[i];

            xOffset = xOffset + 250;
        }
        for(int i = 4; i < 52; i++)
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

    public void OnButton1()
    {
        if (round == 1)
        {
            redOrBlack(1);
        }
        else if (round == 2)
        {
            higherOrLower(1);
        }
    }

    public void OnButton2()
    {
        if (round == 1)
        {
            redOrBlack(2);
        }
        else if (round == 2)
        {
            higherOrLower(2);
        }
    }

    public void OnButton3()
    {

    }

    public void OnButton4()
    {

    }

    public void redOrBlack(int buttonNum)
    {
        GameObject.Find(deck[0]).GetComponent<Seeable>().faceUp = true;
        switch (deck[0][0])
        {
            case '2':
                card1Value = 2;
                break;
            case '3':
                card1Value = 3;
                break;
            case '4':
                card1Value = 4;
                break;
            case '5':
                card1Value = 5;
                break;
            case '6':
                card1Value = 6;
                break;
            case '7':
                card1Value = 7;
                break;
            case '8':
                card1Value = 8;
                break;
            case '9':
                card1Value = 9;
                break;
            case 'T':
                card1Value = 10;
                break;
            case 'J':
                card1Value = 11;
                break;
            case 'Q':
                card1Value = 12;
                break;
            case 'K':
                card1Value = 13;
                break;
            default:
                card1Value = 14;
                break;
        }
        if (buttonNum == 1)
        {
            if (deck[0][1] == 'D' || deck[0][1] == 'H')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Higher or lower?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card1Value + " times" + Environment.NewLine + Environment.NewLine + "Higher or lower?";
            }
        }
        else if (buttonNum == 2)
        {
            if (deck[0][1] == 'C' || deck[0][1] == 'S')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Higher or lower?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card1Value + " times." + Environment.NewLine + Environment.NewLine + "Higher or lower?";
            }
        }

        button1.GetComponentInChildren<Text>().text = "Higher";
        button2.GetComponentInChildren<Text>().text = "Lower";
        round++;
    }

    public void higherOrLower(int buttonNum)
    {
        GameObject.Find(deck[1]).GetComponent<Seeable>().faceUp = true;
        switch (deck[1][0])
        {
            case '2':
                card1Value = 2;
                break;
            case '3':
                card1Value = 3;
                break;
            case '4':
                card1Value = 4;
                break;
            case '5':
                card1Value = 5;
                break;
            case '6':
                card1Value = 6;
                break;
            case '7':
                card1Value = 7;
                break;
            case '8':
                card1Value = 8;
                break;
            case '9':
                card1Value = 9;
                break;
            case 'T':
                card1Value = 10;
                break;
            case 'J':
                card1Value = 11;
                break;
            case 'Q':
                card1Value = 12;
                break;
            case 'K':
                card1Value = 13;
                break;
            default:
                card1Value = 14;
                break;
        }

        if (buttonNum == 1)
        {
            if (card1Value < card2Value)
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
            else if (card1Value > card2Value)
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card2Value + " times" + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + card2Value * 2 + " times" + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
        }
        else if (buttonNum == 2)
        {
            if (card1Value > card2Value)
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
            else if (card1Value < card2Value)
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card2Value + " times." + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + card2Value * 2 + " times" + Environment.NewLine + Environment.NewLine + "Outside or inside?";
            }
        }

        button1.GetComponentInChildren<Text>().text = "Outside";
        button2.GetComponentInChildren<Text>().text = "Inside";
        round++;
    }
}

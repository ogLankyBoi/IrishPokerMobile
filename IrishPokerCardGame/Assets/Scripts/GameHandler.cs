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
    public SceneChanger sceneChanger;

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
        sceneChanger = GetComponent<SceneChanger>();
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
        else if (round == 3)
        {
            outOrIn(1);
        }
        else if (round == 4)
        {
            whatSuit(1);
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
        else if (round == 3)
        {
            outOrIn(2);
        }
        else if (round == 4)
        {
            whatSuit(2);
        }
    }

    public void OnButton3()
    {
        if (round == 4)
        {
            whatSuit(3);
        }
    }

    public void OnButton4()
    {
        if (round == 4)
        {
            whatSuit(4);
        }
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
                card2Value = 2;
                break;
            case '3':
                card2Value = 3;
                break;
            case '4':
                card2Value = 4;
                break;
            case '5':
                card2Value = 5;
                break;
            case '6':
                card2Value = 6;
                break;
            case '7':
                card2Value = 7;
                break;
            case '8':
                card2Value = 8;
                break;
            case '9':
                card2Value = 9;
                break;
            case 'T':
                card2Value = 10;
                break;
            case 'J':
                card2Value = 11;
                break;
            case 'Q':
                card2Value = 12;
                break;
            case 'K':
                card2Value = 13;
                break;
            default:
                card2Value = 14;
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

    public void outOrIn(int buttonNum)
    {
        int highCard;
        int lowCard;
        GameObject.Find(deck[2]).GetComponent<Seeable>().faceUp = true;
        switch (deck[2][0])
        {
            case '2':
                card3Value = 2;
                break;
            case '3':
                card3Value = 3;
                break;
            case '4':
                card3Value = 4;
                break;
            case '5':
                card3Value = 5;
                break;
            case '6':
                card3Value = 6;
                break;
            case '7':
                card3Value = 7;
                break;
            case '8':
                card3Value = 8;
                break;
            case '9':
                card3Value = 9;
                break;
            case 'T':
                card3Value = 10;
                break;
            case 'J':
                card3Value = 11;
                break;
            case 'Q':
                card3Value = 12;
                break;
            case 'K':
                card3Value = 13;
                break;
            default:
                card3Value = 14;
                break;
        }
        if (card1Value >= card2Value)
        {
            highCard = card1Value;
            lowCard = card2Value;
        }
        else
        {
            highCard = card2Value;
            lowCard = card1Value;
        }

        if (buttonNum == 1)
        {
            if (card3Value > highCard && card3Value < lowCard)
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
            else if (card3Value == highCard || card3Value == lowCard)
            {
                dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + card3Value * 2 + " times" + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card3Value + " times" + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
        }
        else if (buttonNum == 2)
        {
            if (card3Value < highCard && card3Value > lowCard)
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
            else if (card3Value == highCard || card3Value == lowCard)
            {
                dialogueText.GetComponent<Text>().text = "Big oof, they have the same value. Drink " + card3Value * 2 + " times" + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card3Value + " times." + Environment.NewLine + Environment.NewLine + "Hearts, Diamonds, Clubs, or Spades?";
            }
        }

        button3.SetActive(true);
        button4.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Hearts";
        button2.GetComponentInChildren<Text>().text = "Diamonds";
        button3.GetComponentInChildren<Text>().text = "Clubs";
        button4.GetComponentInChildren<Text>().text = "Spades";
        round++;
    }

    public void whatSuit(int buttonNum)
    {
        GameObject.Find(deck[3]).GetComponent<Seeable>().faceUp = true;
        switch (deck[3][0])
        {
            case '2':
                card4Value = 2;
                break;
            case '3':
                card4Value = 3;
                break;
            case '4':
                card4Value = 4;
                break;
            case '5':
                card4Value = 5;
                break;
            case '6':
                card4Value = 6;
                break;
            case '7':
                card4Value = 7;
                break;
            case '8':
                card4Value = 8;
                break;
            case '9':
                card4Value = 9;
                break;
            case 'T':
                card4Value = 10;
                break;
            case 'J':
                card4Value = 11;
                break;
            case 'Q':
                card4Value = 12;
                break;
            case 'K':
                card4Value = 13;
                break;
            default:
                card4Value = 14;
                break;
        }
        if (buttonNum == 1)
        {
            if (deck[3][1] == 'H')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card4Value + " times" + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
        }
        else if (buttonNum == 2)
        {
            if (deck[3][1] == 'D')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card4Value + " times." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
        }
        else if (buttonNum == 3)
        {
            if (deck[3][1] == 'C')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card4Value + " times." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
        }
        else if (buttonNum == 4)
        {
            if (deck[3][1] == 'S')
            {
                dialogueText.GetComponent<Text>().text = "Correct! You don't have to drink." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
            else
            {
                dialogueText.GetComponent<Text>().text = "You are wrong. Drink " + card4Value + " times." + Environment.NewLine + Environment.NewLine + "You are done with the game.";
            }
        }

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
    }

    public void OnInGameSettingsButton()
    {
        sceneChanger.SceneLoad("MainMenu");
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;
    public List<string> restOfDeck;

    // Start is called before the first frame update
    void Start()
    {
        startPlaying();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPlaying()
    {
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
            //newCard.tag = "Player1Card" + i.ToString();
            newCard.GetComponent<Seeable>().faceUp = true;

            xOffset = xOffset + 250;
        }
        for(int i = 4; i < 52; i++)
        {
            restOfDeck.Add(deck[i]);
        }
    }
}

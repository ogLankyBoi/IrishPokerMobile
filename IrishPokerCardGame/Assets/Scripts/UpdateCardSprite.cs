﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCardSprite : MonoBehaviour
{

    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Local2PHandlerScr gameHandler2;
    private Seeable seeable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck2 = Local2PHandlerScr.GenerateDeck();
        gameHandler2 = FindObjectOfType<Local2PHandlerScr>();

        int i = 0;
        foreach (string card in deck2)
        {
            if (this.name == card)
            {
                cardFace = gameHandler2.cardFaces[i];
                break;
            }
            i++;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        seeable = GetComponent<Seeable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seeable.faceUp == false)
        {
            spriteRenderer.sprite = cardBack;
        }
        else if (seeable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
    }
}

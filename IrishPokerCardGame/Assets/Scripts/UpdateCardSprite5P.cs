using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCardSprite5P : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Local5PHandlerScr gameHandler5;
    private Seeable seeable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck5 = Local5PHandlerScr.GenerateDeck();
        gameHandler5 = FindObjectOfType<Local5PHandlerScr>();

        int i = 0;
        foreach (string card in deck5)
        {
            if (this.name == card)
            {
                cardFace = gameHandler5.cardFaces[i];
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCardSprite6P : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Local6PHandlerScr gameHandler6;
    private Seeable seeable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck6 = Local6PHandlerScr.GenerateDeck();
        gameHandler6 = FindObjectOfType<Local6PHandlerScr>();

        int i = 0;
        foreach (string card in deck6)
        {
            if (this.name == card)
            {
                cardFace = gameHandler6.cardFaces[i];
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

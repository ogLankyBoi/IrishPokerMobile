using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCardSprite4P : MonoBehaviour
{

    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Local4PHandlerScr gameHandler4;
    private Seeable seeable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck4 = Local4PHandlerScr.GenerateDeck();
        gameHandler4 = FindObjectOfType<Local4PHandlerScr>();

        int i = 0;
        foreach (string card in deck4)
        {
            if (this.name == card)
            {
                cardFace = gameHandler4.cardFaces[i];
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

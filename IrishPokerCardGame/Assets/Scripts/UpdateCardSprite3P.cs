using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCardSprite3P : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Local3PHandlerScr gameHandler3;
    private Seeable seeable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck3 = Local3PHandlerScr.GenerateDeck();
        gameHandler3 = FindObjectOfType<Local3PHandlerScr>();

        int i = 0;
        foreach (string card in deck3)
        {
            if (this.name == card)
            {
                cardFace = gameHandler3.cardFaces[i];
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

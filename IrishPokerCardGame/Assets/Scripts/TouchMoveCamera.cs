using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCamera : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Move camera by dragging finger 
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPos.x * speed, -touchDeltaPos.y * speed, 0);

            // Keep camera from going off the Table Top
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -17.0f, 17.0f),
                Mathf.Clamp(transform.position.y, -11.0f, 11.0f),
                -1.0f
            );
        }
    }
}

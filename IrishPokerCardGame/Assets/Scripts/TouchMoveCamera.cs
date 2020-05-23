using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCamera : MonoBehaviour
{
    public float panSpeed, zoomSpeed, zoomOutMin, zoomOutMax;
    Vector3 touchStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For mouse and touch
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -17.0f, 17.0f),
                Mathf.Clamp(transform.position.y, -11.0f, 11.0f),
                -1.0f
            );
        }
/*
        // Specfically for touch
        if(Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Move camera by dragging finger 
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPos.x * panSpeed, -touchDeltaPos.y * panSpeed, 0);

            // Keep camera from going off the Table Top
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -17.0f, 17.0f),
                Mathf.Clamp(transform.position.y, -11.0f, 11.0f),
                -1.0f
            );
        }
*/
        // Pinch to zoom
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 prevFirstTouchPos = firstTouch.position - firstTouch.deltaPosition;
            Vector2 prevSecondTouchPos = secondTouch.position - secondTouch.deltaPosition;

            float prevMagnitude = (prevFirstTouchPos - prevSecondTouchPos).magnitude;
            float currMagnitude = (firstTouch.position - secondTouch.position).magnitude;

            float difference = currMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
        }
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCardPosition : MonoBehaviour
{
    public Vector3 cardPos;

    // Start is called before the first frame update
    void Start()
    {
        cardPos = transform.position;
    }

    // Update is called once per frame

}

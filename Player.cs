using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // setting player boundaries

        if (transform.position.y >= 2.25){ // Y Upper Boundary
            transform.position = new Vector3(transform.position.x, 2.25f, 0);
        }
        if (transform.position.y <= -2.05){ // Y Lower Boundary
            transform.position = new Vector3(transform.position.x, -2.05f, 0);
        }
        if (transform.position.x >= 1.90){ // X Right Boundary
            transform.position = new Vector3(1.90f, transform.position.y, 0);
        }
        if (transform.position.x <= -1.85){ // X Left Boundary
            transform.position = new Vector3(-1.85f, transform.position.y, 0);
        }
    }
}

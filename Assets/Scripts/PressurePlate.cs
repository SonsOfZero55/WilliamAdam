using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Vector3 intitalPos;
    bool moveOnBack = false;

    // Start is called before the first frame update
    private void Start()
    {
        intitalPos = transform.position;
    }

    // Update is called once per frame
    private void OnCollisonStay2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            transform.Translate(0, -0.0f, 0);
            moveOnBack = false;
        }
    }

    private void OnCollisonEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.parent = transform;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnCollisonExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            moveOnBack = true;
            collision.transform.parent = null;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void Update()
    {
       if (moveOnBack)
        {
            if (transform.position.y < intitalPos.y)
            {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                moveOnBack = false;
            }
        }
    }
}

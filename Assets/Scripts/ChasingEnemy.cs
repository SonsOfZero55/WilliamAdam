using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public int speed = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //This code allows the enemys to move towards the player no matter where they are in the playable area
        //rb.MovePosition
        transform.position = Vector2.MoveTowards(transform.position, 
        Player.transform.position, speed * Time.deltaTime);

        //gameObject.transform.position = new Vector3(Player.transform.position.x, 
        //Player.transform.position.y, Player.transform.position.z);
    }
}

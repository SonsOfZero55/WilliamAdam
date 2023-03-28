using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTest : MonoBehaviour
{

    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        if (Detected)
        {
            gameObject.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position,
        transform.rotation);

        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}

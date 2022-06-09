using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator anim;
    public BoxCollider2D BoxCollider2D;
    public CircleCollider2D CircleCollider2D;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;

    public LayerMask layer;
    public float speed;

    private bool colliding;
    bool playerDestroyed = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast (rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;

            if (height >0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");

                BoxCollider2D.enabled = false;
                CircleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                
                Destroy(gameObject, 0.33f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }
}
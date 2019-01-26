using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public float speed = 30;

    public Sprite explodedShipImage;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlayOneShot
                (SoundManager.Instance.shipExplosion);
            collision.GetComponent<SpriteRenderer>().sprite =
                explodedShipImage;

            Destroy(gameObject);

            //DestroyObject(collision.gameObject, 0.5f);
            Object.Destroy(gameObject, 0.5f);
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
            //DestroyObject(collision.gameObject);
            Object.Destroy(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] AudioClip shootBulletSFX; 
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D bulletRigidBody;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        AudioSource.PlayClipAtPoint(shootBulletSFX, Camera.main.transform.position, 0.2f);
        player = FindObjectOfType<PlayerMovement>();
        bulletRigidBody = GetComponent<Rigidbody2D>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        bulletRigidBody.velocity = new Vector2 (xSpeed,0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}

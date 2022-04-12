using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceWarPlayer : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject playerBullet;
    public Image playerHealthBar;
    public SpaceWarAdmin admin;
    public AudioSource laser;    

    float health = 100f;
    float currentHealth = 100f;
    float shipSpeed = 25f;
    float bulletSpeed = 650f;

    private void Start()
    {
        admin.stop();
    }

    void fireBullet()
    {
        GameObject newBullet = Instantiate(playerBullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bulletSpeed);
        laser.Play();
        Destroy(newBullet, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy_bullet")
        {
            Destroy(collision.gameObject);
            healthDown(10f);
            if (currentHealth <= 0)
            {
                explode();
            }
        }
    }

    void explode()
    {
        Destroy(gameObject);
        GameObject newExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(newExplosion, 1f);
        admin.showPanel2();
    }

    void healthDown(float value)
    {
        currentHealth -= value;
        playerHealthBar.fillAmount = currentHealth / health;
    }

    void Update()
    {
        float keyDetect = Input.GetAxis("Horizontal");
        transform.Translate(keyDetect * Time.deltaTime*shipSpeed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBullet();
        }
    }
}

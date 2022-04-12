using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceWarEnemy : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject enemyBullet;
    public Image enemyHealthBar;
    public SpaceWarAdmin admin;
    public Transform playerShip;
    public AudioSource laser;
    public GameObject sound;

    float health = 100f;
    float currentHealth = 100f;
    float shipSpeed = 8f;
    float bulletSpeed = 650f;

    float fireRange=0.3f;
    float fireTime = 0f;

    private void Start()
    {
        admin.stop();
    }

    void fireBullet()
    {
        GameObject newBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletSpeed);
        laser.Play();
        Destroy(newBullet, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player_bullet")
        {
            Destroy(collision.gameObject);
            healthDown(5f);
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
        admin.showPanel();
    }

    void healthDown(float value)
    {
        currentHealth -= value;
        enemyHealthBar.fillAmount = currentHealth / health;
    }

    void Update()
    {
        if (playerShip) {
            if (transform.position.x < playerShip.position.x)
            {
                transform.Translate(-shipSpeed * Time.deltaTime, 0, 0);
            } 

            if (transform.position.x > playerShip.position.x)
            {
                transform.Translate(shipSpeed * Time.deltaTime, 0, 0);
            }

            if (playerShip.position.x - transform.position.x < 0.2f) {
                if (Time.time >= fireTime)
                {
                    fireBullet();
                    sound.SetActive(true);
                    fireTime = Time.time + fireRange;
                }
            }
        }
    }
}
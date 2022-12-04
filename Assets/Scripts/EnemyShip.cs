using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int health = 100;
    public GameObject bullet;

    SpriteRenderer spriteRenderer;

    private float halfWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;
        SpaceShipBullet bulletScript = otherObject.GetComponent<SpaceShipBullet>();
        if(bulletScript != null)
        {
            health -= bulletScript.damage;
            Destroy(otherObject);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void EnemyShipShoot()
    {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public MoveDirections direction;
    public SpriteRenderer shipRenderer;
    private float speed = 0.1f;
    private float health = 10;
    
    private float halfSide = 0.0f;
    void Start()
    {
        halfSide = shipRenderer.sprite.bounds.size.y / 2;
    }

    public void FixedUpdate()
    {
        switch(direction)
        {
            case MoveDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                
                Vector3 checkPosition = new Vector3(transform.position.x + speed + halfSide, transform.position.y, 0);
                bool isOnScreen = ScreenUtils.IsPositionOnScreen(checkPosition);
                if(isOnScreen == true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    if (transform.position.y > 0) 
                    {
                        direction = MoveDirections.down;
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else
                    {
                        direction = MoveDirections.up;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                break;
            case MoveDirections.left:
                newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
                checkPosition = new Vector3(transform.position.x - speed - halfSide, transform.position.y, 0);
                    isOnScreen = ScreenUtils.IsPositionOnScreen(checkPosition);
                    if(isOnScreen == true)
                    {
                        transform.position = newPosition;
                    }
                    else
                    {
                        if (transform.position.y > 0) 
                        {
                            direction = MoveDirections.down;
                            transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                        else
                        {
                            direction = MoveDirections.up;
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                        }
                    }
                break;
            case MoveDirections.up:
                newPosition = new Vector3(transform.position.x, transform.position.y + speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y + speed + halfSide, 0);
                isOnScreen = ScreenUtils.IsPositionOnScreen(checkPosition);
                    if(isOnScreen == true)
                    {
                        transform.position = newPosition;
                    }
                    else
                    {
                        if (transform.position.x > 0) 
                        {
                            direction = MoveDirections.left;
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        else
                        {
                            direction = MoveDirections.right;
                            transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                    }
                break;
            case MoveDirections.down:
                newPosition = new Vector3(transform.position.x, transform.position.y - speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y - speed - halfSide, 0);
                isOnScreen = ScreenUtils.IsPositionOnScreen(checkPosition);
                    if(isOnScreen == true)
                    {
                        transform.position = newPosition;
                    }
                    else
                    {
                        if (transform.position.x > 0) 
                        {
                            direction = MoveDirections.left;
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        else
                        {
                            direction = MoveDirections.right;
                            transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                    }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
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
}

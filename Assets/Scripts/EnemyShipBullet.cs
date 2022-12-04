using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBullet : MonoBehaviour
{
     public SpriteRenderer bulletRenderer;

    public int damage = 20;
    
    float bulletSpeed = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        // bool isKeyDownShot = Input.GetKey(KeyCode.Space);
        // if(isKeyDownShot == true)
        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y - bulletSpeed, 
            transform.position.z
        );
        if(ScreenUtils.IsPositionOnScreen(transform.position) == false)
        {
            Destroy(gameObject);
        }

    }
}

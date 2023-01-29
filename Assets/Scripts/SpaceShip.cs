using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer spriteRenderer;

    private float speed = 0.1f;

    public int health = 100;

    void Start()
    {

    }

    void Update()
    {
        float halfWidth = spriteRenderer.bounds.size.x / 2;
        float halfHeight = spriteRenderer.bounds.size.y / 2;
        bool isKeyDownL = Input.GetKey(KeyCode.LeftArrow);
        if(isKeyDownL == true)
        {
            Vector3 newPositionL = new Vector3(transform.position.x - speed, transform.position.y, 0);
            Vector3 checkPositionL = new Vector3(newPositionL.x-halfWidth, newPositionL.y, 0);
            if(ScreenUtils.IsPositionOnScreen(checkPositionL) == true)
            {
                transform.position = newPositionL;
            }
            
        }

        bool isKeyDownR = Input.GetKey(KeyCode.RightArrow);
        if(isKeyDownR == true)
        {
            Vector3 newPositionR = new Vector3(transform.position.x + speed, transform.position.y, 0);
            Vector3 checkPositionR = new Vector3(newPositionR.x+halfWidth, newPositionR.y, 0);
            if(ScreenUtils.IsPositionOnScreen(checkPositionR) == true)
            {
                transform.position = newPositionR;
            }
        }

        bool isKeyDownU = Input.GetKey(KeyCode.UpArrow);
        if(isKeyDownU == true)
        {
            Vector3 newPositionR = new Vector3(transform.position.x, transform.position.y + speed, 0);
            Vector3 checkPositionR = new Vector3(newPositionR.x, newPositionR.y + halfHeight, 0);
            if(ScreenUtils.IsPositionOnScreen(checkPositionR) == true)
            {
                transform.position = newPositionR;
            }
        }

        bool isKeyDownD = Input.GetKey(KeyCode.DownArrow);
        if(isKeyDownD == true)
        {
            Vector3 newPositionR = new Vector3(transform.position.x, transform.position.y - speed, 0);
            Vector3 checkPositionR = new Vector3(newPositionR.x, newPositionR.y - halfHeight, 0);
            if(ScreenUtils.IsPositionOnScreen(checkPositionR) == true)
            {
                transform.position = newPositionR;
            }
        }
        
        bool isShot = Input.GetKeyUp(KeyCode.Space);
        if(isShot == true)
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = transform.position;
        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        EnemyShipBullet bulletScript = otherObject.GetComponent<EnemyShipBullet>();
        if(bulletScript != null)
        {
            health -= bulletScript.damage;
            Destroy(otherObject);
            if(health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneIDs.LoseSceneID);
                Destroy(gameObject);   
            }
        }
        else
        {
            RamShip shipScript = otherObject.GetComponent<RamShip>();
            if(shipScript != null)
            {
                Destroy(otherObject);
                SceneManager.LoadSceneAsync(SceneIDs.LoseSceneID);
                Destroy(gameObject);
            }
        }
    }
}

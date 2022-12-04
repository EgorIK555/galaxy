using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyGroup : BaseEnemyGroup
{
    public EnemyShip EnemyShip1;
    public EnemyShip EnemyShip2;
    public EnemyShip EnemyUfo;

    private int direction = -1;
    private float speed = 0.1f;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private System.Random generator = new System.Random();

    
    void Start()
    {
        ships.Add(EnemyShip1);
        ships.Add(EnemyShip2);
        ships.Add(EnemyUfo);

        InvokeRepeating("GroupShoot", 0.0f, 1.0f );
    }

    // Update is called once per frame
    void Update()
    {   ships.RemoveAll(item => item == null);
        if(EnemyShip1 == null && EnemyShip2 == null && EnemyUfo == null)
        {
          isDestroyed = true;
          CancelInvoke("GroupShoot");
        }
        
        if(direction == -1)
        {
          float minX = GetLeftEdge();
          minX += speed * direction;
          if(minX <= -6.4)
          {
            direction *= -1;
          }
          else
          {
            transform.position = new Vector3(
              transform.position.x - speed,
              transform.position.y,
              0
            );
          }
        }
        else
          {
            float maxX = GetRightEdge();
            maxX += speed * direction;
            if(maxX >= 6.4)
            {
              direction *= -1;
            }
            else
            {
              transform.position = new Vector3(
                transform.position.x + speed,
                transform.position.y,
                0
              );
            }
            Vector3 objectPos = transform.position;
          }

    }

    float GetLeftEdge()
    {
      float minX = float.MaxValue;
      for(int i = 0; i < ships.Count; i++)
      {
        if(ships[i].transform.position.x < minX)
        {
          minX = ships[i].transform.position.x;
        }
      }

      return minX;
    }

    float GetRightEdge()
    {
      float maxX = float.MinValue;
      for(int i = 0; i < ships.Count; i++)
      {
        if(ships[i].transform.position.x > maxX)
        {
          maxX = ships[i].transform.position.x;
        }
      }

      return maxX;
    }

    void GroupShoot()
    {
        int shipId = generator.Next(0, ships.Count-1);
        ships[shipId].EnemyShipShoot();
    }
}
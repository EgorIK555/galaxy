using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public MoveDirections direction;
    private float speed = 0.1f;
    void Start()
    {
        
    }

    public void FixedUpdate()
    {
        switch(direction)
        {
            case MoveDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                bool isOnScreen = ScreenUtils.IsPositionOnScreen(newPosition);
                if(isOnScreen == true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    direction = MoveDirections.down;
                }
                break;
            case MoveDirections.left:
                break;
            case MoveDirections.up:
                break;
            case MoveDirections.down:
                break;
        }
    }
}

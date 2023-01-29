using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemyGroup : BaseEnemyGroup
{
    public RamShip ship1;
    public RamShip ship2;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (ship1 == null && ship2 == null) {
            isDestroyed = true;
        }
    }
}

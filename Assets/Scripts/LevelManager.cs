using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    FirstEnemyGroup activeGroup;
    int groupCount;

    void Start()
    {
        GroupSpawner();
        groupCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeGroup.isDestroyed == true)
        {
            Destroy(activeGroup.gameObject);

            if(groupCount == 3)
            {
                SceneManager.LoadSceneAsync(1);
            }
            else
            {
              GroupSpawner();
              groupCount++;  
            }
            
        }
    }

    void GroupSpawner()
    {
        GameObject newGroup = Instantiate(firstGroupOriginal);
        newGroup.transform.position = transform.position;
        activeGroup = newGroup.GetComponent<FirstEnemyGroup>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    public GameObject ramGroupOriginal;
    private BaseEnemyGroup activeGroup;
    private int groupCount = 0;
    private EnemyGroupType [] groupTypes = {
    EnemyGroupType.BaseGroup, 
    EnemyGroupType.BaseGroup,
    EnemyGroupType.RamGroup
    };

    void Start()
    {
        GroupSpawner();
        groupCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeGroup.isDestroyed == true && activeGroup != null)
        {
            Destroy(activeGroup.gameObject);

            if(groupCount == groupTypes.Length)
            {
                SceneManager.LoadSceneAsync(SceneIDs.WinSceneID);
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
        if(groupTypes[groupCount] == EnemyGroupType.BaseGroup)
        {
            GameObject newGroup = Instantiate(firstGroupOriginal);
            newGroup.transform.position = transform.position;
            activeGroup = newGroup.GetComponent<FirstEnemyGroup>();            
        }
        else if(groupTypes[groupCount] == EnemyGroupType.RamGroup)
        {
            GameObject newGroup = Instantiate(ramGroupOriginal);
            newGroup.transform.position = transform.position;
            activeGroup = newGroup.GetComponent<RamEnemyGroup>();
        }
        
    }
}

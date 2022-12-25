using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartLevel1()
    {
        SceneManager.LoadSceneAsync(SceneIDs.levelSceneID);
    }
}

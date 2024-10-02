using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour
{

    public ScenePushPop _scenePushPop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Debug.Log("êÌì¨èCóπ");
            SceneManager.UnloadSceneAsync("BattleScene");
            _scenePushPop.pop();
            _scenePushPop.setObjectActive(true);
        }
    }
}

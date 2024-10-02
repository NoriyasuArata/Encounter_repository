using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSubScene : MonoBehaviour
{



    [SerializeField] private string _stopScene;
    [SerializeField] public string _subScene;
    [SerializeField] public string _gameObjectName;
    public bool loaded_;


    // Start is called before the first frame update
    void Start()
    {
        loaded_ = false;
    }


    public IEnumerator load()
    {
        loaded_ = false;
        SceneManager.sceneLoaded += GameSceneLoaded;
        yield return SceneManager.LoadSceneAsync(_subScene, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {

        Debug.Log("シーンロード完了");
        loaded_ = true;
//        GameData gane_data = GameObject.FindWithTag("GameDataManager").GetComponent<GameData>();
//        Debug.Log(gane_data);
        SceneManager.sceneLoaded -= GameSceneLoaded;

        ScenePushPop sc_push_pop = gameObject.GetComponent<ScenePushPop>();
        sc_push_pop.push();
        sc_push_pop.setObjectActive(false);


        foreach (GameObject obj in next.GetRootGameObjects())
        {
            Debug.Log(obj.name);
            Debug.Log(_gameObjectName);
            if (obj.name == _gameObjectName)
            {
                BattleScript script = obj.GetComponent<BattleScript>();
                Debug.Log(script);
                Debug.Log("バトルスクリプトがあったよ");
                script._scenePushPop = sc_push_pop;
                break;
            }
        }
        SceneManager.SetActiveScene(next);
    }
}

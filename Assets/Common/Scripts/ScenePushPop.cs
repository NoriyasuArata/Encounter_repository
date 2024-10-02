using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

class ScenePushPopData
{
    public string _tagNamne;
    public bool _active;
}



public class ScenePushPop : MonoBehaviour
{
    [SerializeField] private string _sceneName;


    private Stack<ScenePushPopData[]> _pushPoper;



    public void push()
    {
        UnityEngine.SceneManagement.Scene sc = SceneManager.GetSceneByName(_sceneName);

        if (sc.isLoaded)
        {
            Debug.Log(sc.name);
            ScenePushPopData[] data_pool = new ScenePushPopData[sc.GetRootGameObjects().Length];

            int i = 0;
            foreach (GameObject obj in sc.GetRootGameObjects())
            {
                ScenePushPopData data = new ScenePushPopData();
                data._tagNamne = obj.name;
                data._active = obj.activeSelf;
                data_pool[i] = data;
                ++i;
            }
            _pushPoper.Push(data_pool);
        }
    }

    public void pop()
    {
        UnityEngine.SceneManagement.Scene sc = SceneManager.GetSceneByName(_sceneName);
        Debug.Log(_sceneName);
        Debug.Log(sc);
        ScenePushPopData[] data_pool = _pushPoper.Peek();

        foreach (ScenePushPopData data in data_pool)
        {
            foreach (GameObject obj in sc.GetRootGameObjects())
            {
                if (obj.name == data._tagNamne)
                {
                    obj.SetActive(data._active);
                    break;
                }
            }

        }
        _pushPoper.Pop();
        SceneManager.SetActiveScene(sc);
        Debug.Log("シーンアクティブ");
        Debug.Log(sc.name);
    }


    public void setObjectActive(bool active)
    {
        UnityEngine.SceneManagement.Scene sc = SceneManager.GetSceneByName(_sceneName);
        foreach (GameObject obj in sc.GetRootGameObjects())
        {
            obj.SetActive(active);
        }
    }



    // Start is called before the first frame update
    void Awake()
    {
        _pushPoper = new Stack<ScenePushPopData[]>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

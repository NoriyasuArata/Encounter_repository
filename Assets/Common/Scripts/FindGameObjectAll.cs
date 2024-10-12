using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindGameObjectAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject findGmaeObjectAll(string name)
    {
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();


        GameObject[] rootObjects = scene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            GameObject found = findInChildren(obj, name);
            if (found != null)
                return found;
        }

        return null; // 見つからなかった場合
    }

    private GameObject findInChildren(GameObject parent, string name)
    {
        // オブジェクトが見つかった場合は返す
        if (parent.name == name)
            return parent;

        // 子オブジェクトを再帰的に調べる
        foreach (Transform child in parent.transform)
        {
            GameObject found = findInChildren(child.gameObject, name);
            if (found != null)
                return found;
        }

        return null;
    }


}

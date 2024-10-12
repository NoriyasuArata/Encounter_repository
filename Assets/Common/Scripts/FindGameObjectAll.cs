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

        return null; // ������Ȃ������ꍇ
    }

    private GameObject findInChildren(GameObject parent, string name)
    {
        // �I�u�W�F�N�g�����������ꍇ�͕Ԃ�
        if (parent.name == name)
            return parent;

        // �q�I�u�W�F�N�g���ċA�I�ɒ��ׂ�
        foreach (Transform child in parent.transform)
        {
            GameObject found = findInChildren(child.gameObject, name);
            if (found != null)
                return found;
        }

        return null;
    }


}

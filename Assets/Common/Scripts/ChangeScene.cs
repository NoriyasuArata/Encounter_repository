using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] public string _changeSceneName;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_changeSceneName);
        
    }

    /// <summary>
    /// ÉçÅ[Éh
    /// </summary>
    public void load()
    {
        SceneManager.LoadScene(_changeSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

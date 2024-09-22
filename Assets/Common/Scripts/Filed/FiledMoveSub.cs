using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledMoveSub : MonoBehaviour
{


    [SerializeField]
    public float _mainCharDistance;

    [SerializeField]
    public float _subcharSpeed;

    private GameObject _actorMain;

    // Start is called before the first frame update
    void Start()
    {
        _actorMain = GameObject.Find("ActorMain");
        Debug.Log(_actorMain);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = _actorMain.transform.position;
        var subpos = transform.position;
        var vec = pos - subpos;
        var distance = Vector3.Distance(pos, subpos);

        if (distance >= _mainCharDistance)
        {
            var n = vec.normalized;
            subpos = subpos + n * _subcharSpeed * Time.deltaTime;
            transform.position = subpos;
        }
    }
}

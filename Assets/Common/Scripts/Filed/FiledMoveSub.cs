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
    private FiledMove _filedMove;

    // Start is called before the first frame update
    void Start()
    {
        _actorMain = GameObject.Find("ActorMain");
        _filedMove = _actorMain.GetComponent<FiledMove>();
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
            var value = _subcharSpeed;
            if (_filedMove.RunFiled)
            {
                value *= 1.5f;
            }
            subpos = subpos + n * value * Time.deltaTime;
            transform.position = subpos;
        }
    }
}

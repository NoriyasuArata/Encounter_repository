using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class FiledMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController _gameController;
    private bool _runFiled;

    [SerializeField] public GameController Controller
    {
        get => _gameController;
        set => _gameController = value;
    }


    public bool RunFiled
    { get => _runFiled; }

    void Start()
    {
        _gameController = GetComponent<GameController>();
        _runFiled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vec = _gameController.getAxis();
        var value = 2.0f;
        var pos = transform.position;


        _runFiled = _gameController.runFiled();
        if (_runFiled)
        {
            value *= 1.5f;
        }

        pos.x = pos.x + vec.x * value * Time.deltaTime;
        pos.y = pos.y + vec.y * value * Time.deltaTime;
        transform.position = pos;
    }


}

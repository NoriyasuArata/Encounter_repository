using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FiledMove : MonoBehaviour
{
    // Start is called before the first frame update

    private GameController _gameController;
    void Start()
    {
        _gameController = GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vec = _gameController.getAxis();
        var value = 2.0f;
        var pos = transform.position;

        pos.x = pos.x + vec.x * value * Time.deltaTime;
        pos.y = pos.y + vec.y * value * Time.deltaTime;
        transform.position = pos;
    }


}

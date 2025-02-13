using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class FiledMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _commandAction;
    [SerializeField] private InputActionReference _runAction;
    [SerializeField] private InputActionReference _menuAction;

    [SerializeField] public float _walk_speed;
    [SerializeField] public float _run_speed;



    private bool _runFiled; //  フィールド走るフラグ
    private bool _runFiledCommand;  //  フィールドコマンド


    public bool isFiledCommand { get => _runFiledCommand; }



    private Vector2 _moveVector;
    public bool RunFiled
    { get => _runFiled; }


    private void Awake()
    {
        // 入力値が0以外の値に変化したときに呼び出されるコールバック
        _moveAction.action.performed += OnMove;
        _commandAction.action.started += OnCommandAction;
        _runAction.action.started += OnRunAction;
        _menuAction.action.started += OnMenuAction;


        // 入力値が0に戻ったときに呼び出されるコールバック
        _moveAction.action.canceled += OnMove;
        _commandAction.action.canceled += OnCommandAction;
        _runAction.action.canceled += OnRunAction;
        _menuAction.action.canceled += OnMenuAction;

        _runFiled = false;
        _runFiledCommand = false;
        _moveVector = Vector2.zero;

        _walk_speed = 2.0f;
        _run_speed = 2.0f * 1.5f;

    }




    // InputActionの有効化・無効化
    private void OnEnable()
    {
        _moveAction.action.Enable();
        _commandAction.action.Enable();
        _runAction.action.Enable();
        _menuAction.action.Enable();
    }



    private void OnDisable()
    {
        _moveAction.action.Disable();
        _commandAction.action.Disable();
        _runAction.action.Disable();
        _menuAction.action.Disable();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBattle() == false && isFiledCommand == false )
        {
            //  移動
            var vec = _moveVector;
            var value = _walk_speed;
            var pos = transform.position;


            //_runFiled = _gameController.runFiled();
            if (_runFiled)
            {
                value = _run_speed;
            }

            pos.x = pos.x + vec.x * value * Time.deltaTime;
            pos.y = pos.y + vec.y * value * Time.deltaTime;
            transform.position = pos;
        }
    }
    private void Update()
    {
        BattleStart bs = gameObject.GetComponent<BattleStart>();
        if (bs && bs._startBattle == false)
        {
            Destroy(bs);
        }

    }
    

    public bool isBattle()
    {
        BattleStart bs = gameObject.GetComponent<BattleStart>();
        if (bs)
        {
            return bs._startBattle;
        }
        return false;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (isBattle() || context.canceled)
        {
            _moveVector = Vector2.zero;

        }
        else
        {
            _moveVector = context.ReadValue<Vector2>();
            float len = _moveVector.sqrMagnitude;
            if (len > 1.0f)
            {
                _moveVector = _moveVector.normalized;
            }
        }
    }



    public void OnCommandAction(InputAction.CallbackContext context)
    {
        bool command = context.ReadValueAsButton();

        BattleStart bs = gameObject.GetComponent<BattleStart>();

        if (command && (bs == null || bs._startBattle == false))
        {
            Debug.Log(bs);
            if (bs)
            {
                bs._startBattle = true;
            }
            else
            {
                bs = gameObject.AddComponent<BattleStart>();
                bs._startBattle = true;
            }
            bs.startBattle();
            Debug.Log("コマンドの実行");
        }
    }


    public void OnRunAction(InputAction.CallbackContext context)
    {
        if (isBattle()) return;
        _runFiled = context.ReadValueAsButton();
    }

    public void OnMenuAction(InputAction.CallbackContext context)
    {
        if (isBattle()) return;
        bool menuOpen = context.ReadValueAsButton();
        if (menuOpen)
        {
            FindGameObjectAll find_unit = gameObject.GetComponent<FindGameObjectAll>();
            Debug.Log(find_unit);
            GameObject field_cmnd = find_unit.findGmaeObjectAll("FiledCmdCamera");
            Debug.Log(field_cmnd);

            if (_runFiledCommand == false)
            {
                //  メニューオープン
                Debug.Log("メニューオープン");
                _runFiledCommand = true;
                field_cmnd.SetActive(true);
            }
            else
            {
                Debug.Log("メニュークローズ");
                _runFiledCommand = false;
                field_cmnd.SetActive(false);
            }
        }
    }
}

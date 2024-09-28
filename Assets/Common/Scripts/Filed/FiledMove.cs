using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
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



    private bool _runFiled;




    private Vector2 _moveVector;
    public bool RunFiled
    { get => _runFiled; }


    private void Awake()
    {
        // ���͒l��0�ȊO�̒l�ɕω������Ƃ��ɌĂяo�����R�[���o�b�N
        _moveAction.action.performed += OnMove;
        _commandAction.action.started += OnCommandAction;
        _runAction.action.started += OnRunAction;
        _menuAction.action.started += OnMenuAction;


        // ���͒l��0�ɖ߂����Ƃ��ɌĂяo�����R�[���o�b�N
        _moveAction.action.canceled += OnMove;
        _commandAction.action.canceled += OnCommandAction;
        _runAction.action.canceled += OnRunAction;
        _menuAction.action.canceled += OnMenuAction;

        _runFiled = false;
        _moveVector = Vector2.zero;
    }




    // InputAction�̗L�����E������
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


        //  �ړ�
        var vec = _moveVector;
        var value = 2.0f;
        var pos = transform.position;


        //_runFiled = _gameController.runFiled();
        if (_runFiled)
        {
            value *= 1.5f;
        }

        pos.x = pos.x + vec.x * value * Time.deltaTime;
        pos.y = pos.y + vec.y * value * Time.deltaTime;
        transform.position = pos;



    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveVector = context.ReadValue<Vector2>().normalized;
    }


    public void OnCommandAction(InputAction.CallbackContext context)
    {
        bool command = context.ReadValueAsButton();

        if (command)
        {
            //  �R�}���h�̎��s
            Debug.Log("�R�}���h�̎��s");
        }
    }


    public void OnRunAction(InputAction.CallbackContext context)
    {
        _runFiled = context.ReadValueAsButton();
    }

    public void OnMenuAction(InputAction.CallbackContext context)
    {
        bool menuOpen = context.ReadValueAsButton();
        if (menuOpen)
        {
            //  ���j���[�I�[�v��
            Debug.Log("���j���[�I�[�v��");
        }
    }
}

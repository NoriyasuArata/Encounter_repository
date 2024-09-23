using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{


    [SerializeField] private InputCtrlActions _inputCtrlActions;


    void Start()
    {

        _inputCtrlActions = new InputCtrlActions();



    }


    /// <summary>
    /// �A�i���O�X�e�B�b�N�i�A�i���O���́j
    /// </summary>
    /// <returns>�m�[�}���C�Y���ꂽ�x�N�g��</returns>
    public Vector2 getAxis()
    {
        Vector2 rs = new Vector2();
        string h_str = "Horizontal";
        string v_str = "Vertical";
        rs.x = Input.GetAxis(h_str);
        rs.y = Input.GetAxis(v_str);
        rs = rs.normalized;
        return rs;
    }

    /// <summary>
    /// �A�i���O�X�e�B�b�N�i�\���L�[���������F-1,0,1�̐��l���K������
    /// </summary>
    /// <returns></returns>
    public Vector2 getAxisRaw()
    {
        Vector2 rs = new Vector2();
        string h_str = "Horizontal";
        string v_str = "Vertical";
        rs.x = Input.GetAxisRaw(h_str);
        rs.y = Input.GetAxisRaw(v_str);


        //  �S�~�f�[�^���o��̂ŕ␳
        if (rs.x <= -1)
        {
            rs.x = -1;
        }
        else if (rs.x >= 1)
        {
            rs.x = 1;
        }
        else
        {
            rs.x = 0;
        }

        if (rs.y <= -1)
        {
            rs.y = -1;
        }
        else if (rs.y >= 1)
        {
            rs.y = 1;
        }
        else
        {
            rs.y = 0;
        }
        return rs;
    }



    //  �R���g���[���[ID
    public enum MOVE_DIR
    {
        None = 0,   //  ���͖���
        U,          //  ��
        UL,         //  ����
        L,          //  ��
        DL,         //  ����
        D,          //  ��
        DR,         //  �E��
        R,          //  �E
        UR,         //  �E��
    };



    // Update is called once per frame
    void Update()
    {


    }
}

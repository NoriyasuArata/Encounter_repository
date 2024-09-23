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
    /// アナログスティック（アナログ入力）
    /// </summary>
    /// <returns>ノーマライズされたベクトル</returns>
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
    /// アナログスティック（十字キー扱い処理：-1,0,1の数値が必ず入る
    /// </summary>
    /// <returns></returns>
    public Vector2 getAxisRaw()
    {
        Vector2 rs = new Vector2();
        string h_str = "Horizontal";
        string v_str = "Vertical";
        rs.x = Input.GetAxisRaw(h_str);
        rs.y = Input.GetAxisRaw(v_str);


        //  ゴミデータが出るので補正
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



    //  コントローラーID
    public enum MOVE_DIR
    {
        None = 0,   //  入力無し
        U,          //  上
        UL,         //  左上
        L,          //  左
        DL,         //  左下
        D,          //  下
        DR,         //  右下
        R,          //  右
        UR,         //  右上
    };



    // Update is called once per frame
    void Update()
    {


    }
}

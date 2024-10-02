using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    public bool _startBattle;

    private IEnumerator _enumerator;
    // Start is called before the first frame update
    void Start()
    {

        _enumerator = this.OnBattle();
        this.StartCoroutine(_enumerator);
    }


    private void OnDestroy()
    {
        (_enumerator as IDisposable)?.Dispose();
        if (_enumerator != null)
        {
            this.StopCoroutine(_enumerator);
            this._startBattle = false;
        }
        Debug.Log("修了");
    }

    private IEnumerator OnBattle()
    {
        if (_startBattle)
        {
            //  戦闘開始の表示
            GameObject obj = GameObject.Find("Battle");

            var renderer = obj.GetComponent<SpriteRenderer>();
            renderer.enabled = true;

            yield return new WaitForSeconds(2.0f);

            //  表示をオフ
            renderer.enabled=false;
            _startBattle = false;

            //  戦闘
            GameObject main_cam = GameObject.Find("Main Camera");
            Debug.Log(main_cam);
            //  バトルシーンの呼び出し

            ChangeSubScene csBattle = obj.GetComponent<ChangeSubScene>();

            Debug.Log(csBattle);
            Debug.Log(csBattle._subScene);
            yield return StartCoroutine(csBattle.load());
            Debug.Log("戦闘修了");
            //  戦闘修了
        }
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

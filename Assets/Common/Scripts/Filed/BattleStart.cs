using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
            
            //  戦闘

            //  バトルシーンの呼び出し





            //  戦闘修了
            _startBattle = false;
        }
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

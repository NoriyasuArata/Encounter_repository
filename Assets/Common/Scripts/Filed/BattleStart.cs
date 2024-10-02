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
        Debug.Log("�C��");
    }

    private IEnumerator OnBattle()
    {
        if (_startBattle)
        {
            //  �퓬�J�n�̕\��
            GameObject obj = GameObject.Find("Battle");

            var renderer = obj.GetComponent<SpriteRenderer>();
            renderer.enabled = true;

            yield return new WaitForSeconds(2.0f);

            //  �\�����I�t
            renderer.enabled=false;
            _startBattle = false;

            //  �퓬
            GameObject main_cam = GameObject.Find("Main Camera");
            Debug.Log(main_cam);
            //  �o�g���V�[���̌Ăяo��

            ChangeSubScene csBattle = obj.GetComponent<ChangeSubScene>();

            Debug.Log(csBattle);
            Debug.Log(csBattle._subScene);
            yield return StartCoroutine(csBattle.load());
            Debug.Log("�퓬�C��");
            //  �퓬�C��
        }
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

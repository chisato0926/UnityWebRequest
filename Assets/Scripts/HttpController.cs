﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    private void Start() {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect() {
        string url = "https://joytas.net/php/hello.php";
        UnityWebRequest uwr = UnityWebRequest.Get(url); //Getメソッドでインスタンス作成
        yield return uwr.SendWebRequest(); //インスタンスをSendWebRequestメソッドで通信
        if (uwr.isHttpError || uwr.isNetworkError) {
            Debug.Log(uwr.error);
        } else {
            Debug.Log(uwr.downloadHandler.text);
        }
    }
}

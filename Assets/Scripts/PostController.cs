using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect() {
        WWWForm form = new WWWForm();
        //リクエストパラメータの取得AddField(keyの名前,値)
        form.AddField("x", 5);
        form.AddField("y", 8);

        string url = "https://joytas.net/php/calc.php";
        UnityWebRequest uwr = UnityWebRequest.Post(url, form); //Post通信
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError) {
            Debug.Log(uwr.error);
        } else {
            Debug.Log(uwr.downloadHandler.text);
        }
    }
}

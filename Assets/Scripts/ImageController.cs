using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect() {
        string url = "https://joytas.net/php/man.jpg";
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url); //UnityWebRequestクラスのGetTextureメソッドでインスタンスを作成
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError) {
            Debug.Log(uwr.error);
        } else {
            Texture texture = DownloadHandlerTexture.GetContent(uwr); //画像の取得
            //Canvasで使用するためにSpriteに変換
            Sprite sp = Sprite.Create((Texture2D)texture, //第一引数にTexture2D,
                new Rect(0, 0, texture.width, texture.height), //第二引数に使用するtextureの範囲(x,y,width,height)
                new Vector2(0.5f, 0.5f)); //第三引数にSpriteの中心を設定
            sp.name = "man"; //spriteの名前を設定
            Image image = GetComponent<Image>();
            image.rectTransform.sizeDelta = new Vector2(texture.width, texture.height); //sizeDelta(rectTransformのwidthとheight)で元の画像のサイズに設定
            image.sprite = sp; //sorceImageにspを登録
        }
    }
}

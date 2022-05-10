using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tool : MonoBehaviour
{
    public delegate void callback(object obj);


    public void WWWGet(string url, callback cb)
    {
        StartCoroutine(_WWWGet(url, cb));
    }


    IEnumerator _WWWGet(string url, callback cb)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            if (www.responseCode==500)
            {
                Debug.Log("请输入正确的名称或年份");
            }
            else if (www.responseCode == 404)
            {
                Debug.Log("请输入正确的名称或年份");
            }
        }
        else
        {
            cb(www.downloadHandler.text);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Request Handler will be used for all type of Api request 
/// </summary>
public class RequestHandler : MonoBehaviour
{

    private const string baseUrl = "https://5e6b24f90f70dd001643c248.mockapi.io/v1/demo/math/data";

    public static RequestHandler requestHandler;

    private void Awake()
    {
        requestHandler = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// API call from server
    /// </summary>
    public void RequestDataFromServer()
    {
        UnityWebRequest request = new UnityWebRequest(baseUrl, "Post");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        StartCoroutine(ServerResponse(request));
    }

    IEnumerator ServerResponse(UnityWebRequest webRequest)
    {
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError)
        {
            Debug.Log(": Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(" Request data" + webRequest.downloadHandler.text);
        }
        
    }


}

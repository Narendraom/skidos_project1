using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace ServerManagment
{


    /// <summary>
    /// Request Handler will be used for all type of Api request 
    /// </summary>
    public class RequestHandler
    {

        private const string baseUrl = "https://5e6b24f90f70dd001643c248.mockapi.io/v1/demo/math/data";



        /// <summary>
        /// API call from server
        /// </summary>
        public void RequestDataFromServer(ServerRequestBehaviour requestBehaviour)
        {
            UnityWebRequest request = new UnityWebRequest(baseUrl, "Get");// Post method giving error response
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            requestBehaviour.StartCoroutine(ServerResponse(request, requestBehaviour));
        }

        IEnumerator ServerResponse(UnityWebRequest webRequest, IResponse response)
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
                response?.Failed(webRequest.error);
            }
            else
            {
                 Debug.Log(" Request data" + webRequest.downloadHandler.text);
                response?.Success(webRequest.downloadHandler.text);
            }

        }


    }
}
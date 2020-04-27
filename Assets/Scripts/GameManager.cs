using System.Collections;
using System.Collections.Generic;
using ServerManagment;
using UnityEngine;

/// <summary>
/// Manages App throughout the  .
/// </summary>
public class GameManager : MonoBehaviour
{

    private const string SingletonName = "/[GameManager]";

    private static readonly object Lock = new object();
    private static GameManager _instance;

    private RequestHandler _requestHandler;

    public RequestHandler RequestHandler
    {
        get
        {
            if (_requestHandler == null)
                _requestHandler = new RequestHandler();
            return _requestHandler;
        }
    }

    /// <summary>
    /// The singleton instance of the GameManager.
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            lock (Lock)
            {
                if (_instance != null) return _instance;
                var go = GameObject.Find(SingletonName);
                if (go == null)
                {
                    go = new GameObject(SingletonName);
                }

                if (go.GetComponent<GameManager>() == null)
                {
                    go.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(go);
                _instance = go.GetComponent<GameManager>();
                return _instance;
            }
        }
    }

  
}

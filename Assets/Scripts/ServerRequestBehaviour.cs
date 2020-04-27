using System.Collections;
using System.Collections.Generic;
using ServerManagment;
using UnityEngine;

public class ServerRequestBehaviour : MonoBehaviour, IResponse
{
    public virtual void Failed(string error)
    {
        
    }

    public virtual void Success(string response)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Will Controll menu and UI options
/// </summary>
public class MenuController : MonoBehaviour, IResponse
{
    [SerializeField]
    GameObject _startScreen;

    [SerializeField]
    GameObject _savedataScreen;

    [SerializeField]
    GameObject _categoryScreen;

    [SerializeField]
    Text _errorText;



    public void Failed(string error)
    {
        _errorText.text = "Error: " + error;
        _errorText.gameObject.SetActive(true);

    }

    public void Success(string response)
    {

    }
}

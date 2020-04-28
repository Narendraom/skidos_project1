using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Will Controll menu and UI options
/// </summary>
public class MenuController : ServerRequestBehaviour
{
    [SerializeField]
    GameObject _startScreen;

    [SerializeField]
    GameObject _categoryScreen;

    [SerializeField]
    GameObject _levelScreen;

    [SerializeField]
    GameObject _loadingScreen;

    [SerializeField]
    Text _errorText;



    public void FetchButtonClicked()
    {
        _loadingScreen.SetActive(true);
        GameManager.Instance.RequestHandler.RequestDataFromServer(this);
    }


    public override void Failed(string error)
    {
        _loadingScreen.SetActive(false);
        _errorText.text = "Error: " + error;
        _errorText.gameObject.SetActive(true);

    }

    public override void Success(string response)
    {
        GameManager.Instance.ParseCreatorData(response);
        _loadingScreen.SetActive(false);
        _startScreen.SetActive(false);
        _categoryScreen.SetActive(true);

    }

   

    /// <summary>
    /// Click of operation button: Addition, Subtraction etc.
    /// </summary>
    /// <param name="operationId"> id of button object, will calculate operation state</param>

    public void OperationButtonClicked(int operationId)
    {
        GameManager.Instance.operationId = operationId;
        _categoryScreen.SetActive(false);
        _levelScreen.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScreen : MonoBehaviour
{

    [SerializeField]
    InputField _keyInputField;

    [SerializeField]
    InputField _valueInputField;

    [SerializeField]
    Text infoText;


    private void OnEnable()
    {
        _keyInputField.text = "";
        _valueInputField.text = "";
    }

    public void OnSaveButtonClicked()
    {
        if(string.IsNullOrEmpty(_keyInputField.text))
        {
            infoText.text = "Error: Enter Key!";
            infoText.gameObject.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(_valueInputField.text))
        {
            infoText.text = "Error: Enter value!";
            infoText.gameObject.SetActive(true);
            return;
        }
        infoText.gameObject.SetActive(false);

        
        
#if UNITY_ANDROID

        
        string key = _keyInputField.text;
        string value = _valueInputField.text;
       
        NativeBridge.SaveData(key, value);

        infoText.text = NativeBridge.RetreiveData();
        infoText.gameObject.SetActive(true);

        _keyInputField.text = "";
        _valueInputField.text = "";
#endif
    }
}

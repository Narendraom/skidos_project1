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

        
        SavedData dataString = new SavedData();
        dataString.key = _keyInputField.text;
        dataString.value = _valueInputField.text;

        string savedData = NativeBridge.RetreiveData();
        SavedDataList savedList = new SavedDataList();
        if (!PlayerPrefs.HasKey("key"))
        {
            savedList.savedData = new List<SavedData>();
            PlayerPrefs.SetString("key", "key");
        }else
            savedList = JsonUtility.FromJson<SavedDataList>(savedData);

        savedList.savedData.Add(dataString);
        string jsondata = JsonUtility.ToJson(savedList);
        NativeBridge.SaveData(jsondata);

        infoText.text = NativeBridge.RetreiveData();
        infoText.gameObject.SetActive(true);

        _keyInputField.text = "";
        _valueInputField.text = "";
#endif
    }
}

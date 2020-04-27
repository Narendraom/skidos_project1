using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

/// <summary>
/// Will Controll menu and UI options
/// </summary>
public class MenuController : ServerRequestBehaviour
{
    [SerializeField]
    GameObject _startScreen;

    [SerializeField]
    GameObject _savedataScreen;

    [SerializeField]
    GameObject _categoryScreen;

    [SerializeField]
    Text _errorText;



    public void FetchButtonClicked()
    {
        GameManager.Instance.RequestHandler.RequestDataFromServer(this);
    }


    public override void Failed(string error)
    {
        _errorText.text = "Error: " + error;
        _errorText.gameObject.SetActive(true);

    }

    public override void Success(string response)
    {

        ParseJsonToObject(response);
    }

    /// <summary>
    /// There are lots of json deserilzer I am using simple json parser right now
    /// </summary>
    /// <param name="json"> string to parse in object</param>

    private void ParseJsonToObject(string json)
    {
        var responseData = JSON.Parse(json);
        Creator[] creators = new Creator[responseData.Count];
        for (int i = 0; i < creators.Length; i++)
        {
            creators[i] = new Creator();
            creators[i].id = responseData[i]["id"];
            creators[i].name = responseData[i]["name"];
            creators[i].createdAt = responseData[i]["createdAt"];
            creators[i].avatar = responseData[i]["avatar"];

            // Addition category parsing
            creators[i].Addition = new Addition();
            var additionJsonNode = responseData[i]["Addition"];
            creators[i].Addition.data = new Item[additionJsonNode.Count][];
            for (int j = 0; j < additionJsonNode.Count; j++)
            {
                creators[i].Addition.data[j] = new Item[additionJsonNode[j].Count];
                for (int k = 0; k < additionJsonNode[j].Count; k++)
                {
                    creators[i].Addition.data[j][k] = new Item();
                    creators[i].Addition.data[j][k].subtopic_id = additionJsonNode[j][k]["subtopic_id"];
                    creators[i].Addition.data[j][k].subtopic_name = additionJsonNode[j][k]["subtopic_name"];
                }
            }

            // Geometry category parsing

            creators[i].Geometry = new Geometry();
            var geometryJsonNode = responseData[i]["Geometry"];
            creators[i].Geometry.data = new Item[geometryJsonNode.Count][];
            for (int j = 0; j < geometryJsonNode.Count; j++)
            {
                creators[i].Geometry.data[j] = new Item[geometryJsonNode[j].Count];
                for (int k = 0; k < geometryJsonNode[j].Count; k++)
                {
                    creators[i].Geometry.data[j][k] = new Item();
                    creators[i].Geometry.data[j][k].subtopic_id = geometryJsonNode[j][k]["subtopic_id"];
                    creators[i].Geometry.data[j][k].subtopic_name = geometryJsonNode[j][k]["subtopic_name"];
                }
            }

            //Mixed Operations parsing

            creators[i].MixedOperations = new MixedOperations();
            var mixedJsonNode = responseData[i]["Mixed Operations"];
            creators[i].MixedOperations.data = new Item[mixedJsonNode.Count][];
            for (int j = 0; j < mixedJsonNode.Count; j++)
            {
                creators[i].MixedOperations.data[j] = new Item[mixedJsonNode[j].Count];
                for (int k = 0; k < mixedJsonNode[j].Count; k++)
                {
                    creators[i].MixedOperations.data[j][k] = new Item();
                    creators[i].MixedOperations.data[j][k].subtopic_id = mixedJsonNode[j][k]["subtopic_id"];
                    creators[i].MixedOperations.data[j][k].subtopic_name = mixedJsonNode[j][k]["subtopic_name"];
                }
            }

            // Number sense Parsing
            Debug.Log(responseData[i]["name"]);
            creators[i].Numbersense = new NumberSense();
            var numberJsonNode = responseData[i]["Number sense"];
            creators[i].Numbersense.data = new Item[numberJsonNode.Count][];
            Debug.Log(numberJsonNode.Count);
            for (int j = 0; j < numberJsonNode.Count; j++)
            {
                creators[i].Numbersense.data[j] = new Item[numberJsonNode[j].Count];
                for (int k = 0; k < numberJsonNode[j].Count; k++)
                {
                    creators[i].Numbersense.data[j][k] = new Item();
                    creators[i].Numbersense.data[j][k].subtopic_id = numberJsonNode[j][k]["subtopic_id"];
                    creators[i].Numbersense.data[j][k].subtopic_name = numberJsonNode[j][k]["subtopic_name"];
                }
            }

            // Subtraction Parsing

            creators[i].Subtraction = new Subtraction();
            var subJsonNode = responseData[i]["Subtraction"];
            creators[i].Subtraction.data = new Item[subJsonNode.Count][];
            for (int j = 0; j < subJsonNode.Count; j++)
            {
                creators[i].Subtraction.data[j] = new Item[subJsonNode[j].Count];
                for (int k = 0; k < subJsonNode[j].Count; k++)
                {
                    creators[i].Subtraction.data[j][k] = new Item();
                    creators[i].Subtraction.data[j][k].subtopic_id = subJsonNode[j][k]["subtopic_id"];
                    creators[i].Subtraction.data[j][k].subtopic_name = subJsonNode[j][k]["subtopic_name"];
                }
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using ServerManagment;
using SimpleJSON;
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

    public Creator[] creatorData;

    /// <summary>
    /// 1. Addition
    /// 2. Geometry
    /// 3. Mixed Operation
    /// 4. Number Sense
    /// 5. Subtraction
    /// </summary>
    public int operationId;

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

    /// <summary>
    /// There are lots of json Deserialization I am using simple json parser right now
    /// </summary>
    /// <param name="json"> string to parse in object</param>
    public void ParseCreatorData(string json)
    {
        var responseData = JSON.Parse(json);
        creatorData = new Creator[responseData.Count];
        for (int i = 0; i < creatorData.Length; i++)
        {
            creatorData[i] = new Creator();
            creatorData[i].id = responseData[i]["id"];
            creatorData[i].name = responseData[i]["name"];
            creatorData[i].createdAt = responseData[i]["createdAt"];
            creatorData[i].avatar = responseData[i]["avatar"];

            // Addition category parsing
            creatorData[i].Addition = new Addition();
            var additionJsonNode = responseData[i]["Addition"];
            creatorData[i].Addition.data = new Item[additionJsonNode.Count][];
            for (int j = 0; j < additionJsonNode.Count; j++)
            {
                creatorData[i].Addition.data[j] = new Item[additionJsonNode[j].Count];
                for (int k = 0; k < additionJsonNode[j].Count; k++)
                {
                    creatorData[i].Addition.data[j][k] = new Item();
                    creatorData[i].Addition.data[j][k].subtopic_id = additionJsonNode[j][k]["subtopic_id"];
                    creatorData[i].Addition.data[j][k].subtopic_name = additionJsonNode[j][k]["subtopic_name"];
                }
            }

            // Geometry category parsing

            creatorData[i].Geometry = new Geometry();
            var geometryJsonNode = responseData[i]["Geometry"];
            creatorData[i].Geometry.data = new Item[geometryJsonNode.Count][];
            for (int j = 0; j < geometryJsonNode.Count; j++)
            {
                creatorData[i].Geometry.data[j] = new Item[geometryJsonNode[j].Count];
                for (int k = 0; k < geometryJsonNode[j].Count; k++)
                {
                    creatorData[i].Geometry.data[j][k] = new Item();
                    creatorData[i].Geometry.data[j][k].subtopic_id = geometryJsonNode[j][k]["subtopic_id"];
                    creatorData[i].Geometry.data[j][k].subtopic_name = geometryJsonNode[j][k]["subtopic_name"];
                }
            }

            //Mixed Operations parsing

            creatorData[i].MixedOperations = new MixedOperations();
            var mixedJsonNode = responseData[i]["Mixed Operations"];
            creatorData[i].MixedOperations.data = new Item[mixedJsonNode.Count][];
            for (int j = 0; j < mixedJsonNode.Count; j++)
            {
                creatorData[i].MixedOperations.data[j] = new Item[mixedJsonNode[j].Count];
                for (int k = 0; k < mixedJsonNode[j].Count; k++)
                {
                    creatorData[i].MixedOperations.data[j][k] = new Item();
                    creatorData[i].MixedOperations.data[j][k].subtopic_id = mixedJsonNode[j][k]["subtopic_id"];
                    creatorData[i].MixedOperations.data[j][k].subtopic_name = mixedJsonNode[j][k]["subtopic_name"];
                }
            }

            // Number sense Parsing
            //Debug.Log(responseData[i]["name"]);
            creatorData[i].Numbersense = new NumberSense();
            var numberJsonNode = responseData[i]["Number sense"];
            creatorData[i].Numbersense.data = new Item[numberJsonNode.Count][];
//            Debug.Log(numberJsonNode.Count);
            for (int j = 0; j < numberJsonNode.Count; j++)
            {
                creatorData[i].Numbersense.data[j] = new Item[numberJsonNode[j].Count];
                for (int k = 0; k < numberJsonNode[j].Count; k++)
                {
                    creatorData[i].Numbersense.data[j][k] = new Item();
                    creatorData[i].Numbersense.data[j][k].subtopic_id = numberJsonNode[j][k]["subtopic_id"];
                    creatorData[i].Numbersense.data[j][k].subtopic_name = numberJsonNode[j][k]["subtopic_name"];
                }
            }

            // Subtraction Parsing

            creatorData[i].Subtraction = new Subtraction();
            var subJsonNode = responseData[i]["Subtraction"];
            creatorData[i].Subtraction.data = new Item[subJsonNode.Count][];
            for (int j = 0; j < subJsonNode.Count; j++)
            {
                creatorData[i].Subtraction.data[j] = new Item[subJsonNode[j].Count];
                for (int k = 0; k < subJsonNode[j].Count; k++)
                {
                    creatorData[i].Subtraction.data[j][k] = new Item();
                    creatorData[i].Subtraction.data[j][k].subtopic_id = subJsonNode[j][k]["subtopic_id"];
                    creatorData[i].Subtraction.data[j][k].subtopic_name = subJsonNode[j][k]["subtopic_name"];
                }
            }
        }
    }


}

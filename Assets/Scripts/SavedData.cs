using System;
using System.Collections.Generic;

[Serializable]
public class SavedData
{
    public string key;
    public string value;
}

[Serializable]
public class SavedDataList
{
    public List<SavedData> savedData = new List<SavedData>();
}


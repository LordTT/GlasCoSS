using UnityEngine;

[System.Serializable]
public class Patient
{
    public int eye;
    public int physical;
    public int speech;
}

[System.Serializable]
public class Discussion
{
    public string ID;
    public string question;
    public string answer;
}

[System.Serializable]
public class Family
{
    public Discussion[] discussion;
}

[System.Serializable]
public class Diagnosis
{
    public string ID;
    public string Date;
    public string[] paragraphs;
}

[System.Serializable]
public class Record
{
    public string history;
    public string size;
    public string weight;
    public string bmi;
    public Diagnosis[] diagnosis;
    public string[] systems;
}

[System.Serializable]
public class Scenario
{
    public string ID;
    public Patient patient;
    public Family family;
    public Record record;
}

[System.Serializable]
public class RootObject
{
    public Scenario scenario;
}

public class JsonParsing : MonoBehaviour
{
   
    public TextAsset jsonFile;
    public RootObject rootObject;

    private void Awake()
    {
        Debug.Log(jsonFile);
        rootObject = JsonUtility.FromJson<RootObject>(jsonFile.text);
        Debug.Log("json parsed");
    }
}
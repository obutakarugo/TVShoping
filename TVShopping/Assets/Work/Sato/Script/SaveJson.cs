using UnityEngine;
using System.IO;
using MiniJSON;
using System.Collections.Generic;
using System.Collections;


public class SaveJson : MonoBehaviour {

    //unity editor　only ../Assets/
    //パス名

    const string JsonPath = "/Work/Sato/Resources";
    const string FileName = "/sample.json";
    // Use this for initialization
    void Start () {

        //書き込み.////////
        //既存チェッカー
        var _strage_path = (Application.dataPath + JsonPath);
        if (!Directory.Exists(_strage_path))
        {
            //なかったら作る。
            Directory.CreateDirectory(_strage_path);

        }
        var json_text =  File.ReadAllText(Application.dataPath + JsonPath + FileName);
        var json_test = Json.Deserialize(json_text) as Dictionary<string,object>;
        var parameter_test = json_test["info"] as List<object>;
        var param_test = parameter_test[0] as Dictionary<string, object>;
        param_test["state"] = (long)50;
        File.WriteAllText(Application.dataPath + JsonPath + FileName, Json.Serialize(json_test));

        ////////////////////////////////////////////////////
/*
        TextAsset textAsset = Resources.Load("sample") as TextAsset;
        string jsonText = textAsset.text;
        JsonNode json = JsonNode.Parse(jsonText);

        string test = json["info"]["data"][1]["test"].Get<string>();
        

        Debug.Log(test);
        */
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

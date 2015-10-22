using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

    [SerializeField]
    GUISkin Skin;

    GUIStyle Style;
    GUIStyleState State;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	 
	}

    void OnGUI()
    {

        Style = new GUIStyle();
        State = new GUIStyleState();

        GUI.skin=Skin;

        State.textColor = Color.white;

        Style.fontSize = 30;
        Style.normal = State;

        if (GUI.Button(new Rect(0, 0, Screen.width/4, Screen.height/4), "カタログ"))
        {
            Application.LoadLevel("Catalog");
        }

        if (GUI.Button(new Rect(Screen.width / 2 + Screen.width / 4, 0, Screen.width / 4, Screen.height / 4), "オプション"))
        {
            Application.LoadLevel("Option");
        }
        
    }
}

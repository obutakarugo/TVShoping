using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    TouchSystem _touch;
    Scene_Manager _scene_manager;

    // Use this for initialization
    void Start()
    {
        _touch = GetComponent<TouchSystem>();
        _scene_manager = GetComponent<Scene_Manager>();
    }

    [SerializeField]
    Scene_Manager.SCENE_NAME scene;

    void Update()
    {
        if (_touch.isTouch())
        {
            _scene_manager.NextScene(scene);
        }
    }
}

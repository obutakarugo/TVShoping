using UnityEngine;
using System.Collections;

public class Scene_Manager : MonoBehaviour
{
    public enum SCENE_NAME
    {
        Ono,
        Nishimaki,
        Catalog,
        Option,
        Sato,
        GameMain,
    }

    public void NextScene(SCENE_NAME scene)
    {
        Application.LoadLevel(scene.ToString());
    }
}

using UnityEngine;
using System.Collections;


public class TouchSystem : MonoBehaviour {
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
        isTouch();
	}

    // 反応が悪いのでマウスクリックでの操作は保留
    //void isTouch()
    //{
    //    // クリックした瞬間に反応
    //    if (Input.GetMouseButtonDown(0)) Debug.Log("左クリック");

    //    // クリックを離した瞬間に反応
    //    else if (Input.GetMouseButtonUp(0)) Debug.Log("左リリース");

    //    else Debug.Log("");
    //}

    void isTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("touch Began!");
                    break;

                case TouchPhase.Moved:
                    Debug.Log("touch Moved!");
                    break;

                case TouchPhase.Stationary:
                    Debug.Log("touch Stationary!");
                    break;

                case TouchPhase.Ended:
                    Debug.Log("touch Ended!");
                    break;

                case TouchPhase.Canceled:
                    Debug.Log("touch Canceled!");
                    break;
            };
        }
    }
}

using UnityEngine;
using System.Collections;


public class TouchSystem : MonoBehaviour
{
    void Update()
    {
        isTouch();
    }

    // 画面のタッチ判定
    bool isTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // タッチした瞬間にtrueを返す(タッチを認識)
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("True!!");
                return true;
            }

            // タッチを継続していてもtrueを返す
            else if (touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Stationary!!");
                return true;
            }

            // タッチを離した瞬間にfalseを返す
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("False!!");
                return false;
            }
        }
        return false;
    }
}

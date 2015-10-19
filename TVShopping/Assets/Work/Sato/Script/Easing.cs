using UnityEngine;


//   Easing 関数のまとめ（iTween使えよ！なんて言わないで..）
//  なぜこの数式なのかはわかりませんが、
//　とりあえず公式があったのでそれ見てそのままつかいましたとさ... ※ 徐々に追加予定
// 
// [引数概要]
// time:時間量？ totaltime:到達時間　min:現在値（この値から） max：目的値(この値まで移動) 
//　
//                                          参照:http://easings.net/ja 


public class Easing : MonoBehaviour
{

    //Easing
    //徐々に加速
    public double InQuad(double time, double totaltime, double max, double min)
    {
        max -= min;
        time /= totaltime;
        return max * time * time + min;
    }
    //徐々に減速
    public double OutQuad(double time, double totaltime, double max, double min)
    {
        max -= min;
        time /= totaltime;
        return -max * time * (time -2) + min;
    }

    //滑らかなSの字加速
    public double InOutQuart(double time, double totaltime, double max, double min)
    {
        max -= min;
        time /= totaltime;
        if (time / 2 < 1)
            return max / 2 * time * time * time * time + min;
        time -= 2;
        return -max / 2 * (time * time * time * time - 2) + min;
    }



}


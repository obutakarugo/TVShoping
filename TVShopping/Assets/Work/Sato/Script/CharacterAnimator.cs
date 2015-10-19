using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour
{

    //
    //　[キャラクターアニメーション]
    //
    //  現時点ではデバッグ作業が多いため,
    //  わざとpublicで宣言しています。
    //
    //
    
    //sin,cos計算用に円周率を固定.雑把に.14まで。
    private const float RADIUS = 3.14F;
    Easing _easing;

    //表情(画像)パターン
    public enum State
    {

        Normal = 0,             //通常時
        Smile,                  //笑顔
        Happened,               //驚き

        Last,                   //番兵
    }
    public State _current_state;
    public State _next_state;

    //アニメーションパターン
    public enum Animation
    {

        UpScaling = 0,          //縦に拡縮
        Hopping,                //跳ねる
        RotatoToChangeState,    //回転して表情（画像）変更

        Last,           //番兵

    }
    public Animation _current_animation;
    public Animation _next_animation;

    //キャラクターの画像格納と、表示画像領域
    public Sprite[] _charater_index;
    private SpriteRenderer _character;

    //アニメーションスピード
    //時間
    //デフォルトサイズ.
    public float _animation_timer;
    public float _animation_counter  = 0.0f;
    public Vector2 _defalt_scale;
    public Vector2 _defalt_position;

    //拡縮度合
    public float _scaling_limit;
    public float _scaling_speed;
    //跳ねる度合
    public float _hopping_limit = 30.0f;
    public float _total_hopping_time = 1.0f;
    //半回転
    private const float _defalt_rotate = 0.0f;
    private const float _rotate_limit = 90.0f;
    [Range(0.0f,1.0f)]
    public float _total_rotate_time = 1.0F;

    private bool _is_reverse;
    //初期化
    void Awake()
    {

        //easing初期化
        _easing = GameObject.FindObjectOfType<Easing>();
        
        //sprite初期化
        _character = GetComponent<SpriteRenderer>();
        _character.sprite = _charater_index[(int)_current_state]; 

        //デフォルトのスケールを保存.
        _defalt_scale = new Vector2(transform.localScale.x, transform.localScale.y);
        _defalt_position = transform.position;
    }


    // 毎フレーム呼び出し
    void Update()
    {

        ///[TEST処理]///[TEST処理]///[TEST処理]
     
        //Debug用表情変更
        ChangeState();
        _character.sprite = ChangeSprite(_current_state);
        
        ///[TEST処理]///[TEST処理]///[TEST処理]
        

        //アニメーションタイマーが０じゃない場合
        //同じアニメーションを繰り替えす.
        if (_animation_timer > 0)
        {
            //カウンターを更新
            _animation_timer -= Time.deltaTime;
           

            switch (_current_animation)
            {

                 ///////拡縮 ※正確には縮んでもとに戻るようにしてあります.///////////////
                case Animation.UpScaling:

                    transform.localScale = new Vector2(_defalt_scale.x,
                                                       _defalt_scale.y
                                                        - (Mathf.Abs
                                                           (Mathf.Sin(_scaling_speed * _animation_timer * RADIUS / 180.0f))
                                                            * _scaling_limit));

                    //他のアニメーションに遷移
                    if (transform.localScale.y >= _defalt_scale.y - 0.01f)
                    {
                        transform.localScale = _defalt_scale;
                        _current_animation = _next_animation;
                    }
                    break;

                ///////跳ねる/////////////////////////////////////////////////////////
                case Animation.Hopping:

                    //カウンターを更新
                    _animation_counter += Time.deltaTime;

                    float half_time = _total_hopping_time * 0.5f;
                    //jump!※っぽく
                    if (_animation_counter < half_time)
                    transform.position = new Vector2(_defalt_position.x,
                                                    (float)_easing.InOutQuart(_animation_counter, half_time,
                                                                              _hopping_limit,_defalt_position.y));

                    //着地まで
                    if(_animation_counter >= half_time && _animation_counter < _total_hopping_time)
                    transform.position = new Vector2(_defalt_position.x,
                                                    (float)_easing.InOutQuart(_animation_counter - half_time, half_time,
                                                                              _defalt_position.y,_hopping_limit));

                    //到達時間に達したらリセット
                    if(_animation_counter >= _total_hopping_time)
                    {
                        //りせっと
                        _animation_counter = 0;
                        transform.position = _defalt_position;
                        //他のアニメーションに遷移
                        _current_animation = _next_animation;
                    }


                    break;

                //////状態遷移のため、回転.//////////////////////////////////////////////////
                case Animation.RotatoToChangeState:

                    //カウンターを更新
                    _animation_counter += Time.deltaTime;

                    
                    //半回転開始
                    if (_animation_counter < _total_rotate_time && !_is_reverse)
                    {
                        //限界値まで、いーじんぐで加算
                        transform.eulerAngles = new Vector3(0,
                                                            (float)_easing.InQuad(_animation_counter,_total_rotate_time,
                                                                                  _rotate_limit,_defalt_rotate),
                                                            0);

                    }

                    //半回転終了後、逆半回転のフラグを立てる
                    if(_animation_counter >= _total_rotate_time && !_is_reverse){

                        //折り返し
                        _is_reverse = true;
                        //表情（画像の差し替え
                        _current_state = _next_state;
                        //アニメーション用のカウンターをリセット
                        _animation_counter = 0.0f;

                    }

                    //逆半回転のフラグがたったら回転開始
                    if (_is_reverse && _animation_counter < _total_rotate_time) {

                        //total_time分の時間をかけて元のｙ軸に戻す
                        transform.eulerAngles = new Vector3(0,
                                                            (float)_easing.OutQuad(_animation_counter, _total_rotate_time,
                                                                                   _defalt_rotate,_rotate_limit),
                                                            0);
                       
                    }//元の位置にもどったら,位置ずれを修正、その後他のアニメーションに移る.
                    else if(_is_reverse && _animation_counter >= _total_rotate_time){


                        Debug.Log("Reset!");
                        //初期化
                        _is_reverse = false;
                        _animation_counter = 0;

                        //細かい位置ずれ用調整.
                        transform.eulerAngles = Vector3.zero;
                        
                        //他のアニメーションに遷移
                        _current_animation = _next_animation;

                    }

                    break;

            }

        }
    }

    //状態遷移(画像を変更)
    private Sprite ChangeSprite(State state) {

        return _charater_index[(int)state];

    }


    private void ChangeState() {

        if (Input.GetKeyDown("1")) { _next_animation = Animation.UpScaling; }
        if (Input.GetKeyDown("2")) { _next_animation = Animation.RotatoToChangeState; }
        if (Input.GetKeyDown("3")) { _next_animation = Animation.Hopping; }


        if (Input.GetKeyDown(KeyCode.Q)) { _next_state = State.Normal; _current_animation = Animation.RotatoToChangeState; }
        if (Input.GetKeyDown(KeyCode.W)) { _next_state = State.Smile; _current_animation = Animation.RotatoToChangeState; }
        if (Input.GetKeyDown(KeyCode.E)) { _next_state = State.Happened; _current_animation = Animation.RotatoToChangeState; }



    }

    //Easing
    //徐々に加速
    double InQuad(double time, double totaltime, double max, double min)
    {
        max -= min;
        time /= totaltime;
        return max * time * time + min;
    }

}

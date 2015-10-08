#### 今後必要な事は増えていくかもしれませんので、更新したらその都度連絡します。　　　　
***
# 命名規則    

## クラス・構造体・列挙体    
#### 単語の頭文字を大文字表記  
~~~  
class HogeFuga{}    
~~~

## 変数名    
#### 全て小文字表記
~~~
int hoge;
~~~

## メンバ変数    
#### アンダーバーを付けて、全て小文字表記
~~~
class HogeFuga{
    int _hoge;
}
~~~

## 定数名
#### 全て大文字表記
~~~
#define DEF (10)
~~~
~~~
enum{
  LEFT = 0,
  RIGHT = 1,
}
~~~

## 関数名
#### 単語の頭文字を大文字表記
~~~
void LifeCounter(){}
~~~
~~~
bool isHit(){}
~~~

## フォルダ名
#### 基本的に単語の頭文字を大文字表記
#### 場合によって大文字とする(SE、BGM等)
~~~
Player、 Enemy、 BGM、 SE 等
~~~

## Material名
#### Unityでの制作なのでMaterialにも規則を設けます。
#### 単語の頭文字を大文字表記
~~~
Button、 Studio、 Character 等
~~~

using UnityEngine;
using System.Collections;

/* 景品を扱うクラスです。景品にアタッチしてください
   変数raretypeはレア度を表す変数です。数値が高いほどレア度が高いです。 */

public class Keihin : MonoBehaviour {

    /////////////////////////////////////// フィールド ///////////////////////////////////////

    // レア度、数値が高いほうがレア。
    public int raretype;



    //////////////////////////////////////// メソッド ////////////////////////////////////////

    // レア度を取得する
    public int getRareType()
    {
        return raretype;
    }

    // レア度を設定する
    public void setRareType(int rare)
    {
        raretype = rare;
    }

    // レア度をランダムに設定する
    public void setRareType()
    {
        System.Random r = new System.Random();



        setRareType((new System.Random()).Next(4));
    }
}

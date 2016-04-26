using UnityEngine;
using System.Collections;

/* 景品を検出し、結果を出力するクラスです。
   景品を検出するオブジェクトにアタッチしてください。
*/
public class KeihinMgr : MonoBehaviour {


    //////////////////////////////////////// メソッド ////////////////////////////////////////

    // 初回の動作
    void Start()
    {

    }

    // 1フレームおきの動作
    void Update()
    {

    }

    // 接触したとき
    void OnTriggerEnter(Collider c)
    {
        // 結果を表示する
        keihinShow(c.gameObject);
    }

    // レア度を判定し、結果を表示する
    void keihinShow(GameObject c)
    {
        // 景品以外は終了する
        if (c.GetComponent<Keihin>() == null) return;

        
        switch (c.GetComponent<Keihin>().getRareType())
        {

            // ノーマル
            case 0:
                Debug.Log("ノーマルの景品です。");
                break;

            // レア
            case 1:
                Debug.Log("レアの景品です。");
                break;

            // スーパーレア
            case 2:
                Debug.Log("スーパーレアの景品です。");
                break;

            // ウルトラレア
            default:
                Debug.Log("ウルトラレアの景品です。");
                break;
        }
    }

}

using UnityEngine;
using System.Collections;

/* 景品を検出し、結果を出力するクラスです。
   景品を検出するオブジェクトにアタッチしてください。
*/
public class KeihinMgr : MonoBehaviour {
    int rare_rand;

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
    void OnCollisionEnter(Collision c)
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
            // ノーマル～レア
            case 1:
                rare_rand = Random.Range(1, 71);
                break;

            // レア～スーパーレア
            case 2:
                rare_rand = Random.Range(51,91);
                break;

            // スーパーレア～ウルトラレア
            default:
                rare_rand = Random.Range(81, 101);
                break;
        }

        if (0 <= rare_rand && rare_rand <= 50) {
            Debug.Log("ノーマル："+rare_rand);
        }
        else if (51 <= rare_rand && rare_rand <= 80) {
            Debug.Log("レア："+rare_rand);
        }
        else if (81 <= rare_rand && rare_rand <= 95) {
            Debug.Log("スーパーレア："+rare_rand);
        }
        else if (91 <= rare_rand && rare_rand <= 100) {
            Debug.Log("ウルトラレア："+rare_rand);
        }
    }
}

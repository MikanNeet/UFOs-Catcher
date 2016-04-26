//大石君持ってない
using UnityEngine;
using System.Collections;

public class U_Arm : MonoBehaviour {

    //アームのモード
    byte mode_flg = 0;
    //アームが衝突しているかの判定
    bool collide_flg;

    //戻る時の速度
    float ret_spe=0.1f;
    //初期位置格納
    Vector3 def_pos;
    //移動後の場所
    Vector3 after_pos;

    GameObject L_A;
    GameObject R_A;
    const int max = 40;
    int cnt = max;

    // Use this for initialization
    void Start()
    {
        def_pos = this.transform.position;
        //L_A = GameObject.Find("l_arm");
        //R_A = GameObject.Find("r_arm");
        
        L_A = GameObject.Find("tume_left_2");
        R_A = GameObject.Find("tume_right_2");
    }
	
	// Update is called once per frame
	void Update () {

        //アームの状態変化
        switch (mode_flg)
        {
            case 0://ボタン1を押しまち。x方向移動
                if (Input.GetMouseButton(0)) {
                    this.gameObject.transform.position += new Vector3(ret_spe, 0, 0);
                }

                if (Input.GetMouseButtonUp(0)) {//左クリックを外したら次のフェーズへ
                    
                    mode_flg = 1;
                }

                if (collide_flg) {//もし衝突したとき
                    mode_flg = 255;
                }
                break;
            case 1://ボタン2を押しまち。z方向移動
                if (Input.GetMouseButton(0))
                {
                    this.gameObject.transform.position += new Vector3(0, 0, ret_spe);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    mode_flg = 2;
                }
                break;
            case 2://アームの爪が開く
                L_A.transform.Rotate(0, 0, 1);
                R_A.transform.Rotate(0, 0, -1);
                cnt--;
                if (cnt == 0)
                {
                    mode_flg = 3;
                }
                break;
            case 3://アームの降下
                this.gameObject.transform.position -= new Vector3(0, 0.05f, 0f);
                break;
            case 4://アームの爪が戻る
                L_A.transform.Rotate(0, 0, -1);
                R_A.transform.Rotate(0, 0, 1);
                cnt++;
                if (cnt == max)
                {
                    mode_flg = 5;
                }
                break;
            case 5://アームが上昇する
                this.gameObject.transform.position += new Vector3(0, 0.05f, 0f);
                if (def_pos.y - 0.1f < this.gameObject.transform.position.y && this.gameObject.transform.position.y < def_pos.y + 0.1f)
                {
                    this.gameObject.transform.position =new Vector3(this.transform.position.x,def_pos.y,this.transform.position.z);
                    after_pos.x = this.transform.position.x;
                    after_pos.z = this.transform.position.z;
                    mode_flg = 6;
                }
                break;
            case 6://アームが原点まで戻る
                Debug.Log("Z:"+after_pos.z+"/X:"+after_pos.x);
                

                if (after_pos.x< after_pos.z) {
                    this.gameObject.transform.position -= new Vector3(ret_spe * ((after_pos.x -def_pos.x)/ (after_pos.z-def_pos.z)), 0, ret_spe);
                }
                else {
                    this.gameObject.transform.position -= new Vector3(ret_spe, 0, ret_spe * ((after_pos.z - def_pos.z) / (after_pos.x - def_pos.x)));
                }
                if (def_pos.x-0.5f<=this.transform.position.x && this.transform.position.x<=def_pos.x+0.5f && def_pos.z - 0.5f <= this.transform.position.z && this.transform.position.z <= def_pos.z + 0.5f ) {
                    mode_flg = 7;
                    this.transform.position = def_pos;
                }
                break;
            case 7://アームの爪が開く
                L_A.transform.Rotate(0, 0, 1);
                R_A.transform.Rotate(0, 0, -1);
                cnt--;
                if (cnt == 0)
                {
                    mode_flg = 8;
                }
                break;
            case 8://アームの爪が閉じる
                L_A.transform.Rotate(0, 0, -1);
                R_A.transform.Rotate(0, 0, 1);
                cnt++;
                if (cnt == max)
                {
                    mode_flg = 0;
                }
                break;
            case 255://無動作格納庫
                Debug.Log("aa");
                if (Input.GetMouseButtonUp(0)) {
                    collide_flg = false;
                    mode_flg = 1;
                    after_pos = this.transform.position;
                }
                break;


        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.transform.tag=="kabe") {
            if (mode_flg == 0)
            {//ｘ座標移動時は無動作格納庫へ
                collide_flg = true;
            }
            else if (mode_flg == 1) {//ｚ座標移動時は次のフェーズへ
                after_pos.x = this.transform.position.x;
                after_pos.z = this.transform.position.z;
                mode_flg++;
            }
        }
    }
    void OnCollisionEnter(Collision c) {
        if (mode_flg == 3) {
            if (this.gameObject.transform.position.y < -7f )
            {
                mode_flg++;
            }
            else {
                if (c.transform.tag == "kabe") {
                    mode_flg++;
                }
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class U_Manager : MonoBehaviour {

    public GameObject r;
    public GameObject sr;
    public GameObject ur;
    public GameObject Oya;
    GameObject ko;

    // Use this for initialization
    void Start() {
        Oya = GameObject.Find("KUREN");
        for (int i = 0; i < 6; i++) {
            int rand = Random.Range(1, 4);
            switch (rand)
            {
                case 1://SR
                    ko=Instantiate(sr, new Vector3(Random.Range(-15, 15), sr.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), sr.transform.rotation.y, sr.transform.rotation.z, sr.transform.rotation.w))as GameObject;
                    break;
                case 2://R
                    ko=Instantiate(r, new Vector3(Random.Range(-15, 15), r.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), r.transform.rotation.y, r.transform.rotation.z, r.transform.rotation.w))as GameObject;
                    break;
                case 3://UR
                    ko=Instantiate(ur, new Vector3(Random.Range(-15, 15), ur.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), ur.transform.rotation.y, ur.transform.rotation.z, ur.transform.rotation.w))as GameObject;
                    break;
            }
            ko.transform.parent = Oya.transform;
        }   
    }
	
	// Update is called once per frame
	void Update () {

	}

}

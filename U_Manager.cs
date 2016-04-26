//大石君持ってない
using UnityEngine;
using System.Collections;

public class U_Manager : MonoBehaviour {

    public GameObject n;
    public GameObject r;
    public GameObject sr;
    public GameObject ssr;
    public GameObject ur;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 6; i++) {
            int rand = Random.Range(1, 101);
            Debug.Log(rand);
            if (rand==61) {//ur
                Instantiate(ur, new Vector3(Random.Range(-15, 15), ur.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), ur.transform.rotation.y, ur.transform.rotation.z, ur.transform.rotation.w));

            }
            else if (96<=rand && rand<=100) {//ssr
                Instantiate(ssr, new Vector3(Random.Range(-15, 15), ssr.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), ssr.transform.rotation.y, ssr.transform.rotation.z, ssr.transform.rotation.w));

            }
            else if (86<=rand && rand<=95) {//sr
                Instantiate(sr, new Vector3(Random.Range(-15, 15), sr.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), sr.transform.rotation.y, sr.transform.rotation.z, sr.transform.rotation.w));

            }
            else if (62<=rand && rand<=85) {//r
                Instantiate(r, new Vector3(Random.Range(-15, 15), r.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), r.transform.rotation.y, r.transform.rotation.z, r.transform.rotation.w));

            }
            else {
                Instantiate(n, new Vector3(Random.Range(-15, 15), n.transform.position.y, Random.Range(-3, 10)), new Quaternion(Random.Range(-20, 20), n.transform.rotation.y, n.transform.rotation.z, n.transform.rotation.w));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

}

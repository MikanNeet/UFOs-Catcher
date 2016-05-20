using UnityEngine;
using System.Collections;

public class U_Prize : MonoBehaviour {

    GameObject oya;
	// Use this for initialization
	void Start () {
        oya = GameObject.Find("GetArea");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider c) {
        if (c.transform.tag == "get") {
            this.transform.parent= oya.transform;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.transform.tag == "get")
        {
            this.transform.parent = null;
        }
    }
}

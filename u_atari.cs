using UnityEngine;
using System.Collections;

public class u_atari : MonoBehaviour {

    private int atari;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
    }
	// Update is called once per frame
	void Update () {

	}
 public void SetAtari(int num)
    {
        atari=num;
    }
    public int GetAtari() {
        return atari;
    }
}

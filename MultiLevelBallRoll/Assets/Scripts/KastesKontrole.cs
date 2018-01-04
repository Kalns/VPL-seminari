using UnityEngine;
using System.Collections;

public class KastesKontrole : MonoBehaviour {

    public float speed = 1.0f;
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
         transform.Rotate((Vector3.right * Input.GetAxis("Vertical") * speed));
        transform.Rotate((Input.GetAxis("Horizontal") * Vector3.back * speed));
    }
}

using UnityEngine;
using System.Collections;

public class KapsulasKontrole : MonoBehaviour {
    public int timer = 0;
    Renderer rend;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + 1;
        if (timer >= 60)
        {
            Renderer rend = GetComponent<Renderer>();
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            rend.material.color = newColor;
            timer = 0;
        }
	
	}
}

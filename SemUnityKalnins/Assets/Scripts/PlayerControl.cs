using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    float horMove;
    float verMove;
    int count;
    public float speed = 10.0f;
    public Text countText;
    public Text winText;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Punkti: " + count.ToString();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        horMove = Input.GetAxis("Horizontal");
        verMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horMove, 0.0f, verMove);
        rb.AddForce(movement * speed);


    }

    void LateUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible items"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Punkti: " + count.ToString();
            if (count >= 12) { winText.text = "Tu uzvarēji!"; }
        }
    }
}

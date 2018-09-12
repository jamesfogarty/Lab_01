using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    public float speed;
    private int count;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }
   

    // Update is called once per frame
    void Update ()
    {
		
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    private void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win";
        }
    }


}

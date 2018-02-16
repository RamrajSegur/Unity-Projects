using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	public float speed;
	public Text counttext;
	public Text wintext;

	private	Rigidbody rb;

	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		Counttext ();
		wintext.text = "";
	}

	void FixedUpdate(){
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			Counttext ();
		}
	}

	void Counttext(){
		
		counttext.text = "Count " + count.ToString ();
		if (count >= 7) {
			wintext.text = "You Win!";
		}
	}

}

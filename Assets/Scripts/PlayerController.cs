using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		countText.text = "Count: " + count.ToString ();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, 0.0f, moveVertical);

		rb.AddForce (movement * speed);




	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString ();
			if (count >= 6) {
				winText.text = "You win!";
			}
		}
	}

}


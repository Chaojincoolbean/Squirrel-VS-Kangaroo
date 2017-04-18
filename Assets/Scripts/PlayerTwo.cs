using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {

	public Rigidbody2D rb;
	public float x;
	public float y;
	public float cx;
	public float cy;
	public GameObject Camera;
	public AudioSource audio;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		x = this.gameObject.transform.position.x;

		cx = Camera.GetComponent<Camera>().transform.position.x;
		cy = Camera.GetComponent<Camera>().transform.position.y;

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		//x = x + 0.1f;

		y = this.gameObject.transform.position.y;

//		if ((y - cy)> 5f) {
//
//			y = cy+4f;
//
//		}



		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			//x = this.gameObject.transform.position.x - 2f;
			Debug.Log("left");
			rb.AddForce (new Vector3 (-4, 0, 0), ForceMode2D.Impulse);
			audio.Play();
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {

			//x = this.gameObject.transform.position.x + 2f;
			rb.AddForce (new Vector3 (4, 0, 0), ForceMode2D.Impulse);
			audio.Play();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {

			//y = this.gameObject.transform.position.y + 2f;
			rb.AddForce (new Vector3 (0, 4, 0), ForceMode2D.Impulse);
			audio.Play();
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			//y = this.gameObject.transform.position.y - 2f;
			rb.AddForce (new Vector3 (0, -4, 0), ForceMode2D.Impulse);
			audio.Play();
		}

		//this.gameObject.transform.position = new Vector3 (x, y , this.gameObject.transform.position.z);

		
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player1") {

			coll.rigidbody.AddForce (new Vector3 (Random.Range(-10,10),Random.Range(-10,10), 0), ForceMode2D.Impulse);
		}

		if (coll.gameObject.tag == "platform") {

			rb.AddForce (new Vector3 (0, 1, 0), ForceMode2D.Impulse);
		}

	}

}

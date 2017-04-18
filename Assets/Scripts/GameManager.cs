using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Renderer))]

public class GameManager : MonoBehaviour {

	GameObject platform;
	public List<Color> Colors;
	public List<int> Positions;
	public List<int> Positionsx;
	public GameObject Player1;
	public GameObject Player2;
	Color newColor;
	float x;
	float y;
	int n;
	int m;
	float y1,y2,yc;


	// Use this for initialization
	void Start () {
		
		platform = Resources.Load<GameObject> ("platform");
		x = 0f;
		y = 0f;
		n = 0;
		m = 0;



	}
	
	// Update is called once per frame
	void Update () {
		n++;
		//Debug.Log (n);
		if ((n%10) == 0) {
			//Debug.Log (n%5);
			LoadSpriteDynamically();

		}

		y1 = Player1.gameObject.transform.position.y;
		y2 = Player2.gameObject.transform.position.y;
		yc = this.gameObject.transform.position.y;

		if ((yc - y1) > 5f) {
			SceneManager.LoadScene (3);

		}

		if ((yc - y2) > 5f) {
			SceneManager.LoadScene (2);
		}
			
		//x = x + 0.1f;

		//this.gameObject.transform.position = new Vector3 (cameraPosition.x + x, cameraPosition.y, cameraPosition.z);

	}

	void LoadSpriteDynamically(){


		if (Positions.Count > 0) {
			//y = Positions [Random.Range (0, Positions.Count)];
			y = Random.Range (-4f,4f);

		}

		if (Positionsx.Count > 0) {
			//x = Positionsx [Random.Range (0, Positionsx.Count)];
			x = Random.Range (-4f,4f);
		}
		
		Vector3 position = new Vector3(x,y,0);

		GameObject newPlatform = Instantiate (platform, position, Quaternion.identity) as GameObject;

		if (Colors.Count > 0) {
			newColor = Colors [Random.Range (0, Colors.Count)];
		}

		newPlatform.GetComponent<SpriteRenderer> ().color = newColor;


		Destroy (newPlatform,1f);



	}


}
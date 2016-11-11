using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class demo : MonoBehaviour {

	public GameObject obj;
	public Text txt1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		obj.transform.rotation = new Quaternion (1, 1, SwipeManager.angle, 1);
		obj.transform.localScale = new Vector3 (SwipeManager.strength.x/100, SwipeManager.strength.y/100, 1);

		if (SwipeManager.direction != Swipes.None) {
			txt1.text = SwipeManager.direction + "\t\t\t A: "+SwipeManager.angle+"\t\t\t S: "+SwipeManager.strength+"\n" + txt1.text;
		}

	}
}

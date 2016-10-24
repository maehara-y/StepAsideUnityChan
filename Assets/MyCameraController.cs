using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {

	private GameObject unitychan;	// Unityちゃんのオブジェクト
	private float difference;		// Unityちゃんとカメラの距離

	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find ("unitychan");
		// Unityちゃんとカメラの位置（z座標）の差を求める
		this.difference =  this.unitychan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
	}
}

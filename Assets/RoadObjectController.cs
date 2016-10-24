using UnityEngine;
using System.Collections;

// 課題1用クラス
public class RoadObjectController : MonoBehaviour {

	public GameObject unityChan;	// 破棄判定用のユニティちゃん

	// Update is called once per frame
	void Update () {
		// ユニティちゃんより後ろにきたオブジェクトを破棄する
		if (this.transform.position.z < unityChan.transform.position.z - 10) {
			Destroy(this.gameObject);
		}
	}
}

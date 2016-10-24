using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;	// carPrefabを入れる
	public GameObject coinPrefab;	// coinPrefabを入れる
	public GameObject conePrefab;	// cornPrefabを入れる
	public GameObject unityChan;	// unityChanを入れる (課題①の破棄判定用、課題②の生成判定用)

	//private int startPos = -160;			// スタート地点
	//private int goalPos = 120;			// ゴール地点
	private float posRange = 3.4f;			// アイテムを出すx方向の範囲
	private int areaUnit = 30;				// z軸を区切って、この単位でアイテムを生成する
	private int raneInterval = 15;			// レーンの間隔
	private int lastAreaIndex = 0;			// 直近でアイテム生成済みのエリア
	private int startAreaIndex = -8;		// 初期位置のエリア

	// Use this for initialization
	void Start () {
		/* 発展課題対応のためコメントアウト
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i+=15) {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (0, 10);
			if (num <= 1) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.GetComponent<RoadObjectController>().unityChan = this.unityChan;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {
				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//50%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.GetComponent<RoadObjectController>().unityChan = this.unityChan;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.GetComponent<RoadObjectController>().unityChan = this.unityChan;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		// roadのz軸の値の関係で、エリア番号が-8から始まるが、indexを0からカウントするために8を足す
		int currentAreaIndex = (int)this.unityChan.transform.position.z / this.areaUnit - this.startAreaIndex;
		//Debug.Log ("currentAreaIndex :" + currentAreaIndex);

		// 現在のエリアがアイテム生成済であれば処理終了
		if (this.lastAreaIndex >= currentAreaIndex) return;

		// アイテム生成対象エリアのz値の範囲を定義する
		this.lastAreaIndex++;
		int startPos = (currentAreaIndex + this.startAreaIndex) * this.areaUnit + currentAreaIndex * this.raneInterval;
		int goalPos = startPos + this.areaUnit;
		Debug.Log ("startPos:" + startPos + ", goalPos:" + goalPos);

		// 対象エリア内に、レーン毎にアイテムを生成する
		for (int i = startPos; i <= goalPos; i+=this.raneInterval) {
			this.GenerateLaneItems(i);
			Debug.Log ("GenerateLane i:" + i);
		}
	}

	// レーン単位のアイテム生成 (教材のまま)
	private void GenerateLaneItems(int pos) {
		//どのアイテムを出すのかをランダムに設定
		int num = Random.Range (0, 10);
		if (num <= 1) {
			//コーンをx軸方向に一直線に生成
			for (float j = -1; j <= 1; j += 0.4f) {
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.GetComponent<RoadObjectController>().unityChan = this.unityChan;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, pos);
			}
		} else {
			//レーンごとにアイテムを生成
			for (int j = -1; j < 2; j++) {
				//アイテムの種類を決める
				int item = Random.Range (1, 11);
				//アイテムを置くZ座標のオフセットをランダムに設定
				int offsetZ = Random.Range(-5, 6);
				//50%コイン配置:30%車配置:10%何もなし
				if (1 <= item && item <= 6) {
					//コインを生成
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.GetComponent<RoadObjectController>().unityChan = this.unityChan;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, pos + offsetZ);
				} else if (7 <= item && item <= 9) {
					//車を生成
					GameObject car = Instantiate (carPrefab) as GameObject;
					car.GetComponent<RoadObjectController>().unityChan = this.unityChan;
					car.transform.position = new Vector3 (posRange * j, car.transform.position.y, pos + offsetZ);
				}
			}
		}
	}
}

using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
  public GameObject igaguriPrefab;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      // イガグリオブジェクトをプレハブから生成
      GameObject igaguri = Instantiate(igaguriPrefab) as GameObject;

      // マウスポジションからRayオブジェクト（光源と光線の方向のデータを持つ）を生成する
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Vector3 worldDir = ray.direction;
      igaguri.GetComponent<IgaguriController>().Shoot(
        // 方向ベクトルをノーマライズ（長さ１にする）して、1000の力で投げる
        worldDir.normalized * 1000
      );
    }
  }
}

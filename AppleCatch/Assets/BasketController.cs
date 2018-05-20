using UnityEngine;

public class BasketController : MonoBehaviour {
  public AudioClip appleSE;
  public AudioClip bombSE;
  AudioSource aud;

  private void Start()
  {
    this.aud = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Apple")
    {
      this.aud.PlayOneShot(this.appleSE);
    }
    else
    {
      this.aud.PlayOneShot(this.bombSE);
    }
    Destroy(other.gameObject);
  }

  void Update () {
    if (Input.GetMouseButton(0))
    {
      // カメラ位置からクリック座標へ向いたRayオブジェクトを取得
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      // Rayオブジェクトが（ステージに）遮られているかを判定
      if(Physics.Raycast(ray, out hit, Mathf.Infinity))
      {
        // バスケットを移動すべき位置を取得して移動させる
        float x = Mathf.RoundToInt(hit.point.x);
        float z = Mathf.RoundToInt(hit.point.z);
        transform.position = new Vector3(x, 0.0f, z);
      }
    }
		
	}
}

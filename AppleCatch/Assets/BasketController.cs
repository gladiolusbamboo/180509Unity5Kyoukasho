using UnityEngine;

public class BasketController : MonoBehaviour {
  // りんごゲットSE
  public AudioClip appleSE;
  // 爆弾SE
  public AudioClip bombSE;
  AudioSource aud;
  GameObject director;

  private void Start()
  {
    this.director = GameObject.Find("GameDirector");
    this.aud = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter(Collider other)
  {    
    if(other.gameObject.tag == "Apple")
    {
      this.director.GetComponent<GameDirector>().GetApple();
      this.aud.PlayOneShot(this.appleSE);
    }
    else
    {
      this.director.GetComponent<GameDirector>().GetBomb();
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

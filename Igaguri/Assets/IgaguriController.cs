using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour {
  public void Shoot(Vector3 dir)
  {
    // 投げる
    GetComponent<Rigidbody>().AddForce(dir);
  }

  private void OnCollisionEnter(Collision other)
  {
    // 衝突したら重力を無視する（イガグリが的に刺さるようになる）
    GetComponent<Rigidbody>().isKinematic = true;
    GetComponent<ParticleSystem>().Play();
  }

  // Use this for initialization
  void Start () {
    // Shoot(new Vector3(0, 200, 2000));
	}
	
	// Update is called once per frame
	void Update () {
  }
}

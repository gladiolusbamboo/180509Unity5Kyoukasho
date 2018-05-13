using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
  // 回転速度
  float rotSpeed = 0;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // マウスが押されたら回転速度を設定する
    if (Input.GetMouseButton(0))
    {
      this.rotSpeed = 10;
    }

    // 回転速度分、ルーレットを回転させる
    transform.Rotate(0, 0, this.rotSpeed);

    // ルーレットを減速させる
    this.rotSpeed *= 0.96f;

  }
}

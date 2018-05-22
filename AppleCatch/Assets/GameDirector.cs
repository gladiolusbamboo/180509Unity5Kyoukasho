using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
  // タイマーUI
  GameObject timerText;
  // ポイントUI
  GameObject pointText;
  // 残り時間
  float time = 30.0f;
  // ポイント
  int point = 0;
  // アイテムジェネレーター
  GameObject generator;

  // りんごを受け取ったら+100
  public void GetApple()
  {
    this.point += 100;
  }

  // 爆弾を受け取ったら得点半分
  public void GetBomb()
  {
    this.point /= 2;
  }

  void Start()
  {
    this.timerText = GameObject.Find("Time");
    this.pointText = GameObject.Find("Point");
    this.generator = GameObject.Find("ItemGenerator");
  }

  void Update()
  {
    // 画面更新間隔を減算して残り時間を算出
    this.time -= Time.deltaTime;

    // 良い感じの難易度に設定する
    // 第一引数 : アイテム落下間隔
    // 第二引数 : 落下速度
    // 第三引数 : 爆弾が落ちてくる割合
    if (this.time < 0)
    {
      this.time = 0;
      this.generator.GetComponent<ItemGenerator>().SetParameter(float.MaxValue, 0, 0);
    }
    else if (0 <= this.time && this.time < 5)
    {
      this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
    }
    else if (5 <= this.time && this.time < 12)
    {
      this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
    }
    else if (10 <= this.time && this.time < 23)
    {
      this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
    }
    else if (20 <= this.time && this.time < 30)
    {
      this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
    }

    // UI表示
    this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
    this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
  }
}

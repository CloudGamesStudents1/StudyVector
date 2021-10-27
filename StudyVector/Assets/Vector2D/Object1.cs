using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *クリックした位置にオブジェクトを移動させるコード
 *（※ベクトルや座標は全て三次元である）
 */

public class Object1 : MonoBehaviour
{
    //クリックした位置を確保する変数
    Vector3 touchPos = new Vector3();
    //オブジェクトの位置をa,クリックした位置をbとすると、abベクトルを確保する変数
    Vector3 delta = new Vector3();
    //abベクトルの単位ベクトルを確保するベクトル
    Vector3 UnitVector = new Vector3();
    //タイマ用の変数
    double time;
    //object確保用
    GameObject obj1;

    // Start is called before the first frame update
    void Start()
    {
        //getObject
        obj1 = GameObject.Find("Object1");
    }

    // Update is called once per frame
    void Update()
    {
        //時間
        time += Time.deltaTime;

        //マウス位置取得
        if (Input.GetMouseButtonDown(0))
        {
            //マウスをクリックした座標を取得
            touchPos = Input.mousePosition;
            //abベクトルを取得(b-aより)
            delta = touchPos - obj1.transform.position;
            //単位ベクトルの取得(nomalizedで単位ベクトルを取得できる)
            UnitVector = delta.normalized;
        }

        //単位時間辺りに単位ベクトルの２倍変化（ここでは単位時間を0.01秒としている）
        if (time > 0.01)
        {
            obj1.transform.position += UnitVector * 2;
            time = 0;
        }

    }
}
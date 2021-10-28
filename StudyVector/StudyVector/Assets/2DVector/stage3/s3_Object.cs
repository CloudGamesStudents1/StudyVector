using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3_Object : MonoBehaviour
{
    //クリックした位置を確保する変数
    Vector3 touchPos = new Vector3();
    //オブジェクトの位置をa,クリックした位置をbとすると、abベクトルを確保する変数
    Vector3 delta = new Vector3();
    //abベクトルの単位ベクトルを確保するベクトル
    public Vector3 UnitVector = new Vector3();
    //タイマ用の変数
    double time;
    //object確保用
    GameObject obj;

    /*当たり判定用*/
    GameObject[] gameObjects;
    Dictionary<GameObject, bool> HitFlags = new Dictionary<GameObject, bool>();
    Vector3 VecDis = new Vector3();
    Vector3 VecZero = new Vector3();
    float distance;
    float apoint = 95;

    // Start is called before the first frame update
    void Start()
    {
        //getObject
        obj = this.gameObject;
        //Objectタグのゲームオブジェクトをすべて取得
        gameObjects = GameObject.FindGameObjectsWithTag("Object");
        //
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
            delta = touchPos - obj.transform.position;
            //単位ベクトルの取得(nomalizedで単位ベクトルを取得できる)
            UnitVector = delta.normalized;
        }

        //単位時間辺りに単位ベクトルの3倍変化（ここでは単位時間を0.01秒としている）
        if (time > 0.01)
        {
            obj.transform.position += UnitVector * 3;
            time = 0;
        }

        /*当たり判定*/
        //全てのオブジェクトを走査
        foreach (GameObject other in gameObjects)
        {
            //自分自身以外のゲームオブジェクトと距離を比較する
            if (obj != other)
            {
                //２点間のベクトル
                VecDis = obj.transform.position - other.transform.position;
                //２点間の距離
                distance = VecDis.magnitude;
                if (distance < apoint)
                {
                    UnitVector *= -1;
                }
            }
        }
    }
}

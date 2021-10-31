using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ここまで可能な限りUnityの物理機能を使わずに実装したが、かなり辛い事が分かる。
 * だが、知っておかないと、改造できないので、知っておこう。
 * ここから、Unityの機能をモリモリ使って同じ用途のものを作る。
 */

public class s7_ball : MonoBehaviour
{
    GameObject myGobj,TxtSpeed;
    Rigidbody2D myRb;
    CircleCollider2D myCol;
    Vector3 force = new Vector3();//加速度(というよりは力)
    Vector3 speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //【外部オブジェクトの取得】
        TxtSpeed = GameObject.Find("TxtSpeed");

        //【コンポーネントの追加(GUI上でも行える)】
        this.gameObject.AddComponent<Rigidbody2D>();//物理演算の搭載（2D空間の物体の動き）
        this.gameObject.AddComponent<CircleCollider2D>();//当たり判定(2Dの円の当たり判定)

        //【自分自身のオブジェクトの取得 - コードを短くするため】
        myGobj = this.gameObject;
        myRb = myGobj.GetComponent<Rigidbody2D>();
        myCol = myGobj.GetComponent<CircleCollider2D>();

        //【コンポーネントの初期設定（当たり判定とかの設定）】
        myCol.radius = 30;//当たり判定の半径
        myRb.gravityScale = 0;//重力をオフ

        //【速度や加速度などの設定】
        force.Set(0.0f,-8.0f,0.0f);//加速度

    }

    // Update is called once per frame
    void Update()
    {
        //タイマー
        timer += Time.deltaTime;

        //衝突時用に、速度を確保しておく
        speed = myRb.velocity;

        //現在の速度の表示
        TxtSpeed.GetComponent<Text>().text = ((int)speed.magnitude/8).ToString();//floatをintにして8で割り、stringにしてる

        if(timer > 0.1f)
        {
            //単位時間辺りに移動

        }

    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int Rnum = Random.Range(1,8);
        float Rspeed = Random.Range(-80.0f,80.0f);


        //if(collision.gameObject.tag == "TopDownBar")
        //{
        //    //速度を反転
        //    myRb.velocity = new Vector3(speed.x,-speed.y,0);

        //    ////加速度を反転(xに乱数を)
        //    force = new Vector3(Rspeed,-force.y,0);
        //    Debug.Log(force);
        //}
        //else if (collision.gameObject.tag == "SideBar")
        //{
        //    //速度を反転
        //    myRb.velocity = new Vector3(-speed.x, speed.y, 0);

        //    ////加速度を反転(yに乱数を)
        //    force = new Vector3(-force.x, Rspeed, 0);
        //    Debug.Log(force);
        //}

        force *= -1;

    }
}

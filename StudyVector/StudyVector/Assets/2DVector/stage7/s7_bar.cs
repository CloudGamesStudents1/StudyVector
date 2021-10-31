using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s7_bar : MonoBehaviour
{
    GameObject myGobj;
    Rigidbody2D myRb;
    BoxCollider2D myCol;
    string myTag;
    Vector3 moveDelta;

    // Start is called before the first frame update
    void Start()
    {
        //【コンポーネントの追加(GUI上でも行える)】
        this.gameObject.AddComponent<Rigidbody2D>();//物理演算の搭載（2D空間の物体の動き）
        this.gameObject.AddComponent<BoxCollider2D>();//当たり判定の追加

        //【オブジェクトの取得】
        myGobj = this.gameObject;
        myRb = myGobj.GetComponent<Rigidbody2D>();
        myCol = myGobj.GetComponent<BoxCollider2D>();

        //【コンポーネントの初期設定(当たり判定とかの設定)】
        myCol.size = myGobj.GetComponent<RectTransform>().sizeDelta;//当たり判定のサイズをオブジェクトのサイズと同じにする
        myRb.bodyType = RigidbodyType2D.Kinematic;//物体の運動をキネマティックにする（力積により位置が変動しない）
        myRb.gravityScale = 0;//重力をオフ

        //【位置とかタグとか】
        moveDelta = new Vector3(0,0,0);
        myTag = myGobj.tag;

    }

    // Update is called once per frame
    void Update()
    {
        //【barの移動】
        //xに動くかyに動くか
        if(myTag=="TopDownBar")
        {
            //マウスのx座標とリンク
            myGobj.transform.position = new Vector3(Input.mousePosition.x,myGobj.transform.position.y,0);
        }
        else if(myTag == "SideBar")
        {
            //マウスのx座標とリンク
            myGobj.transform.position = new Vector3(myGobj.transform.position.x, Input.mousePosition.y, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 以下のObject2のコードで
 * Object1と同じ動きが出来るようにVectorクラスを完成させよ
 */


public class s1_Object2 : MonoBehaviour
{
    //クリックした位置を確保する変数
    Vector touchPos = new Vector();
    //オブジェクトの現在地を確保する変数
    Vector nowPos = new Vector();
    //オブジェクトの位置をa,クリックした位置をbとすると、abベクトルを確保する変数
    Vector delta = new Vector();
    //abベクトルの単位ベクトルを確保するベクトル
    Vector UnitVector = new Vector();
    //最終的なベクトルの速度
    Vector SpeedVector = new Vector();
    //タイマ用の変数
    double time;
    //object確保用
    GameObject obj2;


    // Start is called before the first frame update
    void Start()
    {
        obj2 = GameObject.Find("Object2");
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
            touchPos.set(Input.mousePosition);
            //abベクトルを取得(b-aより)
            nowPos.set(obj2.transform.position);
            delta = Vector.Sub(touchPos, nowPos);
            //単位ベクトルの取得(nomalizedで単位ベクトルを取得できる)
            UnitVector = delta.normalized();
        }

        //単位時間辺りに単位ベクトルの3倍変化（ここでは単位時間を0.01秒としている）
        if (time > 0.01)
        {
            SpeedVector = Vector.Mult(UnitVector, 3);
            obj2.transform.position += SpeedVector.getVector3();
            time = 0;
        }

    }
}

public class Vector
{
    //フィールド(メンバ変数)
    public float x =0;
    public float y =0;
    public float z =0;

    //コンストラクタ
    public Vector()
    {

    }
    public Vector(float x,float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector(Vector v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    public Vector(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    //メソッド（メンバ関数）
    public void set(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public void set(Vector v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    public void set(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    public float magnitude()
    {
        float ans=0,temp=0;

        temp = (this.x) * (this.x) + (this.y) * (this.y) + (this.z) * (this.z);
        ans = Mathf.Sqrt(temp);

        return ans;
    }
    public Vector normalized()
    {
        Vector ans = new Vector();
        float magnitude = this.magnitude();

        ans.x = this.x / magnitude;
        ans.y = this.y / magnitude;
        ans.z = this.z / magnitude;

        return ans;
    }
    public Vector3 getVector3()
    {
        Vector3 ans = new Vector3(this.x,this.y,this.z);
        return ans;
    }


    //静的メソッド(静的メンバ関数)
    static public Vector Add(Vector v1,Vector v2)
    {
        Vector ans = new Vector();

        ans.x = v1.x + v2.x;
        ans.y = v1.y + v2.y;
        ans.z = v1.z + v2.z;

        return ans;
    }
    static public Vector Sub(Vector v1, Vector v2)
    {
        Vector ans = new Vector();

        ans.x = v1.x - v2.x;
        ans.y = v1.y - v2.y;
        ans.z = v1.z - v2.z;

        return ans;
    }
    static public Vector Mult(Vector v1, Vector v2)
    {
        Vector ans = new Vector();

        ans.x = v1.x * v2.x;
        ans.y = v1.y * v2.y;
        ans.z = v1.z * v2.z;

        return ans;
    }
    static public Vector Mult(Vector v1, float a)
    {
        Vector ans = new Vector();

        ans.x = v1.x * a;
        ans.y = v1.y * a;
        ans.z = v1.z * a;

        return ans;
    }
    static public Vector Div(Vector v1, Vector v2)
    {
        Vector ans = new Vector();

        ans.x = v1.x / v2.x;
        ans.y = v1.y / v2.y;
        ans.z = v1.z / v2.z;

        return ans;
    }
    static public Vector Div(Vector v1, float b)
    {
        Vector ans = new Vector();

        ans.x = v1.x / b;
        ans.y = v1.y / b;
        ans.z = v1.z / b;

        return ans;
    }
}
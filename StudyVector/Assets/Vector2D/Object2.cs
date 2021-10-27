using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 以下のObject2のコードで
 * Object1と同じ動きが出来るようにVectorクラスを完成させよ
 */


public class Object2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Vector
{
    //フィールド(メンバ変数)
    double x =0;
    double y =0;
    double z =0;
    //Return用

    //コンストラクタ
    Vector()
    {

    }
    Vector(double x,double y,double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    Vector(Vector v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    //メソッド（メンバ関数）
    public void set(double x, double y, double z)
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
    public double magnitude()
    {
        double ans=0,temp=0;

        temp = (this.x) * (this.x) + (this.y) * (this.y) + (this.z) * (this.z);
        ans = Math.Sqrt(temp);

        return ans;
    }
    public Vector normalized()
    {
        Vector ans = new Vector();
        double magnitude = this.magnitude();

        ans.x = this.x / magnitude;
        ans.y = this.y / magnitude;
        ans.z = this.z / magnitude;

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
    static public Vector Div(Vector v1, Vector v2)
    {
        Vector ans = new Vector();

        ans.x = v1.x / v2.x;
        ans.y = v1.y / v2.y;
        ans.z = v1.z / v2.z;

        return ans;
    }
}
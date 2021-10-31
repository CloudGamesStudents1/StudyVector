using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * stage1~5までを元に太古のテニスゲーム(っぽいもの)を作成する。
 * Unityの当たり判定や物理エンジンを使わずに作成せよ。
 */

public class s6_ball : MonoBehaviour
{
    //単位ベクトル用の変数
    Vector3 UnitVector = new Vector3();
    //タイマ用の変数
    float timer;
    //speed
    float BaseSpeed = 2;
    //ボールの数値用
    GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Number");

    }

    // Update is called once per frame
    void Update()
    {
        //時間
        timer += Time.deltaTime;

        //マウス位置取得(stage5のクラスを流用)
        UnitVector = s6_Temp.ToOnMouseUnitVector(this.gameObject, UnitVector);

        ////当たり判定(stage5のクラスを流用)
        UnitVector = s6_Temp.BallToBarCollision(this.gameObject, "Bar", UnitVector);


        //単位時間辺りに単位ベクトルのspeed倍変化(ここでは単位時間を0.01秒としている)
        if (timer > 0.01f)
        {
            this.gameObject.transform.position += UnitVector * BaseSpeed * s6_Temp.speed;
            timer = 0;
        }

        //Numberの更新
        Text.GetComponent<Text>().text = s6_Temp.speed.ToString();

    }
}

//継承して機能追加
class s6_Temp : s5_Temp
{
    //
    public static float speed=1;
    //【オーバーロード】
    /// <summary>
    /// 引数で渡したオブジェクトからクリックした位置までの単位ベクトルを取得
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    static public new Vector3 ToOnMouseUnitVector(GameObject obj, Vector3 UnitVector)
    {
        Vector3 touchPos = new Vector3();
        Vector3 delta = new Vector3();

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

        return UnitVector;
    }
    //【オーバーロード】
    /// <summary>
    /// 引数で渡したオブジェクトと引数で渡したタグを持つオブジェクトの当たり判定を行う。
    /// 自分自身とは判定をしない。
    /// 
    /// </summary>
    static public new Vector3 BallToBarCollision(GameObject obj, string tag, Vector3 UnitVector)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        float subX, subY, disX, disY;
        //オブジェクトのサイズの半分を取得（球体なので、x：横幅でもY：高さでも良い）
        float objSize = obj.GetComponent<RectTransform>().sizeDelta.x / 2;
        //衝突するほうのサイズ
        float otherSizeX, otherSizeY;

        /*当たり判定*/
        //全てのオブジェクトを走査
        foreach (GameObject other in gameObjects)
        {
            //自分自身以外のゲームオブジェクトと距離を比較する
            if (obj != other)
            {
                //２点間のX座標の差
                subX = obj.transform.position.x - other.transform.position.x;
                //２点間のY座標の差
                subY = obj.transform.position.y - other.transform.position.y;
                //X座標の距離(絶対値)
                disX = Mathf.Abs(subX);
                //Y座標の距離(絶対値)
                disY = Mathf.Abs(subY);
                //衝突するオブジェクトの幅の半分
                otherSizeX = other.GetComponent<RectTransform>().sizeDelta.x / 2;
                //同じく高さ
                otherSizeY = other.GetComponent<RectTransform>().sizeDelta.y / 2;

                //衝突した場合
                if ((disX < otherSizeX + objSize) && (disY < otherSizeY + objSize))
                {
                    //段々加速させる
                    speed += 0.2f;

                    //【反発後の単位ベクトルの作成】           
                    if (otherSizeX > otherSizeY)//幅のほうが大きい
                    {
                        //y方向に弾きかえるようにベクトルを反転
                        UnitVector.Set(UnitVector.x, -UnitVector.y, UnitVector.z);
                    }
                    else//高さの方が大きい
                    {
                        //y方向に弾きかえるようにベクトルを反転
                        UnitVector.Set(-UnitVector.x, UnitVector.y, UnitVector.z);
                    }

                    //【作成した単位ベクトルを返り値にする】
                    //オブジェクト同士が埋め込まれて止まってしまわないように
                    //当たった瞬間に変化方向に強めに動く
                    obj.transform.position += UnitVector * 3;

                    //反転させたベクトルを返す
                    return UnitVector;
                }
            }
        }
        //どれとも衝突しなければ、元のまま単位ベクトルを返す。
        return UnitVector;

    }

}

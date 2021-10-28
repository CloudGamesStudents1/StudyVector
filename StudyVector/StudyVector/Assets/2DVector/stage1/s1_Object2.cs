using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * �ȉ���Object2�̃R�[�h��
 * Object1�Ɠ����������o����悤��Vector�N���X������������
 */


public class s1_Object2 : MonoBehaviour
{
    //�N���b�N�����ʒu���m�ۂ���ϐ�
    Vector touchPos = new Vector();
    //�I�u�W�F�N�g�̌��ݒn���m�ۂ���ϐ�
    Vector nowPos = new Vector();
    //�I�u�W�F�N�g�̈ʒu��a,�N���b�N�����ʒu��b�Ƃ���ƁAab�x�N�g�����m�ۂ���ϐ�
    Vector delta = new Vector();
    //ab�x�N�g���̒P�ʃx�N�g�����m�ۂ���x�N�g��
    Vector UnitVector = new Vector();
    //�ŏI�I�ȃx�N�g���̑��x
    Vector SpeedVector = new Vector();
    //�^�C�}�p�̕ϐ�
    double time;
    //object�m�ۗp
    GameObject obj2;


    // Start is called before the first frame update
    void Start()
    {
        obj2 = GameObject.Find("Object2");
    }

    // Update is called once per frame
    void Update()
    {
        //����
        time += Time.deltaTime;

        //�}�E�X�ʒu�擾
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X���N���b�N�������W���擾
            touchPos.set(Input.mousePosition);
            //ab�x�N�g�����擾(b-a���)
            nowPos.set(obj2.transform.position);
            delta = Vector.Sub(touchPos, nowPos);
            //�P�ʃx�N�g���̎擾(nomalized�ŒP�ʃx�N�g�����擾�ł���)
            UnitVector = delta.normalized();
        }

        //�P�ʎ��ԕӂ�ɒP�ʃx�N�g����3�{�ω��i�����ł͒P�ʎ��Ԃ�0.01�b�Ƃ��Ă���j
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
    //�t�B�[���h(�����o�ϐ�)
    public float x =0;
    public float y =0;
    public float z =0;

    //�R���X�g���N�^
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

    //���\�b�h�i�����o�֐��j
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


    //�ÓI���\�b�h(�ÓI�����o�֐�)
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
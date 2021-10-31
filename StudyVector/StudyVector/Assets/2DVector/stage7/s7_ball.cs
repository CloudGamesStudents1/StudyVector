using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * �����܂ŉ\�Ȍ���Unity�̕����@�\���g�킸�Ɏ����������A���Ȃ�h������������B
 * �����A�m���Ă����Ȃ��ƁA�����ł��Ȃ��̂ŁA�m���Ă������B
 * ��������AUnity�̋@�\�����������g���ē����p�r�̂��̂����B
 */

public class s7_ball : MonoBehaviour
{
    GameObject myGobj,TxtSpeed;
    Rigidbody2D myRb;
    CircleCollider2D myCol;
    Vector3 force = new Vector3();//�����x(�Ƃ������͗�)
    Vector3 speed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�y�O���I�u�W�F�N�g�̎擾�z
        TxtSpeed = GameObject.Find("TxtSpeed");

        //�y�R���|�[�l���g�̒ǉ�(GUI��ł��s����)�z
        this.gameObject.AddComponent<Rigidbody2D>();//�������Z�̓��ځi2D��Ԃ̕��̂̓����j
        this.gameObject.AddComponent<CircleCollider2D>();//�����蔻��(2D�̉~�̓����蔻��)

        //�y�������g�̃I�u�W�F�N�g�̎擾 - �R�[�h��Z�����邽�߁z
        myGobj = this.gameObject;
        myRb = myGobj.GetComponent<Rigidbody2D>();
        myCol = myGobj.GetComponent<CircleCollider2D>();

        //�y�R���|�[�l���g�̏����ݒ�i�����蔻��Ƃ��̐ݒ�j�z
        myCol.radius = 30;//�����蔻��̔��a
        myRb.gravityScale = 0;//�d�͂��I�t

        //�y���x������x�Ȃǂ̐ݒ�z
        force.Set(0.0f,-8.0f,0.0f);//�����x

    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[
        timer += Time.deltaTime;

        //�Փˎ��p�ɁA���x���m�ۂ��Ă���
        speed = myRb.velocity;

        //���݂̑��x�̕\��
        TxtSpeed.GetComponent<Text>().text = ((int)speed.magnitude/8).ToString();//float��int�ɂ���8�Ŋ���Astring�ɂ��Ă�

        if(timer > 0.1f)
        {
            //�P�ʎ��ԕӂ�Ɉړ�

        }

    }

    //�����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int Rnum = Random.Range(1,8);
        float Rspeed = Random.Range(-80.0f,80.0f);


        //if(collision.gameObject.tag == "TopDownBar")
        //{
        //    //���x�𔽓]
        //    myRb.velocity = new Vector3(speed.x,-speed.y,0);

        //    ////�����x�𔽓](x�ɗ�����)
        //    force = new Vector3(Rspeed,-force.y,0);
        //    Debug.Log(force);
        //}
        //else if (collision.gameObject.tag == "SideBar")
        //{
        //    //���x�𔽓]
        //    myRb.velocity = new Vector3(-speed.x, speed.y, 0);

        //    ////�����x�𔽓](y�ɗ�����)
        //    force = new Vector3(-force.x, Rspeed, 0);
        //    Debug.Log(force);
        //}

        force *= -1;

    }
}

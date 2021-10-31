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
        //�y�R���|�[�l���g�̒ǉ�(GUI��ł��s����)�z
        this.gameObject.AddComponent<Rigidbody2D>();//�������Z�̓��ځi2D��Ԃ̕��̂̓����j
        this.gameObject.AddComponent<BoxCollider2D>();//�����蔻��̒ǉ�

        //�y�I�u�W�F�N�g�̎擾�z
        myGobj = this.gameObject;
        myRb = myGobj.GetComponent<Rigidbody2D>();
        myCol = myGobj.GetComponent<BoxCollider2D>();

        //�y�R���|�[�l���g�̏����ݒ�(�����蔻��Ƃ��̐ݒ�)�z
        myCol.size = myGobj.GetComponent<RectTransform>().sizeDelta;//�����蔻��̃T�C�Y���I�u�W�F�N�g�̃T�C�Y�Ɠ����ɂ���
        myRb.bodyType = RigidbodyType2D.Kinematic;//���̂̉^�����L�l�}�e�B�b�N�ɂ���i�͐ςɂ��ʒu���ϓ����Ȃ��j
        myRb.gravityScale = 0;//�d�͂��I�t

        //�y�ʒu�Ƃ��^�O�Ƃ��z
        moveDelta = new Vector3(0,0,0);
        myTag = myGobj.tag;

    }

    // Update is called once per frame
    void Update()
    {
        //�ybar�̈ړ��z
        //x�ɓ�����y�ɓ�����
        if(myTag=="TopDownBar")
        {
            //�}�E�X��x���W�ƃ����N
            myGobj.transform.position = new Vector3(Input.mousePosition.x,myGobj.transform.position.y,0);
        }
        else if(myTag == "SideBar")
        {
            //�}�E�X��x���W�ƃ����N
            myGobj.transform.position = new Vector3(myGobj.transform.position.x, Input.mousePosition.y, 0);
        }
    }
}

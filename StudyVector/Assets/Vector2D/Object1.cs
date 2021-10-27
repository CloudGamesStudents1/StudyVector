using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *�N���b�N�����ʒu�ɃI�u�W�F�N�g���ړ�������R�[�h
 *�i���x�N�g������W�͑S�ĎO�����ł���j
 */

public class Object1 : MonoBehaviour
{
    //�N���b�N�����ʒu���m�ۂ���ϐ�
    Vector3 touchPos = new Vector3();
    //�I�u�W�F�N�g�̈ʒu��a,�N���b�N�����ʒu��b�Ƃ���ƁAab�x�N�g�����m�ۂ���ϐ�
    Vector3 delta = new Vector3();
    //ab�x�N�g���̒P�ʃx�N�g�����m�ۂ���x�N�g��
    Vector3 UnitVector = new Vector3();
    //�^�C�}�p�̕ϐ�
    double time;
    //object�m�ۗp
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
        //����
        time += Time.deltaTime;

        //�}�E�X�ʒu�擾
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X���N���b�N�������W���擾
            touchPos = Input.mousePosition;
            //ab�x�N�g�����擾(b-a���)
            delta = touchPos - obj1.transform.position;
            //�P�ʃx�N�g���̎擾(nomalized�ŒP�ʃx�N�g�����擾�ł���)
            UnitVector = delta.normalized;
        }

        //�P�ʎ��ԕӂ�ɒP�ʃx�N�g���̂Q�{�ω��i�����ł͒P�ʎ��Ԃ�0.01�b�Ƃ��Ă���j
        if (time > 0.01)
        {
            obj1.transform.position += UnitVector * 2;
            time = 0;
        }

    }
}
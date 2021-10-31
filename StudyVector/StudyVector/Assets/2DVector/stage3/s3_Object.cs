using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/*
 * �����̕��̂̓����蔻��
 */

public class s3_Object : MonoBehaviour
{
    //�N���b�N�����ʒu���m�ۂ���ϐ�
    Vector3 touchPos = new Vector3();
    //�I�u�W�F�N�g�̈ʒu��a,�N���b�N�����ʒu��b�Ƃ���ƁAab�x�N�g�����m�ۂ���ϐ�
    Vector3 delta = new Vector3();
    //ab�x�N�g���̒P�ʃx�N�g�����m�ۂ���x�N�g��
    public Vector3 UnitVector = new Vector3();
    //�^�C�}�p�̕ϐ�
    double time;
    //object�m�ۗp
    GameObject obj;

    /*�����蔻��p*/
    GameObject[] gameObjects;
    Vector3 VecDis = new Vector3();
    float distance;
    float apoint = 64;

    // Start is called before the first frame update
    void Start()
    {
        //getObject
        obj = this.gameObject;
        //Object�^�O�̃Q�[���I�u�W�F�N�g�����ׂĎ擾
        gameObjects = GameObject.FindGameObjectsWithTag("Object");
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
            delta = touchPos - obj.transform.position;
            //�P�ʃx�N�g���̎擾(nomalized�ŒP�ʃx�N�g�����擾�ł���)
            UnitVector = delta.normalized;
        }

        //�P�ʎ��ԕӂ�ɒP�ʃx�N�g����3�{�ω��i�����ł͒P�ʎ��Ԃ�0.01�b�Ƃ��Ă���j
        if (time > 0.01)
        {
            obj.transform.position += UnitVector * 3;
            time = 0;
        }

        /*�����蔻��*/
        //�S�ẴI�u�W�F�N�g�𑖍�
        foreach (GameObject other in gameObjects)
        {
            //�������g�ȊO�̃Q�[���I�u�W�F�N�g�Ƌ������r����
            if (obj != other)
            {
                //�Q�_�Ԃ̃x�N�g��
                VecDis = obj.transform.position - other.transform.position;
                //�Q�_�Ԃ̋���
                distance = VecDis.magnitude;
                //
                if (distance < apoint)
                {
                    //�I�u�W�F�N�g���m�����ߍ��܂�Ď~�܂��Ă��܂�Ȃ��悤��
                    //���������u�Ԃɔ��Ε����ɋ��߂ɓ���
                    obj.transform.position += - UnitVector * 3;
                    //�e��������悤�Ƀx�N�g���𔽓]
                    UnitVector *= -1;
                }
            }
        }
    }
}

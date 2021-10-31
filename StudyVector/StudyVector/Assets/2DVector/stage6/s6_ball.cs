using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * stage1~5�܂ł����ɑ��Ẫe�j�X�Q�[��(���ۂ�����)���쐬����B
 * Unity�̓����蔻��╨���G���W�����g�킸�ɍ쐬����B
 */

public class s6_ball : MonoBehaviour
{
    //�P�ʃx�N�g���p�̕ϐ�
    Vector3 UnitVector = new Vector3();
    //�^�C�}�p�̕ϐ�
    float timer;
    //speed
    float BaseSpeed = 2;
    //�{�[���̐��l�p
    GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.Find("Number");

    }

    // Update is called once per frame
    void Update()
    {
        //����
        timer += Time.deltaTime;

        //�}�E�X�ʒu�擾(stage5�̃N���X�𗬗p)
        UnitVector = s6_Temp.ToOnMouseUnitVector(this.gameObject, UnitVector);

        ////�����蔻��(stage5�̃N���X�𗬗p)
        UnitVector = s6_Temp.BallToBarCollision(this.gameObject, "Bar", UnitVector);


        //�P�ʎ��ԕӂ�ɒP�ʃx�N�g����speed�{�ω�(�����ł͒P�ʎ��Ԃ�0.01�b�Ƃ��Ă���)
        if (timer > 0.01f)
        {
            this.gameObject.transform.position += UnitVector * BaseSpeed * s6_Temp.speed;
            timer = 0;
        }

        //Number�̍X�V
        Text.GetComponent<Text>().text = s6_Temp.speed.ToString();

    }
}

//�p�����ċ@�\�ǉ�
class s6_Temp : s5_Temp
{
    //
    public static float speed=1;
    //�y�I�[�o�[���[�h�z
    /// <summary>
    /// �����œn�����I�u�W�F�N�g����N���b�N�����ʒu�܂ł̒P�ʃx�N�g�����擾
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    static public new Vector3 ToOnMouseUnitVector(GameObject obj, Vector3 UnitVector)
    {
        Vector3 touchPos = new Vector3();
        Vector3 delta = new Vector3();

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

        return UnitVector;
    }
    //�y�I�[�o�[���[�h�z
    /// <summary>
    /// �����œn�����I�u�W�F�N�g�ƈ����œn�����^�O�����I�u�W�F�N�g�̓����蔻����s���B
    /// �������g�Ƃ͔�������Ȃ��B
    /// 
    /// </summary>
    static public new Vector3 BallToBarCollision(GameObject obj, string tag, Vector3 UnitVector)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        float subX, subY, disX, disY;
        //�I�u�W�F�N�g�̃T�C�Y�̔������擾�i���̂Ȃ̂ŁAx�F�����ł�Y�F�����ł��ǂ��j
        float objSize = obj.GetComponent<RectTransform>().sizeDelta.x / 2;
        //�Փ˂���ق��̃T�C�Y
        float otherSizeX, otherSizeY;

        /*�����蔻��*/
        //�S�ẴI�u�W�F�N�g�𑖍�
        foreach (GameObject other in gameObjects)
        {
            //�������g�ȊO�̃Q�[���I�u�W�F�N�g�Ƌ������r����
            if (obj != other)
            {
                //�Q�_�Ԃ�X���W�̍�
                subX = obj.transform.position.x - other.transform.position.x;
                //�Q�_�Ԃ�Y���W�̍�
                subY = obj.transform.position.y - other.transform.position.y;
                //X���W�̋���(��Βl)
                disX = Mathf.Abs(subX);
                //Y���W�̋���(��Βl)
                disY = Mathf.Abs(subY);
                //�Փ˂���I�u�W�F�N�g�̕��̔���
                otherSizeX = other.GetComponent<RectTransform>().sizeDelta.x / 2;
                //����������
                otherSizeY = other.GetComponent<RectTransform>().sizeDelta.y / 2;

                //�Փ˂����ꍇ
                if ((disX < otherSizeX + objSize) && (disY < otherSizeY + objSize))
                {
                    //�i�X����������
                    speed += 0.2f;

                    //�y������̒P�ʃx�N�g���̍쐬�z           
                    if (otherSizeX > otherSizeY)//���̂ق����傫��
                    {
                        //y�����ɒe��������悤�Ƀx�N�g���𔽓]
                        UnitVector.Set(UnitVector.x, -UnitVector.y, UnitVector.z);
                    }
                    else//�����̕����傫��
                    {
                        //y�����ɒe��������悤�Ƀx�N�g���𔽓]
                        UnitVector.Set(-UnitVector.x, UnitVector.y, UnitVector.z);
                    }

                    //�y�쐬�����P�ʃx�N�g����Ԃ�l�ɂ���z
                    //�I�u�W�F�N�g���m�����ߍ��܂�Ď~�܂��Ă��܂�Ȃ��悤��
                    //���������u�Ԃɕω������ɋ��߂ɓ���
                    obj.transform.position += UnitVector * 3;

                    //���]�������x�N�g����Ԃ�
                    return UnitVector;
                }
            }
        }
        //�ǂ�Ƃ��Փ˂��Ȃ���΁A���̂܂ܒP�ʃx�N�g����Ԃ��B
        return UnitVector;

    }

}

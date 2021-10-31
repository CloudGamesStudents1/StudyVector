using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �y�{�[���̓����蔻��𒲐�����z
 * stage4�܂łł��������Ē��˕Ԃ�͂��邪�A�΂߂ɓ������Ă����̂܂ܗ��������ɒ��˕Ԃ�s���R�ł���B
 * �����̗͐ς̎����x�N�g����p���čs���Όv�Z�ł��邪�A�������ʓ|�ł���A���������Â炢�B
 * �͂̕ω��͍l�����A�x�N�g���̕ω��̂݁i�������G�c�Ɂj���l���āA�ȒP�ȃx�N�g���̏Փˉ^������������B
 * ��̓I�ɂ́AY�����łԂ������ꍇ�́AX�����̃x�N�g���͂��̂܂܂�Y�����݂̂𔽓]�B
 * X�����łԂ������ꍇ�́AY�����̃x�N�g���͂��̂܂܂�X�����݂̂̂𔽓]������B
 * �i���ӁF�����ō쐬���������蔻��͂Ȃ񂿂���ē����蔻��ł��B������ꍇ�ɑΉ��ł�����̂ł͂���܂���B�j
 * �i���Ƃ��΁A�����`�̕����������ʂ���Փ˂����ꍇ�A����ɔ��˂��܂���B�j
 */

public class s5_ball : MonoBehaviour
{
    //�P�ʃx�N�g���p�̕ϐ�
    Vector3 UnitVector = new Vector3();
    //�^�C�}�p�̕ϐ�
    float timer;
    //speed
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //����
        timer += Time.deltaTime;

        //�}�E�X�ʒu�擾
        UnitVector = s5_Temp.ToOnMouseUnitVector(this.gameObject, UnitVector);

        ////�����蔻��
        UnitVector = s5_Temp.BallToBarCollision(this.gameObject, "Bar", UnitVector);

        //�P�ʎ��ԕӂ�ɒP�ʃx�N�g����speed�{�ω�(�����ł͒P�ʎ��Ԃ�0.01�b�Ƃ��Ă���)
        if (timer > 0.01f)
        {
            this.gameObject.transform.position += UnitVector * speed;
            timer = 0;
        }

    }
}


/*�ȉ��A����N���X�Ǝ��상�\�b�h*/
/// <summary>
/// �K���Ɏ��삵�����\�b�h���܂Ƃ߂��N���X�B
/// ���O���v�����Ȃ��̂ŁATemp�ŁB
/// </summary>
class s5_Temp
{
    /// <summary>
    /// �����œn�����I�u�W�F�N�g����N���b�N�����ʒu�܂ł̒P�ʃx�N�g�����擾
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    static public Vector3 ToOnMouseUnitVector(GameObject obj, Vector3 UnitVector)
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
    /// <summary>
    /// �����œn�����I�u�W�F�N�g�ƈ����œn�����^�O�����I�u�W�F�N�g�̓����蔻����s���B
    /// �������g�Ƃ͔�������Ȃ��B
    /// 
    /// </summary>
    static public Vector3 BallToBarCollision(GameObject obj, string tag, Vector3 UnitVector)
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

                    Debug.Log(UnitVector);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s6_bar : MonoBehaviour
{
    //�P�ʃx�N�g���p�̕ϐ�
    Vector3 UnitVector = new Vector3();
    //�T�C�Y�Ƃ�
    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        width = this.GetComponent<RectTransform>().sizeDelta.x;
        height = this.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (width > height)
        {
            UnitVector.Set(Input.mousePosition.x, this.gameObject.transform.position.y, 0);
            this.gameObject.transform.position = UnitVector;

        }
        else
        {
            UnitVector.Set(this.gameObject.transform.position.x, Input.mousePosition.y, 0);
            this.gameObject.transform.position = UnitVector;
        }
        
    }
}

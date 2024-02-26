using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    // Start is called before the first frame update
    //�@�J�������ɂ��邩�ǂ���
    private bool isInsideCamera;
    private float elapsedTime;
    //�@�o�ߎ��ԕ\���e�L�X�g

    // Update is called once per frame
    void Update()
    {
        if (isInsideCamera)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    //�@�J��������O�ꂽ
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }

    //�@�J�������ɓ�����
    private void OnBecameVisible()
    {
        isInsideCamera = true;
        
    }
}

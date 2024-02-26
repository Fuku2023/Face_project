using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    // Start is called before the first frame update
    //　カメラ内にいるかどうか
    private bool isInsideCamera;
    private float elapsedTime;
    //　経過時間表示テキスト

    // Update is called once per frame
    void Update()
    {
        if (isInsideCamera)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    //　カメラから外れた
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }

    //　カメラ内に入った
    private void OnBecameVisible()
    {
        isInsideCamera = true;
        
    }
}

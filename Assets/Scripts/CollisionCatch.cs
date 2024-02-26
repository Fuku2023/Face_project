using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.Animations;

public class CollisionCatch : MonoBehaviour
{
    private NavMeshAgent _nav;
    private Animator _anim;
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //プレイヤーがEmptyのコライダーに入ったときの処理
            Debug.Log("侵入");
            if (_nav.isOnOffMeshLink)
            {
                //後ろから幽霊が覗き込んで来るアニメー
                // //3.5秒後に幽霊ワープション
                _anim.SetBool("Look", true);
                _nav.CompleteOffMeshLink();
                Invoke("Tereport", 3.5f);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Restart());
            //プレイヤーがEmptyのコライダーから出た時の処理
            Debug.Log("脱出");
        }
    }

    public IEnumerator Restart()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(3.0f);

        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    private void Tereport()
    {
        //ワープさせる位置
        transform.position = new Vector3(1.5f, -1.4f, 16f);
    }
}

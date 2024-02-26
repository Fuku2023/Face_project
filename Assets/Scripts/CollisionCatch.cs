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
            //�v���C���[��Empty�̃R���C�_�[�ɓ������Ƃ��̏���
            Debug.Log("�N��");
            if (_nav.isOnOffMeshLink)
            {
                //��납��H�삪�`������ŗ���A�j���[
                // //3.5�b��ɗH�샏�[�v�V����
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
            //�v���C���[��Empty�̃R���C�_�[����o�����̏���
            Debug.Log("�E�o");
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
        //���[�v������ʒu
        transform.position = new Vector3(1.5f, -1.4f, 16f);
    }
}

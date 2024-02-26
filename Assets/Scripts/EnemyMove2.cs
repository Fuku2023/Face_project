using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove2 : MonoBehaviour
{
    //�ǂ�������Ώۂ̍��W���
    [SerializeField] private Transform _target;
    //�G�[�W�F���g���L���b�V�����Ă����p
    private NavMeshAgent _agent;
    private bool _direction = false;
    private float _delay = 3.5f;
    // ���g��Transform
    [SerializeField] private Transform _self;
    // �^�[�Q�b�g��Transform
    [SerializeField] private Transform _Rtarget;
    // �O���̊�ƂȂ郍�[�J����ԃx�N�g��
    [SerializeField] private Vector3 _forward = Vector3.forward;

    void Start()
    {
        //Nav Mesh Agent�R���|�[�l���g���擾
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_direction == true)
        {
            Vector3 targetPos = _Rtarget.transform.position;
            // �^�[�Q�b�g��Y���W�������Ɠ����ɂ��邱�Ƃ�2�����ɐ�������B
            targetPos.y = this.gameObject.transform.position.y;
            this.gameObject.transform.LookAt(targetPos);
        }
        if (_direction == false)
        {
            //�G�[�W�F���g�̍s��Ƀv���C���[�̍��W��ݒ�
            _agent.destination = _target.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            _direction = true;
            Invoke("Mukifalse", _delay);
        }
    }

    private void Mukifalse()
    {
        _direction = false;
    }
}

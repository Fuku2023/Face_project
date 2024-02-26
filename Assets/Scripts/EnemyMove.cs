using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    //�����ʒu
    private Vector3 _startpos;
    //�ړI�n
    private Vector3 _destination;
    //���񂷂�ʒu
    [SerializeField]
    private Transform[] _PatrolPos;
    //���ɏ��񂷂�ʒu
    private int _nowPatrolPos = 0;

    private void OnEnable()
    {
        //�����ʒu��ݒ�
        _startpos = transform.position;
        //����n�_��ݒ�
        var _patrolParent = GameObject.Find("SlenderPatrolPosition");
        //_PatrolPos = new Transform[_patrolParent.transform.childCount];
        //for (int i = 0; i < _patrolParent.transform.childCount; i++)
        //{
        //    _PatrolPos[i] = _patrolParent.transform.GetChild(i);
        //}
    }
    public void CreateRamdomPosition()
    {
        //�����_����Vector2�̒l�𓾂�
        var _randDestination = Random.insideUnitCircle * 8;
        //���ݒn�Ƀ����_���Ȉʒu�𑫂��ĖړI�n�ɂ���
        SetDestination(_startpos + new Vector3(_randDestination.x, 0, _randDestination.y));
    }


    //����n�_�����ɉ��
    public void SetNextPosition()
    {
        SetDestination(_PatrolPos[_nowPatrolPos].position);
        _nowPatrolPos++;
        if (_nowPatrolPos >= _PatrolPos.Length)
        {
            _nowPatrolPos = 0;
        }
    }

    //�ړI�n��ݒ肷��
    public void SetDestination(Vector3 position)
    {
        _destination = position;
    }
    public Vector3 GetDestination()
    {
        return _destination;
    }

}

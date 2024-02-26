using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    //初期位置
    private Vector3 _startpos;
    //目的地
    private Vector3 _destination;
    //巡回する位置
    [SerializeField]
    private Transform[] _PatrolPos;
    //次に巡回する位置
    private int _nowPatrolPos = 0;

    private void OnEnable()
    {
        //初期位置を設定
        _startpos = transform.position;
        //巡回地点を設定
        var _patrolParent = GameObject.Find("SlenderPatrolPosition");
        //_PatrolPos = new Transform[_patrolParent.transform.childCount];
        //for (int i = 0; i < _patrolParent.transform.childCount; i++)
        //{
        //    _PatrolPos[i] = _patrolParent.transform.GetChild(i);
        //}
    }
    public void CreateRamdomPosition()
    {
        //ランダムなVector2の値を得る
        var _randDestination = Random.insideUnitCircle * 8;
        //現在地にランダムな位置を足して目的地にする
        SetDestination(_startpos + new Vector3(_randDestination.x, 0, _randDestination.y));
    }


    //巡回地点を順に回る
    public void SetNextPosition()
    {
        SetDestination(_PatrolPos[_nowPatrolPos].position);
        _nowPatrolPos++;
        if (_nowPatrolPos >= _PatrolPos.Length)
        {
            _nowPatrolPos = 0;
        }
    }

    //目的地を設定する
    public void SetDestination(Vector3 position)
    {
        _destination = position;
    }
    public Vector3 GetDestination()
    {
        return _destination;
    }

}

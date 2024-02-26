using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove2 : MonoBehaviour
{
    //追いかける対象の座標情報
    [SerializeField] private Transform _target;
    //エージェントをキャッシュしておく用
    private NavMeshAgent _agent;
    private bool _direction = false;
    private float _delay = 3.5f;
    // 自身のTransform
    [SerializeField] private Transform _self;
    // ターゲットのTransform
    [SerializeField] private Transform _Rtarget;
    // 前方の基準となるローカル空間ベクトル
    [SerializeField] private Vector3 _forward = Vector3.forward;

    void Start()
    {
        //Nav Mesh Agentコンポーネントを取得
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_direction == true)
        {
            Vector3 targetPos = _Rtarget.transform.position;
            // ターゲットのY座標を自分と同じにすることで2次元に制限する。
            targetPos.y = this.gameObject.transform.position.y;
            this.gameObject.transform.LookAt(targetPos);
        }
        if (_direction == false)
        {
            //エージェントの行先にプレイヤーの座標を設定
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

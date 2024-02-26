using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterNavigation : MonoBehaviour
{
    public float m_speed = 2.0f; //移動速度
    public float m_rotation;     // 回転速度    
    public Transform m_target;    //敵を追いかけるオブジェクト
    NavMeshAgent m_agent;

    private static Vector3 m_position;
    private float m_patroldistance;
    private float m_targetdistance;

    void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        DoPatrol();  
    }
    private void Update()
    {
        m_patroldistance = Vector3.Distance(this.m_agent.transform.position, m_position);
        m_targetdistance = Vector3.Distance(this.m_agent.transform.position, m_target.transform.position);

        //Playerとの距離が30f以下になると逃げる
        if(m_targetdistance <= 30f)
        {
            Move();
        }
        else if (m_patroldistance<15f)
        {
            DoPatrol();
        }
        else
        {
            m_agent.SetDestination(m_position);
        }
    }
   void Move()
    {
        //ターゲットの方向を求める
        Vector3 vec = transform.position - m_target.position;  //m_target.position - transform.position;
        //ターゲットの方を向く
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), m_rotation);
        //進むほうへ移動
        transform.Translate(Vector3.forward * m_speed);
    }
    public void DoPatrol()
    {
        var x = Random.Range(-50.0f, 50.0f);
        var z = Random.Range(-50.0f, 50.0f);
        m_position = new Vector3(x, 0, z);
        m_agent.SetDestination(m_position);
    }
}

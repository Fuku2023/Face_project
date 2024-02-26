using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterNavigation : MonoBehaviour
{
    public float m_speed = 2.0f; //�ړ����x
    public float m_rotation;     // ��]���x    
    public Transform m_target;    //�G��ǂ�������I�u�W�F�N�g
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

        //Player�Ƃ̋�����30f�ȉ��ɂȂ�Ɠ�����
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
        //�^�[�Q�b�g�̕��������߂�
        Vector3 vec = transform.position - m_target.position;  //m_target.position - transform.position;
        //�^�[�Q�b�g�̕�������
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), m_rotation);
        //�i�ނق��ֈړ�
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

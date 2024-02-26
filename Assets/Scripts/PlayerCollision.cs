using UnityEngine;
using UnityEngine.AI;

public class PlayerCollision : MonoBehaviour
{
    private NavMeshAgent _nav;
    private float _posiyion_x = 1.5f;
    private float _posiyion_y = -1.4f;
    private float _posiyion_z = 16f;
    [SerializeField] private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _nav = GetComponentInParent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[��Empty�̃R���C�_�[�ɓ������Ƃ��̏���
        if (other.tag == "Player")
        {
            //�H��̃X�s�[�h��0.1�グ��
            _nav.speed += 0.1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //�v���C���[��Empty�̃R���C�_�[����o�����̏���
        if (other.tag == "Player")
        {
            //�H��̃X�s�[�h��0.1������
            _nav.speed -= 0.1f;
        }
    }
    private void Tereport()
    {
        _anim.SetBool("Walk", true);
        //���[�v������ʒu
        transform.position = new Vector3(_posiyion_x, _posiyion_y, _posiyion_z);
    }
}

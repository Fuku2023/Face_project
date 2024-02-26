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
        //プレイヤーがEmptyのコライダーに入ったときの処理
        if (other.tag == "Player")
        {
            //幽霊のスピードを0.1上げる
            _nav.speed += 0.1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //プレイヤーがEmptyのコライダーから出た時の処理
        if (other.tag == "Player")
        {
            //幽霊のスピードを0.1下げる
            _nav.speed -= 0.1f;
        }
    }
    private void Tereport()
    {
        _anim.SetBool("Walk", true);
        //ワープさせる位置
        transform.position = new Vector3(_posiyion_x, _posiyion_y, _posiyion_z);
    }
}

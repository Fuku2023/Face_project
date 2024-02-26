using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnemyChase : MonoBehaviour
{
    //幽霊のアニメーション
    [SerializeField] private Animator _anim;
    public GameObject _controllerObj;
    public ContinuousMoveProviderBase _controller;
    public float _displayDelay = 3.5f;
    private float _enemyMove = 1.9f;
    private float _delay = 3.5f;
    private float _position_x = 1.5f;
    private float _position_y = -1.4f;
    private float _position_z = 16f;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _controller = _controllerObj.GetComponent<ContinuousMoveProviderBase>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //幽霊が後ろから見てくるアニメーション
            _anim.SetBool("Look", true);
            //3.5秒後に幽霊ワープ
            Invoke("Tereport", _delay);
            if (_controller.moveSpeed > 0)
            {
                // スピード0にする
                _controller.moveSpeed = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_controller.moveSpeed == 0)
            {
                _controller.moveSpeed = _enemyMove;
            }
        }
    }

    private void Tereport()
    {
        _anim.SetBool("Look", false);
        //ワープさせる位置
        transform.position = new Vector3(_position_x, _position_y, _position_z);
    }

}

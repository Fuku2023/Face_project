using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCast : MonoBehaviour
{
    ///���C�L���X�g�̒���
    [SerializeField]
    private float _raycastLength;
    //�H��̓��ɗ��L���X�g���������ăQ�[���I�[�o�[�ɂȂ�܂ł̎���
    private float _limitTime=0.2f;
    //���C�L���X�g�Ŕ�������R���C�_�[
    [SerializeField]
    private Collider _slenderCollider;
    //���C�L���X�g���H��̊�ɓ������Ă���̎���
    private float _gameoverTime = default;
    //���C�L���X�g��`
    [SerializeField]
    private float _raycast;
    [SerializeField]
    private float _raycast2;
    [SerializeField]
    private float _raycast3;
    [SerializeField]
    private float _raycast4;
    //�t�F�[�h�p�l���̎擾
    public GameObject _Panelfade;
    //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    Image _fadealpha;
    //�p�l����alpha�l�擾�ϐ�
    private float _alpha;

    private void Start()
    {
        //�p�l���̃C���[�W�擾
        _fadealpha = _Panelfade.GetComponent<Image>();
        //�p�l����alpha�l���擾
        _alpha = _fadealpha.color.a;
    }

    private void Update()
    {
        //���C�L���X�g�𔭎�(4�{)
        RaycastHit hit;
        Physics.Raycast(
            this.transform.position+Vector3.right*_raycast,
            transform.forward,
            out hit,
            _raycastLength);

        RaycastHit hit2;
        Physics.Raycast(
           this.transform.position+Vector3.left*_raycast2,
           transform.forward,
           out hit2,
           _raycastLength);

        RaycastHit hit3;
        Physics.Raycast(
          this.transform.position + Vector3.up * _raycast3,
          transform.forward,
          out hit3,
          _raycastLength);

        RaycastHit hit4;
        Physics.Raycast(
          this.transform.position + Vector3.down * _raycast4,
          transform.forward,
          out hit4,
          _raycastLength);

        //���₷���悤�Ƀ��C�����o��
        Debug.DrawRay(this.transform.position+Vector3.right * _raycast,
            transform.forward * _raycastLength,
            Color.red);

        Debug.DrawRay(this.transform.position + Vector3.left * _raycast2,
            transform.forward * _raycastLength,
            Color.red);

        Debug.DrawRay(this.transform.position + Vector3.up * _raycast3,
            transform.forward * _raycastLength,
            Color.red);

        Debug.DrawRay(this.transform.position + Vector3.down * _raycast4,
            transform.forward * _raycastLength,
            Color.red);
        //���C���H��̓��̃R���C�_�[�ɂ��������̏���
        if (hit.collider == _slenderCollider||
            hit2.collider == _slenderCollider||
            hit3.collider == _slenderCollider||
            hit4.collider == _slenderCollider
            )
        {
            _gameoverTime = +_gameoverTime + Time.deltaTime;
        }
        //�H��̓��ɓ��Ă��ĂȂ��Ƃ�
        else
        {
            _gameoverTime = 0;
        }

        //���C�L���X�g����莞�ԗH��̓��ɂ���������
        if (_gameoverTime > _limitTime)
        {
            FadeOut();                   
            GameOverScean();            
        }
    }

    private void GameOverScean()
    {
        //�Q�[���I�[�o�[��ʂɑJ��
        SceneManager.LoadScene("GameOver");
    }
    void FadeOut()
    {
        _alpha += 255f;
        _fadealpha.color = new Color(255, 0, 0, _alpha);

    }

}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCast : MonoBehaviour
{
    ///レイキャストの長さ
    [SerializeField]
    private float _raycastLength;
    //幽霊の頭に来キャストが当たってゲームオーバーになるまでの時間
    private float _limitTime=0.2f;
    //レイキャストで判定を取るコライダー
    [SerializeField]
    private Collider _slenderCollider;
    //レイキャストが幽霊の顔に当たってからの時間
    private float _gameoverTime = default;
    //レイキャスト定義
    [SerializeField]
    private float _raycast;
    [SerializeField]
    private float _raycast2;
    [SerializeField]
    private float _raycast3;
    [SerializeField]
    private float _raycast4;
    //フェードパネルの取得
    public GameObject _Panelfade;
    //フェードパネルのイメージ取得変数
    Image _fadealpha;
    //パネルのalpha値取得変数
    private float _alpha;

    private void Start()
    {
        //パネルのイメージ取得
        _fadealpha = _Panelfade.GetComponent<Image>();
        //パネルのalpha値を取得
        _alpha = _fadealpha.color.a;
    }

    private void Update()
    {
        //レイキャストを発射(4本)
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

        //見やすいようにレイを視覚化
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
        //レイが幽霊の頭のコライダーにあった時の処理
        if (hit.collider == _slenderCollider||
            hit2.collider == _slenderCollider||
            hit3.collider == _slenderCollider||
            hit4.collider == _slenderCollider
            )
        {
            _gameoverTime = +_gameoverTime + Time.deltaTime;
        }
        //幽霊の頭に当てってないとき
        else
        {
            _gameoverTime = 0;
        }

        //レイキャストが一定時間幽霊の頭にあたったら
        if (_gameoverTime > _limitTime)
        {
            FadeOut();                   
            GameOverScean();            
        }
    }

    private void GameOverScean()
    {
        //ゲームオーバー画面に遷移
        SceneManager.LoadScene("GameOver");
    }
    void FadeOut()
    {
        _alpha += 255f;
        _fadealpha.color = new Color(255, 0, 0, _alpha);

    }

}
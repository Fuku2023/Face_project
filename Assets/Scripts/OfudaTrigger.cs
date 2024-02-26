using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OfudaTrigger : MonoBehaviour
{
    [SerializeField]
    private int _ofudasuu = 0;
    [SerializeField]
    Text _ofudatext;

    [SerializeField]
    private float _changetime;

    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾
    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    private float alpha;           //�p�l����alpha�l�擾�ϐ�
    private bool fadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _ofudatext.text = "0";
        _changetime = 0.0f;
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;            //�p�l����alpha�l���擾
    }

    // Update is called once per frame
    void Update()
    {

        if(_ofudasuu == 3)
        {
            _changetime += Time.deltaTime;
            if (_changetime >= 2.0f)
            {
                FadeOut();
                GameClearScean();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Ofuda" && _ofudasuu <5)
        {
            _ofudasuu += 1;
        }
        SetScore();
    }

    private void SetScore()
    {
        _ofudatext.text = string.Format("{0}", _ofudasuu);
    }

    void FadeOut()
    {
        alpha += 255f;
        fadealpha.color = new Color(255, 255, 255, alpha);

    }
    private void GameClearScean()
    {
        //�Q�[���I�[�o�[��ʂɑJ��
        SceneManager.LoadScene("GameClear");
    }
}

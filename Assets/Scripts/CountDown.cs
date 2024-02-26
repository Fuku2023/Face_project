using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timerText;
    float time;

    private bool _animstart;
    //�J�E���g�_�E��
    public float remaining = 150f; 
    public GameObject _lightObje;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;            //�p�l����alpha�l���擾

    }
    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    [SerializeField] private GameObject _obj1;
    [SerializeField] private GameObject _obj2;
    [SerializeField] private GameObject _obj3;
    [SerializeField] private GameObject _obj4;
    [SerializeField] private GameObject _obj5;
    [SerializeField] private GameObject _obj6;
    [SerializeField] private GameObject _obj7;
    [SerializeField] private GameObject _obj8;
    [SerializeField] private GameObject _obj9;
    [SerializeField] private GameObject _obj10;
    [SerializeField] private GameObject _obj11;
    [SerializeField] private GameObject _obj12;
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;
    [SerializeField] private Text _text4;

    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾
    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    private float alpha;           //�p�l����alpha�l�擾�ϐ�
    private bool fadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    //void Update()
    //{
    //    //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
    //    time += Time.deltaTime;
    //    //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
    //    int remaining = timeLimit - (int)time;
    //    //timerText���X�V���Ă���
    //    timerText.text = $"{remaining.ToString("D3")}";
    //    if(remaining == 0f)
    //    {
    //        //�Q�[���N���A
    //        SceneManager.LoadScene("GameClear");
    //    }
    //}

    //private void 
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        this.remaining -= Time.deltaTime;

        //���Ԃ�\������
        //timeText.text = countdown.ToString("f1") + "�b";
        //�t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        //time�ϐ���int�^�ɂ��������Ԃ������������int�^��limit�ϐ��ɑ��
        int remaining = timeLimit - (int)time;
        //timerText���X�V���Ă���
        timerText.text = $"{remaining.ToString("D3")}" + "�b";


        //������G���A�ǉ��Ǝc��^�C���\��
        //countdown��120�ȉ��ɂȂ������Ƀg�C���ǉ�,120�b�ƕ\��
        if (this.remaining <= 151)
        {
            _anim.SetBool("textmove", true);
            _anim.SetBool("textmove2", true);
        }

        if (this.remaining <= 122)
        {
            _obj1.gameObject.SetActive(false);
            _obj2.gameObject.SetActive(false);
            _anim.SetBool("textmove", false);
            _anim.SetBool("textmove2", false);
        }

        //countdown��100�ȉ��ɂȂ������ɗ��Ȏ��ǉ�,100�b�ƕ\��
        if (this.remaining <= 100)
        {
            _obj3.gameObject.SetActive(false);
            _obj4.gameObject.SetActive(false);
            _obj5.gameObject.SetActive(false);
            _obj6.gameObject.SetActive(false);
        }

        //countdown��60�ȉ��ɂȂ������ɍZ�����ǉ�,60�b�ƕ\��
        if (this.remaining <= 61)
        {
            _obj7.gameObject.SetActive(false);
            _obj8.gameObject.SetActive(false);
            _anim.SetBool("textmove", true);
            _anim.SetBool("textmove2", true);
        }

        //countdown��30�ȉ��ɂȂ������Ɍ��֒ǉ�,30�b�ƕ\��,������Ԃ�����
        if (this.remaining <= 31)
        {
            _obj9.gameObject.SetActive(false);
            _obj10.gameObject.SetActive(false);
            _obj11.gameObject.SetActive(false);
            _obj12.gameObject.SetActive(false);
            _anim.SetBool("textmove", false);
            _anim.SetBool("textmove2", false);

            _lightObje.SetActive(true);

        }

        if (this.remaining <= 11)
        {
            _anim.SetBool("textmove", true);
            _anim.SetBool("textmove2", true);
        }



        //countdown��0�ȉ��ɂȂ������ɃQ�[���I�[�o�[
        if (this.remaining <= 0)
        {
            FadeOut();
            GameOverScean();
        }
    }
    void FadeOut()
    {
        alpha += 0f;
        fadealpha.color = new Color(0, 0, 0, alpha);

    }
    private void GameOverScean()
    {
        //�Q�[���I�[�o�[��ʂɑJ��
        SceneManager.LoadScene("GameOver");
    }
}

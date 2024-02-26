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
    //カウントダウン
    public float remaining = 150f; 
    public GameObject _lightObje;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;            //パネルのalpha値を取得

    }
    //時間を表示するText型の変数
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

    public GameObject Panelfade;   //フェードパネルの取得
    Image fadealpha;               //フェードパネルのイメージ取得変数
    private float alpha;           //パネルのalpha値取得変数
    private bool fadeout;          //フェードアウトのフラグ変数

    //void Update()
    //{
    //    //フレーム毎の経過時間をtime変数に追加
    //    time += Time.deltaTime;
    //    //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
    //    int remaining = timeLimit - (int)time;
    //    //timerTextを更新していく
    //    timerText.text = $"{remaining.ToString("D3")}";
    //    if(remaining == 0f)
    //    {
    //        //ゲームクリア
    //        SceneManager.LoadScene("GameClear");
    //    }
    //}

    //private void 
    void Update()
    {
        //時間をカウントダウンする
        this.remaining -= Time.deltaTime;

        //時間を表示する
        //timeText.text = countdown.ToString("f1") + "秒";
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining = timeLimit - (int)time;
        //timerTextを更新していく
        timerText.text = $"{remaining.ToString("D3")}" + "秒";


        //逃げるエリア追加と残りタイム表示
        //countdownが120以下になった時にトイレ追加,120秒と表示
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

        //countdownが100以下になった時に理科室追加,100秒と表示
        if (this.remaining <= 100)
        {
            _obj3.gameObject.SetActive(false);
            _obj4.gameObject.SetActive(false);
            _obj5.gameObject.SetActive(false);
            _obj6.gameObject.SetActive(false);
        }

        //countdownが60以下になった時に校長室追加,60秒と表示
        if (this.remaining <= 61)
        {
            _obj7.gameObject.SetActive(false);
            _obj8.gameObject.SetActive(false);
            _anim.SetBool("textmove", true);
            _anim.SetBool("textmove2", true);
        }

        //countdownが30以下になった時に玄関追加,30秒と表示,部屋を赤くする
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



        //countdownが0以下になった時にゲームオーバー
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
        //ゲームオーバー画面に遷移
        SceneManager.LoadScene("GameOver");
    }
}

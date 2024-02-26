using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] int timeLimit;
    float time;
    public float remaining = 150f;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioSource audioSource2;
    [SerializeField]
    AudioSource audioSource3;
    [SerializeField]
    AudioSource audioSource4;
    [SerializeField]
    AudioSource audioSource5;
    [SerializeField]
    AudioSource audioSource6;
    [SerializeField]
    AudioSource audioSource7;
    [SerializeField]
    AudioSource audioSource8;
    [SerializeField]
    AudioSource audioSource9;
    [SerializeField]
    AudioSource audioSource10;
    [SerializeField]
    AudioSource audioSource11;
    [SerializeField]
    AudioSource audioSource12;
    [SerializeField]
    AudioSource audioSource13;
    //[SerializeField] private GameObject _obj1;
    //[SerializeField] private GameObject _obj2;
    //[SerializeField] private GameObject _obj3;
    //[SerializeField] private GameObject _obj4;
    //[SerializeField] private GameObject _obj5;
    //[SerializeField] private GameObject _obj6;
    //[SerializeField] private GameObject _obj7;
    //[SerializeField] private GameObject _obj8;
    //[SerializeField] private GameObject _obj9;
    //[SerializeField] private GameObject _obj10;
    //[SerializeField] private GameObject _obj11;
    //[SerializeField] private GameObject _obj12;
    //[SerializeField] private GameObject _obj13;

    //[SerializeField]
    //private GameObject _audio1;
    //[SerializeField]
    //private GameObject _audio2;
    //[SerializeField]
    //private GameObject _audio3;
    //[SerializeField]
    //private GameObject _audio4;
    //[SerializeField]
    //private GameObject _audio5;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {

        this.remaining -= Time.deltaTime;
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining = timeLimit - (int)time;

        //ドアのオブジェクトが消えるときに効果音再生
        if (this.remaining <= 120)
        {
            audioSource.Play();
            Debug.Log(audioSource);
        }
        if (this.remaining <= 118)
        {
            audioSource.Stop();
        }
        if (this.remaining <= 100)
        {
            Debug.Log("b");
            audioSource3.Play();


        }
        if (this.remaining <= 60)
        {
            Debug.Log("c");
            audioSource7.Play();

        }
        if (this.remaining <= 30)
        {
            Debug.Log("d");
            audioSource9.Play();

        }
        if (this.remaining <= 25)
        {
            Debug.Log("e");
            audioSource13.Play();
        }

    }
}

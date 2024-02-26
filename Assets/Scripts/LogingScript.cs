using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogingScript : MonoBehaviour
{
    public float remaining = 10f; //15•b
    [SerializeField] int timeLimit;
    float time;

    // Update is called once per frame
    void Update()
    {
        //Invoke("Tereport", 3.5f);
        this.remaining -= Time.deltaTime;
        time += Time.deltaTime;
        //time•Ï”‚ğintŒ^‚É‚µ§ŒÀŠÔ‚©‚çˆø‚¢‚½”‚ğintŒ^‚Ìlimit•Ï”‚É‘ã“ü
        int remaining = timeLimit - (int)time;
        if (this.remaining <= 0)
        {
            SceneManager.LoadScene("Main");
        }
    }
}

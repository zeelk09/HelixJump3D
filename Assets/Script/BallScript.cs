using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    float Speed;
    Rigidbody body;
    bool flag;

    [SerializeField]
    GameObject splashObject;

    [SerializeField]
    Sprite[] AllSplashSprite;
    [SerializeField]
    GameObject GameOverPAnel,WinnerPanel;
    [SerializeField]
    int Power, Radius;
    [SerializeField]
    TextMeshProUGUI Scoretext;
    [SerializeField]
    AudioClip BallSound;
    [SerializeField]
    AudioSource SoundSource;
    int Score;
    [SerializeField]
    GameObject ScoreText, Text;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
       // body.velocity = Vector3.zero;
       // body.AddForce(Vector3.up*Speed,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (!flag)
        //{
        //    body.AddForce(Vector3.up * Speed, ForceMode.Impulse);
        //    flag = true;
        //}
        //Invoke("flagchange", 0.2f);
        if(!flag)
        {
            this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y + 2,this.transform.position.x),0.4f);
            this.transform.DOScale(new Vector3(this.transform.localScale.x-0.3f,this.transform.localScale.y,this.transform.localScale.z),0.3f).OnComplete(MyCallBack);
            this.transform.DOScale(new Vector3(this.transform.localScale.x, this.transform.localScale.y-0.3f, this.transform.localScale.z), 0.2f).OnComplete(MyCallBack);
            this.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            flag = true;
        }
        Invoke("flagchange", 0.2f);
        SoundSource.clip = BallSound;
        SoundSource.Play();
        //GameObject g = Instantiate(splashObject, collision.transform);
         GameObject g = Instantiate(splashObject, Vector3.zero, Quaternion.Euler(90, 0, 0), collision.transform);
        g.transform.localPosition = new Vector3(-0.0134f, -0.0089f, 0.0027f);
        
        g.GetComponent<SpriteRenderer>().sprite = AllSplashSprite[Random.Range(0,AllSplashSprite.Length)];
        Destroy(g,0.7f);

        if(collision.gameObject.transform.tag =="Bad")
        {
            GameOverPAnel.SetActive(true);
            SoundSource.mute = true;
            ScoreText.SetActive(false);
            Text.SetActive(false);
        }
        if(collision.gameObject.transform.tag =="Win")
        {
            WinnerPanel.SetActive(true);
            SoundSource.mute = true;
            ScoreText.SetActive(false);
            Text.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Red")
        {

            Score += 5;
            ScoreText.transform.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        }
    }
    void MyCallBack()
    {
        this.transform.DOScale(new Vector3(0.7f,0.7f,0.7f),0.3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach(Transform child in other.transform)
        {
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Power,child.transform.position,Radius,0.1f);
            child.gameObject.GetComponent<Rigidbody>().mass = Power;
              
            child.gameObject.GetComponent<MeshCollider>().enabled = false;
           
        }
        
    }
    public void RetryBnt()
    {
        SceneManager.LoadScene(1);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    private void flagchange()
    {
        flag = false;
    }

  
}

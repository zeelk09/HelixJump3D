using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    GameObject StartScen, LoadingScene, SettingPannel,ExitPanel;
    [SerializeField]
    Slider SliderObj;
    bool Flag;
    [SerializeField]
    float Speed;
    [SerializeField]
    Sprite MusicOn,MusicOff,SoundOn,SoundOff;
    [SerializeField]
    Button Music, Sound;
    [SerializeField]
    AudioSource MusicSource, SoundSource;

    private void Start()
    {
        if (AudioScript.instance.Music)
        {
            Music.GetComponent<Image>().sprite = MusicOn;
            MusicSource.mute = false;
        }
        else
        {
            Music.GetComponent<Image>().sprite = MusicOff;
            MusicSource.mute = true;
        }

        if (AudioScript.instance.Sound)
        {
            Sound.GetComponent<Image>().sprite = SoundOn;
            SoundSource.mute = false;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = SoundOff;
            SoundSource.mute = true;
        }
       
    }
    public void StartBtn()
    {
        SoundSource.Play();
        Flag = true;
        StartScen.SetActive(false);
        LoadingScene.SetActive(true);
    }
    private void Update()
    {
        if(Flag==true)
        {
            if (SliderObj.value < 1)
            {
                SliderObj.value = SliderObj.value + Speed * Time.deltaTime;
            }
            else
            { 
                Flag = false;
                SceneManager.LoadScene(1);
            }

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (SettingPannel.activeInHierarchy)
            {
                SettingPannel.SetActive(false);
                StartScen.SetActive(true);
            }

            else if (ExitPanel.activeInHierarchy)
            {
                ExitPanel.SetActive(false);
            }
            else
            {
                ExitPanel.SetActive(true);
            }
        }
    }
    public void MusicMangemnet()
    {
        if (AudioScript.instance.Music)
        {
            Music.GetComponent<Image>().sprite = MusicOff;
            AudioScript.instance.Music = false;
            MusicSource.mute = true;
        }
        else
        {
            Music.GetComponent<Image>().sprite = MusicOn;
            AudioScript.instance.Music = true;
            MusicSource.mute = false;
        }
    }
    public void SoundMangemnet()
    {
        if (AudioScript.instance.Sound)
        {
            Sound.GetComponent<Image>().sprite = SoundOff;
            AudioScript.instance.Sound = false;
            SoundSource.mute = true;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = SoundOn;
            AudioScript.instance.Sound = true;
            SoundSource.mute = false;
        }
    }
    public void SettingPanl()
    {
        SoundSource.Play();
        SettingPannel.SetActive(true);
    }

    public void BackBtn()
    {
        SoundSource.Play();
        SettingPannel.SetActive(false);
        StartScen.SetActive(true);
    }
    public void WrongBtn()
    {
        ExitPanel.SetActive(false);
        StartScen.SetActive(true);
    }
}

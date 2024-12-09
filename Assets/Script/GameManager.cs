        
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] AllPrebObj;
    [SerializeField]
    GameObject RotateObj;
    GameObject Gg;
    int counter = 0;
    int value = 0;
    [SerializeField]
    Color[] AllColour;
    [SerializeField]
    Material[] AllMaterial;
    [SerializeField]
    Button Music, Sound;
    [SerializeField]
    AudioSource[] MusicSource;
    [SerializeField]
     AudioSource SoundSource;
    [SerializeField]
     AudioClip[] AllSoundSource;
    [SerializeField]
    Sprite MusicOn, SoundOn, MusicOff, SoundOff;
    [SerializeField]
    GameObject SettingPan;
    [SerializeField]
    GameObject SetttingBtn;
   
    private void Start()
    {
        counter = PlayerPrefs.GetInt("Level", 9);
        InstantSlice();
        if(counter>=12)
        {
            AllMaterial[0].color = AllColour[0];
            AllMaterial[1].color = AllColour[1];
            AllMaterial[2].color = AllColour[2];
        }
        if (AudioScript.instance.Music)
        {
            Music.GetComponent<Image>().sprite = MusicOn;
            MusicSource[0].mute = false;
        }
        else
        {
            Music.GetComponent<Image>().sprite = MusicOff;
            MusicSource[0].mute = true;
        }

        if (AudioScript.instance.Sound)
        {
            Sound.GetComponent<Image>().sprite = SoundOn;
            SoundSource.clip = AllSoundSource[0];
            SoundSource.mute = false;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = SoundOff;
            SoundSource.clip = AllSoundSource[0];
            SoundSource.mute = true;
        }

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(SetttingBtn.activeInHierarchy)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void InstantSlice()
    {
        counter = PlayerPrefs.GetInt("Level",9);
        for (int i = 0; i < counter; i++)
        {
            if (i == 0)
            {
                Gg = Instantiate(AllPrebObj[0], RotateObj.transform);
            }
            else if (i == counter - 1)
            {
                Gg = Instantiate(AllPrebObj[AllPrebObj.Length - 1], RotateObj.transform);
            }
            else
            {
                Gg = Instantiate(AllPrebObj[Random.Range(1, AllPrebObj.Length - 2)], RotateObj.transform);
            }

            Gg.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            Gg.transform.Translate(new Vector3(0, 3 + value, 0));
            value -= 4;
        }
    }
    public void LevelInc()
    {
        counter = PlayerPrefs.GetInt("Level",9);
        counter++;
        PlayerPrefs.SetInt("Level",counter);
        SceneManager.LoadScene(1);
    }
    public void MusicMangemnet()
    {
        if (AudioScript.instance.Music)
        {
            Music.GetComponent<Image>().sprite = MusicOff;
            AudioScript.instance.Music = false;
            MusicSource[0].mute = true;
        }
        else
        {
            Music.GetComponent<Image>().sprite = MusicOn;
            AudioScript.instance.Music = true;
            MusicSource[0].mute = false;
        }
    }
    public void SoundMangemnet()
    {
        if (AudioScript.instance.Sound)
        {
            Sound.GetComponent<Image>().sprite = SoundOff;
            AudioScript.instance.Sound = false;
            // SoundSource.mute = true;
            SoundSource.clip = AllSoundSource[0];
            SoundSource.mute = true;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = SoundOn;
            AudioScript.instance.Sound = true;
            // SoundSource.mute = false;
            SoundSource.clip = AllSoundSource[0];
            SoundSource.mute = false;
        }
    }
    public void SettingPanl()
    {
        SettingPan.SetActive(true);
        SetttingBtn.SetActive(false);
        SoundSource.clip = AllSoundSource[0];
        SoundSource.Play();
    }
    public void BackBtn()
    {
        SettingPan.SetActive(false);
        SetttingBtn.SetActive(true);

    }
}

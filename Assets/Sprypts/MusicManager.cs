using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        
    }
    void Start()
    {
        
        
        LoadVolume();
    }
    public void VolumeSlider(float volume)
    {
        
        volumeText.text = volume.ToString("0.0");
    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolume();
    }

    void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
        //AudioSource.vol
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (SceneManager.GetActiveScene().name == "BLevel1")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        */
        /*
        if (SceneManager.GetActiveScene().name == "KosmosPanel")
        {
            this.gameObject.SetActive(true);
        }
        */
     
    }

}

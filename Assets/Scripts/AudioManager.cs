using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    public SFXLibrary sfxLibrary;
    public MusicLibrary primaryMusicLibrary;
    public MusicLibrary interruptMusicLibrary;
    [SerializeField] private AudioMixer mixer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sfxLibrary.Initialize();
        primaryMusicLibrary.Initialize();
        interruptMusicLibrary.Initialize();
    }

    /*private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/
    private void Start()
    {
        StartCoroutine(LoadAndInitializeSavedSettings());
    }
    IEnumerator LoadAndInitializeSavedSettings()
    {
        if (mixer != null)
        {
            yield return new WaitForEndOfFrame();
            mixer.SetFloat("MusicVolume",  Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1.0f)) * 20);
            mixer.SetFloat("SFXVolume",  Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume", 1.0f)) * 20);
        }
    }

    /*private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadAndApplySavedSettings();
    }*/

    public void UpdateMixer(string parameter, float value)
    {
        mixer.SetFloat(parameter, Mathf.Log10(value) * 20);
    }

    public void PlaySFX(SFXType type)
    {
        AudioClip clip = sfxLibrary.GetClip(type);
        if (clip != null)
        {
            if (SFXAudioSource.Instance != null)
            {
                SFXAudioSource.Instance.GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }
    }

    public void PlayPrimaryMusic(MusicType type)
    {
        AudioClip clip = primaryMusicLibrary.GetClip(type);
        if (clip != null)
        {
            if (InterruptMusicSource.Instance != null)
            {
                InterruptMusicSource.Instance.GetComponent<AudioSource>().Stop();
            }

            if (PrimaryMusicSource.Instance != null)
            {
                PrimaryMusicSource.Instance.GetComponent<AudioSource>().Stop();
                PrimaryMusicSource.Instance.GetComponent<AudioSource>().clip = clip;
                PrimaryMusicSource.Instance.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void ResumePrimaryMusic()
    {
        if (InterruptMusicSource.Instance != null)
        {
            InterruptMusicSource.Instance.GetComponent<AudioSource>().Stop();
        }

        if (PrimaryMusicSource.Instance != null)
        {
            PrimaryMusicSource.Instance.GetComponent<AudioSource>().UnPause();
        }
    }

    public void PlayInterruptMusic(MusicType type)
    {
        AudioClip clip = interruptMusicLibrary.GetClip(type);
        if (clip != null)
        {
            if (PrimaryMusicSource.Instance != null)
            {
                PrimaryMusicSource.Instance.GetComponent<AudioSource>().Pause();
            }

            if (InterruptMusicSource.Instance != null)
            {
                InterruptMusicSource.Instance.GetComponent<AudioSource>().clip = clip;
                InterruptMusicSource.Instance.GetComponent<AudioSource>().Play();
            }
        }
    }

}
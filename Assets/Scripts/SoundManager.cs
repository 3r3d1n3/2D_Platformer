using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    
    [SerializeField] private AudioSource[] bgmAudios;
    [SerializeField] private AudioSource[] eventAudios;
    [SerializeField] private AudioClip[] clips;

    [SerializeField] private TMP_Dropdown selectedInput;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider eventVolume;

    [SerializeField] private Toggle bgmMute;
    [SerializeField] private Toggle eventMute;

    void Awake()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();
        
        selectedInput.onValueChanged.AddListener(SetInputType);
        
        bgmVolume.onValueChanged.AddListener(BgmVolumeAdjust);
        eventVolume.onValueChanged.AddListener(EventVolumeAdjust);
        
        bgmMute.onValueChanged.AddListener(BgmMute);
        eventMute.onValueChanged.AddListener(EventMute);
        
    }

    void Start()
    {
        bgmVolume.value = bgmAudios[0].volume;
        bgmMute.isOn = bgmAudios[0].mute;
        
        eventVolume.value = eventAudios[0].volume;
        eventMute.isOn = eventAudios[0].mute;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SoundPlay(string clipName)
    {
        foreach (var bgmAudio in bgmAudios)
        {
            if (!bgmAudio.isPlaying)
            {
                foreach (var clip in clips)
                {
                    if (clip.name.Equals(clipName))
                    {
                        bgmAudio.clip = clip;
                        bgmAudio.loop = true;
                        bgmAudio.Play();
                        return;
                    }
                }
                Debug.Log($"{clipName} 파일을 찾을 수 없음");
                return;
            }
        }
        Debug.Log($"재생 가능한 bgm AudioSource가 없습니다.");
    }

    public void SoundOneShot(string clipName)
    {
        foreach (var eventAudio in eventAudios)
        {
            if (!eventAudio.isPlaying)
            {
                foreach (var clip in clips)
                {
                    if (clip.name.Equals(clipName))
                    {
                        eventAudio.PlayOneShot(clip);
                        return;
                    }
                }

                Debug.Log($"{clipName} 파일을 찾을 수 없음");
                return;
            }
        }
        Debug.Log($"재생 가능한 event audio source 없음");
    }

    private void BgmVolumeAdjust(float volume)
    {
        foreach (var bgmAudio in bgmAudios)
        {
            bgmAudio.volume = volume;
        }
    }

    private void EventVolumeAdjust(float volume)
    {
        foreach (var eventAudio in eventAudios)
        {
            eventAudio.volume = volume;
        }
    }

    private void BgmMute(bool isMute)
    {
        foreach (var bgmAudio in bgmAudios)
        {
            bgmAudio.mute = isMute;
        }
    }

    private void EventMute(bool isMute)
    {
        foreach (var eventAudio in eventAudios)
        {
            eventAudio.mute = isMute;
        }
    }

    private void SetInputType(int index)
    {
        switch (index)
        {
            case 0:
                playerMovement.inputType = InputType.Keyboard;
                break;
            case 1:
                playerMovement.inputType = InputType.Joystick;
                break;
        }
    }
}

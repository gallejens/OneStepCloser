using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        Instance = this;
    }

    public void BackButtonPressed()
    {
        PlayerPreferenceManager.Instance.SavePlayerPreferences();
        Disable();
        MainMenu.Instance.Enable();
    }

    public void SetMouseSensitivity(float sens)
    {
        PlayerController.MouseSensitivity = sens;
        PlayerPreferenceManager.LoadedPlayerPreference.mouseSens = sens;
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
        PlayerPreferenceManager.LoadedPlayerPreference.soundVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPreferenceManager.LoadedPlayerPreference.musicVolume = volume;
    }

    public void FullscreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPreferenceManager.LoadedPlayerPreference.fullscreen = isFullscreen;
    }

    public void Enable() => GenericMethods.SetAllChildrenActive(gameObject, true);

    public void Disable() => GenericMethods.SetAllChildrenActive(gameObject, false);
}

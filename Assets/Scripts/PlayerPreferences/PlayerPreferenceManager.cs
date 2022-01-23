using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferenceManager : MonoBehaviour
{
    public static PlayerPreferenceManager Instance { get; private set; }

    public static PlayerPreference LoadedPlayerPreference = new PlayerPreference();

    [SerializeField] private GameObject sensSlider;
    [SerializeField] private GameObject soundSlider;
    [SerializeField] private GameObject musicSlider;
    [SerializeField] private GameObject fullscreenToggle;

    [SerializeField] private OptionsMenu optionsMenu;

    private void Awake()
    {
        Instance = this;

        try
        {
            LoadedPlayerPreference = GenericMethods.ReadJSONFile<PlayerPreference>("playerpreference");
        }
        catch (JsonSerializationException)
        {
            // default sens value to 5 instead of 0 if no playerpreference files exists
            LoadedPlayerPreference.mouseSens = 5;
        }
    }

    private void Start()
    {
        sensSlider.GetComponent<Slider>().SetValueWithoutNotify(LoadedPlayerPreference.mouseSens);
        optionsMenu.SetMouseSensitivity(LoadedPlayerPreference.mouseSens);

        soundSlider.GetComponent<Slider>().SetValueWithoutNotify(LoadedPlayerPreference.soundVolume);
        optionsMenu.SetSoundVolume(LoadedPlayerPreference.soundVolume);

        musicSlider.GetComponent<Slider>().SetValueWithoutNotify(LoadedPlayerPreference.musicVolume);
        optionsMenu.SetMusicVolume(LoadedPlayerPreference.musicVolume);

        fullscreenToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(LoadedPlayerPreference.fullscreen);
        optionsMenu.FullscreenToggle(LoadedPlayerPreference.fullscreen);
    }

    public void SavePlayerPreferences()
    {
        GenericMethods.WriteJSONFile(LoadedPlayerPreference, "playerpreference");
    }
}

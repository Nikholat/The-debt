using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;
    private const float _mulpiplier = 20f;

    void Awake()
    {
        slider.onValueChanged.AddListener(HanldeSliderValueChanged);
    }

    private void HanldeSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) *  _mulpiplier;
        mixer.SetFloat(volumeParameter, _volumeValue);
    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) *  _mulpiplier);
        slider.value = Mathf.Pow(10f, _volumeValue / _mulpiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }
}

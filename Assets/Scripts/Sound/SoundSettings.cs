using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sound
{
    public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private string parameter;
        [SerializeField] private AudioClip testSound;
        [SerializeField] private SoundPlayer soundPlayer;

        private void Start()
        {
            mixer.GetFloat(parameter, out var value);
            slider.value = value;
            // todo: fix it
            slider.onValueChanged.AddListener(SliderValueChange);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SliderValueChange);
        }

        private void SliderValueChange(float value)
        {
            mixer.SetFloat(parameter, value);
            if (soundPlayer && testSound) soundPlayer.PlayClip(testSound);
        }
    }
}
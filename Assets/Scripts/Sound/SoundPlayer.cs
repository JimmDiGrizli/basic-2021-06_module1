using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource source;
        [SerializeField] private List<SoundData> sounds = new List<SoundData>();

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void Play(string clipName)
        {
            source.clip = FindClip(clipName);
            source.Play();
        }

        [CanBeNull]
        private AudioClip FindClip(string clipName)
        {
            return sounds.Find(data => data.name == clipName).clip;
        }

        [Serializable]
        private struct SoundData
        {
            public string name;
            public AudioClip clip;
        }
    }
}
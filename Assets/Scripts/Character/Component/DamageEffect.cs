using System;
using UnityEngine;

namespace Character.Component
{
    public class DamageEffect : MonoBehaviour
    {
        public GameObject damageEffect;

        public void ShowDamageEffect()
        {
            foreach (var effect in damageEffect.GetComponentsInChildren<ParticleSystem>())
            {
                effect.Play();
            }
        }
    }
}
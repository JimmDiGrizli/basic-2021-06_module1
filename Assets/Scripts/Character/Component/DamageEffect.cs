using System;
using UnityEngine;

namespace Character.Component
{
    public class DamageEffect : MonoBehaviour
    {
        public GameObject damageEffect;

        // todo: Нужно спросить, как сделать так чтобы не проигрывались эффекты при старте уровня.
        public void Start()
        {
            foreach (var effect in damageEffect.GetComponentsInChildren<ParticleSystem>())
            {
                effect.Stop();
            }          
        }

        public void ShowDamageEffect()
        {
            foreach (var effect in damageEffect.GetComponentsInChildren<ParticleSystem>())
            {
                effect.Play();
            }
        }
    }
}
using System;
using Sound;
using UnityEngine;

namespace Character.Component
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] public int health;
        public int Health => health;

        [SerializeField] public bool isDead;
        public bool IsDead => isDead;

        public Action<int> OnHealthChanged;
        public Action OnDead;

        private DamageEffect damageEffect;
        [SerializeField] private string damageSound;
        [SerializeField] private string dieSound;
        private SoundPlayer soundPlayer;

        private void Start()
        {
            damageEffect = GetComponent<DamageEffect>();
            soundPlayer = GetComponentInChildren<SoundPlayer>();
        }

        public void ApplyDamage(AttackComponent attackComponent)
        {
            health -= attackComponent.Damage;
           
            if (damageEffect) damageEffect.ShowDamageEffect();            

            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
            }

            if (soundPlayer) soundPlayer.Play(isDead ? dieSound : damageSound);

            OnHealthChanged?.Invoke(health);
        }
    }
}
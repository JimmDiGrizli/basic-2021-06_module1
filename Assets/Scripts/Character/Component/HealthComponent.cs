using System;
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

        private void Start()
        {
            damageEffect = GetComponent<DamageEffect>();
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

            OnHealthChanged?.Invoke(health);
        }
    }
}
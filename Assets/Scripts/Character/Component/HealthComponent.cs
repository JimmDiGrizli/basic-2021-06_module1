using System;
using Sound;
using UnityEngine;

namespace Character.Component
{
    [RequireComponent(typeof(DamageEffect))]
    [AddComponentMenu("Character/HealthComponent")]
    public class HealthComponent : MonoBehaviour
    {
        public int Health { get; private set; }
        public bool IsDead { get; private set; }

        public Action<int> OnHealthChanged;
        public Action OnDead;

        private DamageEffect damageEffect;
        [ContextMenuItem("Tools/Check", "Check")] [SerializeField]
        private string damageSound;

        [ContextMenuItem("Tools/Check", "Check")] [SerializeField]
        private string dieSound;
        private SoundPlayer soundPlayer;

        public void Configuration(Characteristics characteristics)
        {
            Health = characteristics.Health;
        }

        public void ApplyDamage(AttackComponent attackComponent)
        {
            Health -= attackComponent.Damage;

            if (damageEffect) damageEffect.ShowDamageEffect();

            if (Health <= 0)
            {
                IsDead = true;
                Health = 0;
                OnDead?.Invoke();
            }

            if (soundPlayer) soundPlayer.Play(IsDead ? dieSound : damageSound);

            OnHealthChanged?.Invoke(Health);
        }

        private void Start()
        {
            damageEffect = GetComponent<DamageEffect>();
            soundPlayer = GetComponentInChildren<SoundPlayer>();
        }

        [ContextMenu("Tools/Check")]
        private void Check()
        {
            if (damageSound == null) Debug.Log("Not set damageSound.");
            else if (dieSound == null) Debug.Log("Not set dieSound.");
            else Debug.Log("It's ok!");
        }
    }
}
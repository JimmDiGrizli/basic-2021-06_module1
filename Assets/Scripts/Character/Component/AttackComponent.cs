using System;
using Sound;
using UnityEngine;

namespace Character.Component
{
    public class AttackComponent : MonoBehaviour
    {
        private int damage;
        public int Damage => damage;

        private Action OnAttackFinished;

        [SerializeField] private string attackSound;
        private SoundPlayer soundPlayer;

        private void Start()
        {
            soundPlayer = GetComponentInChildren<SoundPlayer>();
        }

        public void Configuration(Characteristics characteristics)
        {
            damage = characteristics.Damage;
        }

        public void Attack(HealthComponent healthComponent)
        {
            if (soundPlayer) soundPlayer.Play(attackSound);
            if (healthComponent.IsDead == false) healthComponent.ApplyDamage(this);
            OnAttackFinished?.Invoke();
        }
    }
}
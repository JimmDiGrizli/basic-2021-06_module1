using System;
using UnityEngine;

namespace Character.Component
{
    public class AttackComponent : MonoBehaviour
    {
        public int damage;
        public int Damage => damage;

        public Action<int> OnDamageChanged;
        public Action OnAttackFinished;

        public void Attack(HealthComponent healthComponent)
        {
            if (healthComponent.IsDead == false) healthComponent.ApplyDamage(this);
            OnAttackFinished?.Invoke();
        }
    }
}
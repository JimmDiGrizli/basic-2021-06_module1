using Character.Component;
using UnityEngine;

namespace Character
{
    public class CharacterAnimationEvents : MonoBehaviour
    {
        CharacterComponent _characterComponent;

        void Start()
        {
            _characterComponent = GetComponentInParent<CharacterComponent>();
        }

        void ShootEnd()
        {
            _characterComponent.SetState(CharacterComponent.State.Idle);
        }

        void AttackEnd()
        {
            _characterComponent.SetState(CharacterComponent.State.RunningFromEnemy);
        }

        void Hit()
        {
            _characterComponent.AttackFinished();
        }
    }
}
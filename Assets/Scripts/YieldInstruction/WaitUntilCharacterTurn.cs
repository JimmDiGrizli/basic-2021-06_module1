using System;
using Character.Component;
using UnityEngine;

namespace YieldInstruction
{
    public class WaitUntilCharacterTurn : CustomYieldInstruction
    {
        private bool _isKeepWiting = true;
        public override bool keepWaiting => _isKeepWiting;
        
        public WaitUntilCharacterTurn(CharacterComponent character)
        {
            void Action()
            {
                _isKeepWiting = false;
                character.AttackComponent.OnAttackFinished -= Action;
            }

            character.AttackComponent.OnAttackFinished += Action;
        }
    }
}
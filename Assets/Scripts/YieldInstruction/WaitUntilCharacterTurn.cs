using System;
using Character.Component;
using UnityEngine;

namespace YieldInstruction
{
    public class WaitUntilCharacterTurn : CustomYieldInstruction
    {
        private bool isKeepWiting = true;
        public override bool keepWaiting => isKeepWiting;
        
        public WaitUntilCharacterTurn(CharacterComponent character)
        {
            void Action()
            {
                isKeepWiting = false;
                character.OnTurnEnded -= Action;
            }

            character.OnTurnEnded += Action;
        }
    }
}
using System.Collections;
using System.Linq;
using Character.Component;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using YieldInstruction;

public class GameController : MonoBehaviour
{
    [SerializeField] private CharacterComponent[] playerCharacters;
    [SerializeField] private CharacterComponent[] enemyCharacters;

    [SerializeField] private PauseController pauseController;

    public CanvasGroup selectScreen;
    private CharacterComponent currentPlayerCharacter;

    private void Start()
    {
        PrepareSelectButtons(false, true);
        StartTimers();
    }

    // todo: разделить на несколько методов
    private void PrepareSelectButtons(bool visible = true, bool binding = false)
    {
        var buttons = selectScreen.GetComponentsInChildren<Button>();
        for (var index = 0; index < buttons.Length; index++)
        {
            var button = buttons[index];
            if (enemyCharacters.Count() > index && enemyCharacters[index].HealthComponent.isDead == false)
            {
                var enemy = enemyCharacters[index];
                button.GetComponentInChildren<Text>().text = enemy.gameObject.name;
                if (binding) button.onClick.AddListener(() => RunPlayerAction(enemy));
                button.interactable = visible;
            }
            else
            {
                button.interactable = false;
            }
        }
    }

    private void StartTimers()
    {
        if (CheckWinner()) return;

        foreach (var character in playerCharacters)
        {
            Pause(character);
        }

        foreach (var character in enemyCharacters)
        {
            RunEnemyAction(character, playerCharacters);
        }
    }

    private void PauseTimers()
    {
        foreach (var character in playerCharacters)
        {
            character.TimerComponent.Pause();
        }

        foreach (var character in enemyCharacters)
        {
            character.TimerComponent.Pause();
        }
    }

    private void RunEnemyAction(CharacterComponent character, CharacterComponent[] aims)
    {
        void RunCharAction()
        {
            PauseTimers();
            character.SetTarget(GetTarget(aims).HealthComponent);
            character.StartTurn();

            void RunTimers()
            {
                StartTimers();
                character.OnTurnEnded -= RunTimers;
            }

            character.OnTurnEnded += RunTimers;
        }

        character.TimerComponent.OnCountdownCompleted += RunCharAction;
        character.TimerComponent.Run();
    }

    private void Pause(CharacterComponent character)
    {
        void PauseAction()
        {
            PrepareSelectButtons();
            currentPlayerCharacter = character;
            PauseTimers();
        }

        character.TimerComponent.OnCountdownCompleted += PauseAction;
        character.TimerComponent.Run();
    }

    private void RunPlayerAction(CharacterComponent enemy)
    {
        currentPlayerCharacter.SetTarget(enemy.HealthComponent);
        currentPlayerCharacter.StartTurn();

        void RunTimers()
        {
            StartTimers();
            PrepareSelectButtons(false);
            currentPlayerCharacter.OnTurnEnded -= RunTimers;
        }

        currentPlayerCharacter.OnTurnEnded += RunTimers;
    }


    private bool CheckWinner()
    {
        // todo: перевеси на подписку на смерть чара
        bool isPlayerCharacterAlive = playerCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null;
        bool isEnemyCharacterAlive = enemyCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null;

        if (!isPlayerCharacterAlive && !isEnemyCharacterAlive) return false;
        pauseController.Finish(!isPlayerCharacterAlive);
        return true;
    }

    private CharacterComponent GetTarget(CharacterComponent[] characterComponents)
    {
        return characterComponents.FirstOrDefault(c => !c.HealthComponent.IsDead);
    }
}
using System.Collections;
using System.Linq;
using Character.Component;
using JetBrains.Annotations;
using UnityEngine;
using YieldInstruction;

public class GameController : MonoBehaviour
{
    [SerializeField] private CharacterComponent[] playerCharacters;
    [SerializeField] private CharacterComponent[] enemyCharacters;
    
    private Coroutine gameLoop;
    
    private void Start()
    {
        gameLoop = StartCoroutine(GameLoop());
    }
    
    private IEnumerator GameLoop()
    {
        Coroutine turn = StartCoroutine(Turn(playerCharacters, enemyCharacters));

        yield return new WaitUntil(() => CheckWinner() != null);

        StopCoroutine(turn);
        GameOver();
    }

    [CanBeNull]
    private string CheckWinner()
    {
        bool isPlayerCharacterAlive = playerCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null;
        bool isEnemyCharacterAlive = enemyCharacters.FirstOrDefault(c => !c.HealthComponent.IsDead) == null;
        
        if (!isPlayerCharacterAlive && !isEnemyCharacterAlive) return null;
        return !isPlayerCharacterAlive ? "Victory" : "Defeat";
    }
    
    private void GameOver()
    {
        Debug.Log(CheckWinner());
    }

    private IEnumerator Turn(CharacterComponent[] playerChars, CharacterComponent[] enemyChars)
    {
        int turnCounter = 0;
        while (true)
        {
            for (int i = 0; i < playerChars.Length; i++)
            {
                if(playerChars[i].HealthComponent.IsDead)
                {
                    Debug.Log("");
                    Debug.Log("Character: " + playerChars[i].name + " is dead");
                    continue;
                }
                playerChars[i].SetTarget(GetTarget(enemyChars).HealthComponent);
                //TODO: hotfix
                yield return null; // ugly fix need to investigate
                playerChars[i].StartTurn();
                yield return new WaitUntilCharacterTurn(playerChars[i]);
                Debug.Log("Character: " + playerChars[i].name + " finished turn");
            }

            yield return new WaitForSeconds(.5f);

            for (int i = 0; i < enemyChars.Length; i++)
            {
                if (enemyChars[i].HealthComponent.IsDead)
                {
                    Debug.Log("Enemy character: " + enemyChars[i].name + " is dead");
                    continue;
                }
                enemyChars[i].SetTarget(GetTarget(playerChars).HealthComponent);
                enemyChars[i].StartTurn();
                yield return new WaitUntilCharacterTurn(enemyChars[i]);
                Debug.Log("Enemy character: " + enemyChars[i].name + " finished turn");
            }

            yield return new WaitForSeconds(.5f);

            turnCounter++;
            Debug.Log("Turn #" + turnCounter + " has been ended");
        }
    }
    
    private CharacterComponent GetTarget(CharacterComponent[] characterComponents)
    {
        return characterComponents.FirstOrDefault(c => !c.HealthComponent.IsDead);
    }
}

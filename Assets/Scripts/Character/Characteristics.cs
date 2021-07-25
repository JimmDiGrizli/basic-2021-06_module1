using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "CharacterCharacteristics", menuName = "Dismal Forest/Characteristics")]
    public class Characteristics : ScriptableObject
    {
        [SerializeField] private int health;
        public int Health => health;

        [SerializeField] private int damage;
        public int Damage => damage;

        [SerializeField] private int waitingTime;
        public int WaitingTime => waitingTime;
    }
}
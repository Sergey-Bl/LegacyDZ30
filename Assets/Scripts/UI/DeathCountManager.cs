using UnityEngine;

namespace Platformer.Model
{
    public class DeathCountManager : MonoBehaviour
    {
        public int deathCount;
        public int DeathCount => deathCount;

        public event System.Action OnDeathCountChanged;

        public void IncrementDeathCount()
        {
            deathCount++;
            Debug.Log("Slime killed: " + deathCount);
            OnDeathCountChanged?.Invoke();
        }
    }
}
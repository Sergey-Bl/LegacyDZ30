using Platformer.Gameplay;
using TMPro;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represents the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        private int currentHP;
        private int deathCount; // Death count field

       [SerializeField] private TextMeshProUGUI deathCountText; // Reference to the UI text component

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
                deathCount++; // Increment death count
                UpdateDeathCountText(); // Update UI text
            }
        }

        /// <summary>
        /// Decrement the HP of the entity until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        /// <summary>
        /// Gets the current death count.
        /// </summary>
        public int GetDeathCount()
        {
            return deathCount;
        }

        private void UpdateDeathCountText()
        {
            if (deathCountText != null)
            {
                deathCountText.text = deathCount.ToString($"Dead Player Count: {0}");
            }
        }

        void Awake()
        {
            currentHP = maxHP;
            deathCount = 0;
            UpdateDeathCountText(); // Initialize UI text
        }
    }
}

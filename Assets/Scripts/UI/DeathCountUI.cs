using Platformer.Model;
using TMPro;
using UnityEngine;
using Platformer.Gameplay;



namespace Platformer.UI
{
    public class DeathCountUI : MonoBehaviour
    {
        [SerializeField] private DeathCountManager deathCountManager;
        [SerializeField] private TextMeshProUGUI textComponent;

        private void OnEnable()
        {
            PlayerEnemyCollision.deathCountManager = deathCountManager;
            deathCountManager.OnDeathCountChanged += UpdateDeathCountText;
            UpdateDeathCountText(); // Обновляем текст сразу после подписки
        }

        private void OnDisable()
        {
            deathCountManager.OnDeathCountChanged -= UpdateDeathCountText;
        }

        private void UpdateDeathCountText()
        {
            textComponent.text = "Slime killed: " + deathCountManager.DeathCount;
        }
    }
}
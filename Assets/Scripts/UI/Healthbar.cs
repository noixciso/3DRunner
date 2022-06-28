using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Image _healthBar;

   private void OnEnable()
   {
      _player.HealthChanged += OnHealthChanged;
   }

   private void OnDisable()
   {
      _player.HealthChanged -= OnHealthChanged;
   }

   private void OnHealthChanged(int health)
   {
      _healthBar.fillAmount = health / 10f;
   }
}

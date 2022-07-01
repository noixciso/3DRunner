using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Image _healthBar;

   private const float _lengthOneHealthBarSection = 10f;

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
      _healthBar.fillAmount = health / _lengthOneHealthBarSection;
   }
}

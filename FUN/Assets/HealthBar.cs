using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro ;   


public class HealthBar : MonoBehaviour
{

    private float _maxHealth = 100;
    private float _currentHealth;

  [SerializeField ]  private Image _healthBarFill;
    [SerializeField] private Gradient _colorGradient;  
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;    
       
        
    }

    public void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.fillAmount = targetFillAmount;

        // Evaluate the color gradient at the target fill amount
        _healthBarFill.color = _colorGradient.Evaluate(targetFillAmount);
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
      /*  if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth < 0)
        {
            _currentHealth = 0;
        } */

        UpdateHealthBar();
        
    }

   
}

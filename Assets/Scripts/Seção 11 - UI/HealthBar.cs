using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private int healingFactor = 10;

    private Image _lifeBar;
    private TextMeshProUGUI _txtHealth;
    private int _currentHealth = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount > 1)
        {
            if (transform.GetChild(0).childCount > 0)
            {
                _lifeBar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
            }

            if (transform.GetChild(1).childCount > 0)
            {
                _txtHealth = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth()
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            _lifeBar.fillAmount = (float)_currentHealth/100;
            _txtHealth.text = _currentHealth.ToString();
        }
    }
    
    public void RecoverHealth()
    {
        if (_currentHealth < 100)
        {
            _currentHealth += healingFactor;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, 100);
            _lifeBar.fillAmount = (float)_currentHealth/100;
            _txtHealth.text = _currentHealth.ToString();
        }
    }
}

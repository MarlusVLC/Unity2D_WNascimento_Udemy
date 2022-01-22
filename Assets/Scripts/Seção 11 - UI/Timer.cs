using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private float startTimer = 10;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private Image _counter;
    private float _currTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _currTime = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _currTime = _currTime > 0 ? _currTime - Time.deltaTime : 0;

        _time.text = Mathf.Ceil(_currTime).ToString();
        _counter.fillAmount = _currTime / startTimer;
    }
}

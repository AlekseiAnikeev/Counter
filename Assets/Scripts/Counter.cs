using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;

    private bool _isButtonPressed = false;
    private float _triggerTime;
    private int _counter = 0;

    private void Start()
    {
        _triggerTime = _delay;
        _text.text = "0";

        StartCoroutine(TestCoroutine());
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _isButtonPressed = _isButtonPressed == false;
    }

    IEnumerator TestCoroutine()
    {
        while (enabled)
        {
            yield return new WaitUntil(() => _isButtonPressed);

            if (Time.time >= _triggerTime)
            {
                _text.text = _counter++.ToString();
                _triggerTime = Time.time + _delay;
            }
        }
    }
}

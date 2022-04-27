using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
    private Image bar;
    private float currentAmount;
    [SerializeField] float barSpeed;
    [SerializeField] TextMeshProUGUI barText;

    void Start()
    {
        bar = GetComponent<Image>();
        bar.fillAmount = 1.0f;
        currentAmount = 1.0f;
    }

    private void Update()
    {
        if (currentAmount != bar.fillAmount)
        {
            // Cause bar to empty/fill gradually instead of instantly
            bar.fillAmount = Mathf.Lerp(bar.fillAmount, currentAmount, Time.deltaTime * barSpeed);
        }
    }

    public void InitializeValues(float maxValue)
    {
        barText.text = maxValue.ToString();
    }

    public void UpdateBar(float maxValue, float currentValue)
    {
        currentAmount = currentValue / maxValue;
        barText.text = currentValue.ToString();
    }
}

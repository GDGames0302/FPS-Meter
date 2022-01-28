using UnityEngine;
using System.Collections;
using TMPro;

public class FPSMeter : MonoBehaviour
{
    TextMeshProUGUI fpsMeterText;

    [Tooltip("The number of decimals that the fps meter text will display.")]
    [Range(0, 3)]
    [SerializeField]
    int numberOfDecimals;

    [Tooltip("Controls how often the fps meter text will update.")]
    [SerializeField]
    float timeBetweenTextUpdates = 0.1f;

    public float fpsCount { get; private set; }
    float deltaTime;


    void Awake()
    {
        fpsMeterText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(UpdateFPSTextLoop());
    }

    void Update()
    {
        CalculateFPS();
    }

    
    void CalculateFPS()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fpsCount = 1.0f / deltaTime;
    }

    IEnumerator UpdateFPSTextLoop()
    {
        UpdateFPSText();

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenTextUpdates);
            UpdateFPSText();
        }
    }

    void UpdateFPSText()
    {
        fpsMeterText.text = fpsCount.ToString("F" + numberOfDecimals);
    }
}
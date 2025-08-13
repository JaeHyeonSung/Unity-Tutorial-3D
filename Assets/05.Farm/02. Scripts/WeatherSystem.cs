using System;
using System.Collections;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public enum WeatherType
    {
        Sunny,
        Rainy,
        Snowy,
    }
    public WeatherType weatherType;

    [SerializeField] private GameObject[] weatherParticles; // 0: Sunny, 1: Rainy, 2: Snowy

    public event Action<WeatherType> weatherAction;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
            Debug.Log("Weather Count: " + weatherCount);

            int ranIndex = UnityEngine.Random.Range(0, weatherCount);

            weatherType = (WeatherType)ranIndex;

            foreach(var particle in weatherParticles)
            {
                particle.SetActive(false);
            }

            weatherParticles[ranIndex].SetActive(true);

            weatherAction?.Invoke(weatherType);
        }
    }
}

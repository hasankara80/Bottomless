using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private GameObject insectPrefab;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject starPrefab;
    private int[] _xPosition = new int[3];

    private void Start()
    {
        _xPosition[0] = -2;
        _xPosition[1] = 0;
        _xPosition[2] = 2;
        
        for (int i = 0; i < 40; i++)
        {
            Instantiate(starPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0.3f, (i + 1) * 53),quaternion.identity);
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(heartPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0.3f, (i + 1) * 401),quaternion.identity);
        }

        for (int i = 0; i < 100; i++)
        {
            Instantiate(stonePrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0.45f, (i + 1) * 23),quaternion.identity);
        }

        for (int i = 0; i < 100; i++)
        {
            Instantiate(insectPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0.1f, (i + 1) * 29),quaternion.identity);
        }
    }
}

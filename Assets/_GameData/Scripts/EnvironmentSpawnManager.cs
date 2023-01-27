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
            Instantiate(starPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0, (i + 1) * 50),quaternion.identity);
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(heartPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0, (i + 1) * 410),quaternion.identity);
        }

        for (int i = 0; i < 100; i++)
        {
            Instantiate(stonePrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0, (i + 1) * 20),quaternion.identity);
        }

        for (int i = 0; i < 100; i++)
        {
            Instantiate(insectPrefab, new Vector3(_xPosition[Random.Range(0,_xPosition.Length)], 0, (i + 1) * 30),quaternion.identity);
        }
    }
}

using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _points;
    [SerializeField] private Coin _coin;
    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_points.childCount];

        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _points.GetChild(i);
        }

        Spawn();
    }

    private void Spawn()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coin, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}

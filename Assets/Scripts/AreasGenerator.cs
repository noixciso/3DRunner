using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreasGenerator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _startingAreas;
    [SerializeField] private GameObject[] _playingAreas;

    private List<GameObject> _activeAreas = new List<GameObject>();

    private float _spawnPosition = 0;
    private float _areaLenght = 200;
    private int _partAreaLength = 130;
    private int _startingCountAreas = 6;

    private void OnEnable()
    {
        _player.Respawn += OnRespawn;
    }

    private void OnDisable()
    {
        _player.Respawn -= OnRespawn;
    }

    private void Awake()
    {
        SpawnStartingAreas();
    }

    private void Update()
    {
        if (_player.IsRespawn == false)
        {
            if (IsOneAreaPassed())
            {
                Initialize(_playingAreas,Random.Range(0, _playingAreas.Length));
                DeletePassedArea();
            }
        }
    }
    
    private bool IsOneAreaPassed()
    {
        bool isPlayerPosition = _player.transform.position.z - _partAreaLength > _spawnPosition - (_startingCountAreas * _areaLenght);
        return isPlayerPosition;
    }

    private void Initialize(GameObject[] areas, int areaIndex)
    {
        GameObject area = Instantiate(areas[areaIndex], transform.forward * _spawnPosition, transform.rotation);
        _activeAreas.Add(area);
        _spawnPosition += _areaLenght;
    }

    private void SpawnStartingAreas()
    {
        Initialize(_startingAreas, Random.Range(0, _startingAreas.Length));
        
        for (int i = 1; i < _startingCountAreas; i++)
        {
            Initialize(_playingAreas, Random.Range(0, _playingAreas.Length));
        }
    }

    private void DeletePassedArea()
    {
        Destroy(_activeAreas[0]);
        _activeAreas.RemoveAt(0);
    }
    
    private void DeleteAllAreas()
    {
        foreach (var item in _activeAreas)
        {
            Destroy(item);
        }
        
        _activeAreas.Clear();
    }

    private void OnRespawn()
    {
        DeleteAllAreas();
        _spawnPosition = 0;
        SpawnStartingAreas();
    }
}
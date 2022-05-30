using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreasGenerator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _startingAreas;
    [SerializeField] private GameObject[] _playingAreas;
    [SerializeField] private Transform _playerPosition;

    private List<GameObject> _activeAreas = new List<GameObject>();

    private float _spawnPosition = 0;
    private float _tileLenght = 200;
    private int _startTiles = 6;

    private void OnEnable()
    {
        _player.Respawn += OnRespawn;
    }

    private void OnDisable()
    {
        _player.Respawn -= OnRespawn;
    }

    private void Start()
    {
        SpawnStartingAreas();
    }

    private void Update()
    {
        if (_player.IsRespawn == false)
        {
            if (_playerPosition.position.z  > _spawnPosition - (_startTiles * _tileLenght))
            {
                Initialize(_playingAreas,Random.Range(0, _playingAreas.Length));
                DeletePassedArea();
            }
        }
    }

    private void Initialize(GameObject[] areas, int tileIndex)
    {
        GameObject area = Instantiate(areas[tileIndex], transform.forward * _spawnPosition, transform.rotation);
        _activeAreas.Add(area);
        _spawnPosition += _tileLenght;
    }

    private void SpawnStartingAreas()
    {
        for (int i = 0; i < _startTiles; i++)
        {
            if (i == 0)
            {
                Initialize(_startingAreas, Random.Range(0, _startingAreas.Length));
            }

            Initialize(_playingAreas, Random.Range(0, _playingAreas.Length));
        }
    }

    private void DeletePassedArea()
    {
        Destroy(_activeAreas[0]);
        _activeAreas.RemoveAt(0);
    }
    
    public void DeleteAllAreas()
    {
        foreach (var item in _activeAreas)
        {
            Destroy(item);
        }
        
        _activeAreas.Clear();
    }

    public void OnRespawn()
    {
        DeleteAllAreas();
        Debug.Log($"позиция игрока: {_player.transform.position}" +
                  $"стандартная позиция: {_playerPosition.position}");

        _spawnPosition = 0;
        
        SpawnStartingAreas();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject characterControllerPlayer;
    [SerializeField] private GameObject rigidbodyPlayer;
    private string gameObjectTag = "Player";
    public void OnSpawnCharacterControllerPlayer()
    {
        characterControllerPlayer.tag = gameObjectTag;
        Instantiate(characterControllerPlayer, spawnPoint.position, Quaternion.identity);
    }

    public void OnSpawnRigidbodyPlayer()
    {
        rigidbodyPlayer.tag = gameObjectTag;
        Instantiate(rigidbodyPlayer, spawnPoint.position, Quaternion.identity);
    }

    public void OnClearSpawnedPlayer()
    {
        var spawnedPlayer = GameObject.FindGameObjectWithTag(gameObjectTag);
        Destroy(spawnedPlayer);
    }
}

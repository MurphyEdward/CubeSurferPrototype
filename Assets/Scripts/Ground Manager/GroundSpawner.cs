using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    private int NumberOfTracksSpawned;

    [SerializeField] private List<GameObject> _groundTrackPrefab;

    private void OnEnable()
    {
        NumberOfTracksSpawned = _groundTrackPrefab.Count;

        GenerateLevelEventTrigger.OnFinishZoneEnter += SpawnRandomTrack;
    }

    private void SpawnRandomTrack()
    {
        int randomTrackNumber = Random.Range(0, 3);
        Vector3 newTrackPosition = new(0, 0, _groundTrackPrefab[randomTrackNumber].transform.localScale.z * NumberOfTracksSpawned);
        Instantiate(_groundTrackPrefab[randomTrackNumber], newTrackPosition, Quaternion.identity);
        NumberOfTracksSpawned++;
    }

    private void OnDisable()
    {
        GenerateLevelEventTrigger.OnFinishZoneEnter -= SpawnRandomTrack;
    }
}

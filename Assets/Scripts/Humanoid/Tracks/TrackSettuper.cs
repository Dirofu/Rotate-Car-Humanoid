using System.Collections.Generic;
using UnityEngine;

public class TrackSettuper : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;

    [Header("Pool Settup")]
    [SerializeField] private GameObject _poolPrefab;
    [SerializeField] private TrackDeactivator _trackPrefab;
    [SerializeField] private int _count;

    [SerializeField] private List<TrackDeactivator> _tracks = new List<TrackDeactivator>();
    
    private GameObject _poolRoot;

    private void Start()
    {
        InitializePool();
    }

    public void SpawnTrackOnLeftFoot() => SpawnTrackOnFoot(_leftFoot.position);
    public void SpawnTrackOnRightFoot() => SpawnTrackOnFoot(_rightFoot.position);

    private void SpawnTrackOnFoot(Vector3 position)
    {
        GameObject temp = GetFirstUnactiveTrack();
        temp.SetActive(true);
        temp.transform.position = position;
    }

    private GameObject GetFirstUnactiveTrack()
    {
        foreach (var item in _tracks)
        {
            if (item.gameObject.activeInHierarchy == false)
                return item.gameObject;
        }
        return null;
    }

    private void InitializePool()
    {
        _poolRoot = Instantiate(_poolPrefab);

        for (int i = 0; i < _count; i++)
        {
            TrackDeactivator tempTrack = Instantiate(_trackPrefab, _poolRoot.transform);
            _tracks.Add(tempTrack);
            tempTrack.gameObject.SetActive(false);
        }
    }
}
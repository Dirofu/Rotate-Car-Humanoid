using UnityEngine;

public class TrackAnimatorRedirector : MonoBehaviour
{
    [SerializeField] private TrackSettuper _track;

    public void SpawnTrackOnLeftFoot() => _track.SpawnTrackOnLeftFoot();
    public void SpawnTrackOnRightFoot() => _track.SpawnTrackOnRightFoot();
}

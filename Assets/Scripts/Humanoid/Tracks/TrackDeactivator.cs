using System.Collections;
using UnityEngine;

public class TrackDeactivator : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate = 3f;

    private void OnEnable()
    {
        StartCoroutine(DeactivateForTime());
    }

    private IEnumerator DeactivateForTime()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        gameObject.SetActive(false);
    }
}

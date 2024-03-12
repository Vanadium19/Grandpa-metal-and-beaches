using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Transform _cornerPoint;

    private Transform _transform;

    private void Awake() => _transform = transform;

    public Vector3 GetRandomPointInZone()
    {
        Vector3 point = _transform.position;

        point += Vector3.right * Random.Range(-_cornerPoint.localPosition.x, _cornerPoint.localPosition.x);
        point += Vector3.forward * Random.Range(-_cornerPoint.localPosition.z, _cornerPoint.localPosition.z);

        return point;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if (_cornerPoint == null)
            return;

        Gizmos.DrawCube(transform.position, Vector3.ProjectOnPlane(_cornerPoint.localPosition * 2, Vector3.up));
    }
}

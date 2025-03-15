using Scripts.Schemas;
using UnityEngine;

public class NetworkSyncEntityPosition : MonoBehaviour, ISetup<Vector2D>
{
    [SerializeField] private float speed = 5f;

    private Vector3 _targetPosition;

    // public void OnChange(Vector2D current)
    // {
    //     Debug.Log($"Change position {current}");
    //     _targetPosition = new Vector3(current.x, current.y, 0);
    // }

    private Vector2D _remotePosition;

    public void Update()
    {
        Debug.Log($"Remote {name} {_remotePosition.x} {_remotePosition.y} ");
        _targetPosition = new Vector3(_remotePosition.x, _remotePosition.y, 0);
        
        transform.position = Vector3.Lerp(transform.position, _targetPosition, speed * Time.deltaTime);
    }

    public void Setup(Vector2D value)
    {
        _remotePosition = value;
        NetworkManager.Instance.Callbacks.BindTo(value, _remotePosition);
    }
}
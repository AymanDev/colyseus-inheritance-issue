using Scripts.Schemas;
using UnityEngine;

[RequireComponent(typeof(NetworkSyncEntityPosition))]
public class DynamicEntityController : MonoBehaviour, ISetup<Entity>
{
    private NetworkSyncEntityPosition _remotePosition;
    private Entity _entity;

    private void Awake()
    {
        _remotePosition = GetComponent<NetworkSyncEntityPosition>();
    }

    public void Setup(Entity value)
    {
        _entity = value;
        NetworkManager.Instance.Callbacks.BindTo(value, _entity);

        _remotePosition.Setup(value.position);
    }
}
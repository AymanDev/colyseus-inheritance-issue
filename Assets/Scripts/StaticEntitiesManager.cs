using System.Collections.Generic;
using Scripts.Schemas;
using UnityEngine;

public class StaticEntitiesManager : RemoteMapHandler<Entity>
{
    [SerializeField] private GameObject prefab;

    private readonly Dictionary<string, GameObject> _entities = new();

    public override void Initialize()
    {
        NetworkManager.Instance.Callbacks.OnAdd(state => state.staticEntities.entities, OnAdded);
        NetworkManager.Instance.Callbacks.OnAdd(state => state.staticEntities.entities, OnRemoved);
    }

    public override void OnAdded(string key, Entity entity)
    {
        var obj = Instantiate(prefab, transform);
        obj.transform.position = new Vector3(entity.position.x, entity.position.y, 0);

        _entities.Add(key, obj);
    }

    public override void OnRemoved(string key, Entity entity)
    {
        Destroy(_entities[key]);

        _entities.Remove(key);
    }
}
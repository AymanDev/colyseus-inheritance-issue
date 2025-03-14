using System.Collections.Generic;
using Scripts.Schemas;
using UnityEngine;

public class StaticEntitiesManager : RemoteMapHandler<Entity>
{
    [SerializeField] private GameObject prefab;

    private readonly Dictionary<string, GameObject> _entities = new();

    public override void Initialize()
    {
        NetworkManager.Instance.Callbacks.Listen(state => state.staticEntities, (staticEntities, _) => {
          NetworkManager.Instance.Callbacks.OnAdd(staticEntities, s => s.entities, OnAdded);
          NetworkManager.Instance.Callbacks.OnAdd(staticEntities, s => s.entities, OnRemoved);
        });
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

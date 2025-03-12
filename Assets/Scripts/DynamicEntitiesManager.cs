using System.Collections.Generic;
using Scripts.Schemas;
using UnityEngine;

/**
 * I wanted to pass <see cref="DynamicEntity"/> as type to generic here
 * but generated C# classes from Colyseus do not create and support generics in them.
 *
 * This is not possible right now because it will give error `Attribute argument cannot use type parameters.`.
 * If I try to do it manually in <see cref="EntitiesMap{T}"/>
 */
public class DynamicEntitiesManager : RemoteMapHandler<Entity>
{
    [SerializeField] private GameObject prefab;

    private readonly Dictionary<string, GameObject> _entities = new();

    public override void Initialize()
    {
        NetworkManager.Instance.Callbacks.OnAdd(state => state.dynamicEntities.entities, OnAdded);
        NetworkManager.Instance.Callbacks.OnRemove(state => state.dynamicEntities.entities, OnRemoved);
    }

    public override void OnAdded(string key, Entity entity)
    {
        if (entity is not DynamicEntity dynamicEntity)
        {
            return;
        }

        var obj = Instantiate(prefab, transform);

        var controller = obj.GetComponent<DynamicEntityController>();
        controller.Setup(dynamicEntity);
        _entities.Add(key, obj);
    }

    public override void OnRemoved(string key, Entity entity)
    {
        Destroy(_entities[key]);

        _entities.Remove(key);
    }
}
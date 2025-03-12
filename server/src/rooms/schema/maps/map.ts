import { MapSchema, Schema, type } from "@colyseus/schema";
import { Entity } from "../entities/entity";

export abstract class EntitiesMap<T extends Entity = Entity> extends Schema {
  @type({ map: Entity })
  entities = new MapSchema<T>();

  getEntityByKey(key: string) {
    return this.entities.get(key);
  }

  addEntity(entity: T) {
    this.entities.set(entity.uuid, entity);
  }

  removeEntity(entity: T) {
    this.removeEntityByKey(entity.uuid);
  }

  removeEntityByKey(key: string) {
    this.entities.delete(key);
  }
}

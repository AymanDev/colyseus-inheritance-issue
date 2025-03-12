import { Player } from "../entities/player";
import { DynamicEntitiesMap } from "./dynamic-entities-map";

export class PlayerMap extends DynamicEntitiesMap<Player> {
  override getEntityByKey(key: string): Player {
    return this.entities.get(key);
  }

  override addEntity(entity: Player): void {
    this.entities.set(entity.sessionId, entity);
  }

  override removeEntity(entity: Player): void {
    this.removeEntityByKey(entity.sessionId);
  }

  override removeEntityByKey(key: string): void {
    this.entities.delete(key);
  }
}

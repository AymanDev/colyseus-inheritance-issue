import { DynamicEntity, IUpdate } from "../entities/dynamic";
import { WorldState } from "../state";
import { EntitiesMap } from "./map";

export class DynamicEntitiesMap<T extends DynamicEntity = DynamicEntity>
  extends EntitiesMap<T>
  implements IUpdate
{
  shouldUpdate(world: WorldState): boolean {
    return this.entities.values.length > 0;
  }

  onUpdate(world: WorldState): void {
    for (const entity of this.entities.values()) {
      if (entity.shouldBeDeleted) {
        this.entities.delete(entity.uuid);
        continue;
      }

      if (entity.shouldUpdate(world)) {
        continue;
      }

      entity.onUpdate(world);
    }
  }
}

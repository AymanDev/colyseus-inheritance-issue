import { entity } from "@colyseus/schema";
import { WorldState } from "../state";
import { DynamicEntity } from "./dynamic";

@entity
export class SlimeEntity extends DynamicEntity {
  override onUpdate(world: WorldState): void {
    const player = world.players.entities.values().toArray()[0];

    if (!player) {
      return;
    }

    const dir = player.position.clone().minus(this.position).normalize();

    this.position.add(dir);
  }
}

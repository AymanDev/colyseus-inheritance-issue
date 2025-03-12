import { type } from "@colyseus/schema";
import { Entity } from "./entity";
import { Health } from "../common/health";
import { WorldState } from "../state";

export interface IUpdate {
  shouldUpdate(world: WorldState): boolean;

  onUpdate(world: WorldState): void;
}

export class DynamicEntity extends Entity implements IUpdate {
  shouldBeDeleted: boolean;

  @type(Health)
  health = new Health();

  shouldUpdate(world: WorldState): boolean {
    return !this.shouldBeDeleted;
  }

  onUpdate(world: WorldState): void {
    if (Math.random() > 0.5) {
      this.health.damage(1);
    }

    if (this.health.current === 0) {
      this.shouldBeDeleted = true;
    }
  }
}

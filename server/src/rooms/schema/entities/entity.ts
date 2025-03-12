import { entity, Schema, type } from "@colyseus/schema";
import { Vector2D } from "../common/vector2d";

@entity
export class Entity extends Schema {
  @type("string")
  uuid: string;

  @type(Vector2D)
  position: Vector2D;

  constructor() {
    super();

    this.uuid = `fake_uuid_${Math.random()}_${Math.random() * 10}_${
      Math.random() * 100
    }`;

    this.position = Vector2D.random();
  }
}

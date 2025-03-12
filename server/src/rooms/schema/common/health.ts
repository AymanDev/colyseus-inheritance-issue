import { Schema, type } from "@colyseus/schema";

export class Health extends Schema {
  @type("uint32")
  max: number;

  @type("uint32")
  current: number;

  damage(value: number) {
    if (value > this.current) {
      this.current = 0;
      return;
    }

    this.current -= value;
  }
}

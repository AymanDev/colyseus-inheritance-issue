import { entity, type } from "@colyseus/schema";
import { DynamicEntity } from "./dynamic";

@entity
export class Player extends DynamicEntity {
  @type("string")
  name: string;

  sessionId: string;
}

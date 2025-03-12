import { Schema, type } from "@colyseus/schema";
import { StaticEntitiesMap } from "./maps/static-entities-map";
import { DynamicEntitiesMap } from "./maps/dynamic-entities-map";
import { PlayerMap } from "./maps/player-map";

export class WorldState extends Schema {
  @type(StaticEntitiesMap)
  staticEntities = new StaticEntitiesMap();

  @type(DynamicEntitiesMap)
  dynamicEntities = new DynamicEntitiesMap();

  @type(PlayerMap)
  players = new PlayerMap();
}

import { Room, Client } from "@colyseus/core";
import { WorldState } from "./schema/state";
import { Player } from "./schema/entities/player";
import { Entity } from "./schema/entities/entity";
import { SlimeEntity } from "./schema/entities/slime";

export class MyRoom extends Room<WorldState> {
  state = new WorldState();

  onCreate(options: any) {
    for (let idx = 0; idx < 5; idx++) {
      const entity = new Entity();
      this.state.staticEntities.addEntity(entity);
    }

    for (let idx = 0; idx < 5; idx++) {
      const slime = new SlimeEntity();
      this.state.dynamicEntities.addEntity(slime);
    }

    this.onMessage("move", (client, { x, y }) => {
      const player = this.state.players.getEntityByKey(client.sessionId);

      player.position.x = x;
      player.position.y = y;
    });

    this.setSimulationInterval(this.onUpdate.bind(this));
  }

  onJoin(client: Client, options: { name: string }) {
    const player = new Player();
    player.sessionId = client.sessionId;
    player.name = options.name;

    this.state.players.addEntity(player);
  }

  onUpdate() {
    if (this.state.dynamicEntities.shouldUpdate(this.state)) {
      this.state.dynamicEntities.onUpdate(this.state);
    }

    if (this.state.players.shouldUpdate(this.state)) {
      this.state.players.onUpdate(this.state);
    }
  }

  onLeave(client: Client, consented: boolean) {
    this.state.players.removeEntityByKey(client.sessionId);
  }

  onDispose() {
    console.log("room", this.roomId, this.roomName, "disposing...");
  }
}

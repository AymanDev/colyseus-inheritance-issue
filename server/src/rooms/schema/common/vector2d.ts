import { Schema, type } from "@colyseus/schema";

export class Vector2D extends Schema {
  @type("number")
  x: number;

  @type("number")
  y: number;

  // ! Warning ! NEVER USE WITHOUT CLONE
  // Usage without cloning scheme will result in unwanted
  // behavior and syncing wrong positions
  // for wrong entities
  static readonly ZERO = new Vector2D(0, 0);

  constructor(x: number, y: number) {
    super();

    this.x = x;
    this.y = y;
  }

  public get magnitude(): number {
    return Math.sqrt(this.x * this.x + this.y * this.y);
  }

  getDistanceSqr(point: Vector2D) {
    const x = this.x - point.x;
    const y = this.y - point.y;

    return x * x + y * y;
  }

  getDistance(point: Vector2D) {
    return Math.sqrt(this.getDistanceSqr(point));
  }

  minus(vector: Vector2D) {
    this.x -= vector.x;
    this.y -= vector.y;

    return this;
  }

  add(vector: Vector2D) {
    this.x += vector.x;
    this.y += vector.y;

    return this;
  }

  multiply(multiplier: number) {
    this.x *= multiplier;
    this.y *= multiplier;

    return this;
  }

  sqr() {
    this.x *= this.x;
    this.y *= this.y;

    return this;
  }

  normalize() {
    const magnitude = this.magnitude;

    this.x /= magnitude;
    this.y /= magnitude;

    return this;
  }

  toPhysicsWorld() {
    return { x: this.x, y: this.y };
  }

  static random() {
    return new Vector2D(Math.random() * 128, Math.random() * 128);
  }
}

import {assert} from "chai";
import {spinWords} from '../src/spinWords';

describe("spinWords", () =>{
  it("should pass some fixed tests", () => {
    assert.strictEqual(spinWords("Hey fellow warriors"), "Hey wollef sroirraw");
  });
});
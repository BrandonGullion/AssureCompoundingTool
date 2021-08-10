import React, { useState } from "react";
import { AssureContext } from "../AssureContext";
import CompoundFormPageOne from "./CompoundFormPageOne";
import CompoundFormPageTwo from "./CompoundFormPageTwo";

export default function Frame() {
    const [counter, setCounter] = useState(1);

    // TODO :: Make the frame have an overlay and pass in multiple items into the frame, allowing them
    // to slide depending on the counter

    return (
        <div className="frame">
            <AssureContext>
                <div>
                    <CompoundFormPageOne></CompoundFormPageOne>
                </div>
                <div>
                    <CompoundFormPageTwo></CompoundFormPageTwo>
                </div>
            </AssureContext>
        </div>
    );
}

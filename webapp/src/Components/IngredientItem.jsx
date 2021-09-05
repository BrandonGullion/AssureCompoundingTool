import React, { useContext, useEffect, useState } from "react";
import { IoClose } from "react-icons/io5";
import { AssureDispatchContext, AssureStateContext } from "../AssureContext";

export default function IngredientItem(props) {
    const [drugName, setDrugName] = useState("");
    const [percent, setPercent] = useState("");
    const [grams, setGrams] = useState("");
    const [closeButtonVisibility, setCloseButtonVisibility] = useState(false);

    const { uid } = props;

    const state = useContext(AssureStateContext);
    const dispatch = useContext(AssureDispatchContext);

    useEffect(() => {
        console.log("Checking button visibility")
        state.ingredientArray.length >= 2
            ? setCloseButtonVisibility(true)
            : setCloseButtonVisibility(false);
    }, [state.ingredientArray]);

    return (
        <div style={{ width: "100%" }}>
            <input
                onChange={(e) => setDrugName(e.target.value)}
                style={{ width: "47%" }}
                className="default-input"
            ></input>
            <input
                onChange={(e) => setPercent(e.target.value)}
                style={{ width: "10%" }}
                className="default-input"
            ></input>
            <input
                onChange={(e) => setGrams(e.target.value)}
                style={{ width: "10%", marginRight: "0" }}
                className="default-input"
            ></input>
            <button
                className="close-button"
                onClick={()=> dispatch({type:"REMOVE_INGREDIENT_ITEM", payload:uid})}
                style={{
                    position: "relative",
                    top: "4px",
                    visibility: closeButtonVisibility ? "" : "hidden",
                }}
            >
                <IoClose className="close-button-icon"></IoClose>
            </button>
        </div>
    );
}

import React, { useContext, useEffect } from "react";
import { AssureDispatchContext, AssureStateContext } from "../AssureContext";

export default function CompoundFormPageTwo() {
    const dispatch = useContext(AssureDispatchContext);
    const state = useContext(AssureStateContext);
    const { ingredientArray } = state;

    // Checks to see if the ingredient item container is larger than 200px, if so
    // then it will add a border
    useEffect(() => {
        let ingredientDiv = document.getElementById(
            "ingredient-items-container"
        );

        console.log(ingredientDiv.clientHeight);
        if (ingredientDiv === undefined) return;

        // If there are enough ingredients, update the border
        if (ingredientDiv.clientHeight >= 200) {
            ingredientDiv.classList.add("ingredient-list-container-border");
        }

        // Remove any border when decrementing count
        if (ingredientDiv.clientHeight < 200) {
            ingredientDiv.classList.remove("ingredient-list-container-border");
        }
    }, [ingredientArray]);

    return (
        <div className="compounding-form-page-container">
            <label
                style={{ position: "relative", left: "40px", width: "100%" }}
            >
                Compound Submission Form
            </label>
            <hr className="default-linebreak" />
            <label style={{ position: "relative", left: "40px" }}>
                Ingredients
            </label>
            <br></br>
            <div id="ingredient-titles" style={{ marginTop: "10px" }}>
                <label
                    style={{
                        position: "relative",
                        left: "10px",
                        bottom: "5px",
                    }}
                >
                    Name
                </label>
                <label
                    style={{
                        position: "relative",
                        left: "300px",
                        bottom: "5px",
                    }}
                >
                    %
                </label>
                <label
                    style={{
                        position: "relative",
                        left: "390px",
                        bottom: "5px",
                    }}
                >
                    g
                </label>
            </div>
            <div
                id="ingredient-items-container"
                className="ingredient-list-container"
            >
                {ingredientArray.map((x) => x.component)}
            </div>
            <button
                onClick={() => dispatch({ type: "ADD_INGREDIENT_ITEM" })}
                className="default-button add-ingredient-button"
            >
                +
            </button>

            {/* Information for mix type, total grams and repeats*/}
            <div
                className="input-container"
                style={{ position: "absolute", top: "400px" }}
            >
                <div className="input-label-item">
                    <label style={{ position: "relative", left: "10px" }}>
                        Mixture Type
                    </label>
                    <select
                        className="default-dropdown"
                        style={{ width: "270px" }}
                    >
                        {/* TODO :: Add selection tags in here */}
                        <option>Example</option>
                    </select>
                </div>
                <div className="input-label-item" style={{ width: "15%" }}>
                    <label style={{ position: "relative", left: "20px" }}>
                        Total (g)
                    </label>
                    <input
                        style={{ textAlign: "center" }}
                        placeholder="30"
                        className="default-input"
                    />
                </div>

                <div className="input-label-item" style={{ width: "15%" }}>
                    <label style={{ position: "relative", left: "30px" }}>
                        Refills
                    </label>
                    <input
                        style={{ textAlign: "center" }}
                        placeholder="1"
                        className="default-input"
                    />
                </div>
            </div>
            <div style={{ position: "relative", top: "390px" }}>
                <button
                    onClick={() => dispatch({
                        type: "TO_INTRO_SLIDE",
                        payload: -1,
                    })}
                    className="default-button back-button"
                >
                    Back
                </button>
                <button
                    onClick={() => dispatch({
                        type: "TO_FINAL_SLIDE",
                        payload: 1,
                    })}
                    className="default-button next-button"
                >
                    Next
                </button>
            </div>
        </div>
    );
}

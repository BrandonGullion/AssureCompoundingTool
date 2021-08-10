import React, { useState, createContext, useEffect, useReducer } from "react";
import IngredientItem from "./Components/IngredientItem";
import { v4 as uuidv4 } from "uuid";

export const AssureDispatchContext = createContext();
export const AssureStateContext = createContext();

export const AssureContext = (props) => {
    // Creates a new ingredient item with a unique uid, and appends it to the list
    // This is then given to the dispatch and the current list is re-assigned
    const addIngredientItem = () => {
        const uid = uuidv4();
        const ingredientItem = {
            uid: uid,
            component: <IngredientItem key={uid} uid={uid}></IngredientItem>,
        };
        return ingredientItem;
    };

    const initialState = {
        ingredientArray: [addIngredientItem()],
        slideCounter: 0,
    };

    const reducer = (state, action) => {
        switch (action.type) {
            case "ADD_INGREDIENT_ITEM":
                console.log("adding ingredient");
                return {
                    ...state,
                    ingredientArray: [
                        ...state.ingredientArray,
                        addIngredientItem(),
                    ],
                };
            case "TO_INTRO_SLIDE":
                console.log("Navigating to first slide...");
                return { ...state };
            case "TO_INGREDIENT_SLIDE":
                console.log("Navigating to ingredient slide");
                return { ...state };
            case "TO_FINAL_SLIDE":
                console.log("Navigating to final slide...");
                return { ...state };
            // use the payload to find the desired ingredient index and then remove from the list
            case "REMOVE_INGREDIENT_ITEM":
                console.log(`Removing list item w/ id of ${action.payload}`);
                let ingredientIndex = state.ingredientArray.findIndex(
                    (x) => x.uid === action.payload
                );

                // This is required for subsequent re-renders when the app decides to 
                // try and load 2 - 3 times...
                if (ingredientIndex === -1) {
                    return { ...state };
                }

                // Returns the new state along with the spliced array
                return {
                    ...state,
                    ingredientArray: state.ingredientArray.splice(
                        ingredientIndex,
                        1
                    ),
                };
            default:
                break;
        }
    };

    const [state, dispatch] = useReducer(reducer, initialState);

    return (
        <AssureDispatchContext.Provider value={dispatch}>
            <AssureStateContext.Provider value={state}>
                {props.children}
            </AssureStateContext.Provider>
        </AssureDispatchContext.Provider>
    );
};

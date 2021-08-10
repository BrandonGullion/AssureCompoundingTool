import React from "react";

export default function CompoundFormPageOne() {
    return (
        <div className="compounding-form-page-container">
            <label style={{ position: "relative", left: "40px" }}>
                Compound Submission Form
            </label>
            <hr className="default-linebreak" />
            {/* Container for first row of elements */}
            <div
                style={{
                    position: "relative",
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                }}
            >
                <div className="input-container">
                    <div
                        style={{ width: "min-content" }}
                        className="input-label-item"
                    >
                        <label style={{ width: "80px" }}>Carrier No.</label>
                        <input
                            className="default-input"
                            placeholder="11"
                            style={{
                                width: "15%",
                                minWidth: "40px",
                                textAlign: "center",
                            }}
                        ></input>
                    </div>
                    <div className="input-label-item">
                        <label style={{ position: "relative", left: "10px" }}>
                            Group No.
                        </label>
                        <input
                            className="default-input"
                            placeholder="012345"
                        ></input>
                    </div>
                    <div className="input-label-item">
                        <label style={{ position: "relative", left: "10px" }}>
                            Member Id
                        </label>
                        <input
                            style={{width:"95%"}}
                            className="default-input"
                            placeholder="0000001445662101"
                        ></input>
                    </div>
                </div>
                <div className="input-container" style={{ marginTop: "20px" }}>
                    <div className="input-label-item">
                        <label style={{ position: "relative", left: "10px" }}>
                            First Name
                        </label>
                        <input
                            placeholder="John"
                            className="default-input"
                        ></input>
                    </div>
                    <div className="input-label-item">
                        <label style={{ position: "relative", left: "10px" }}>
                            Last Name
                        </label>
                        <input
                            className="default-input"
                            placeholder="Doe"
                        ></input>
                    </div>
                    <div
                        className="input-label-item"
                        style={{ width: "120px" }}
                    >
                        <label
                            style={{
                                position: "relative",
                                left: "10px",
                                width: "125px",
                            }}
                        >
                            Date of Birth
                        </label>
                        <input
                            className="default-input"
                            style={{ width: "60%", textAlign: "center" }}
                            placeholder="dd/mm/yyyy"
                        ></input>
                    </div>
                </div>
                <div className="input-container" style={{ marginTop: "10px" }}>
                    <div
                        className="input-label-item"
                        style={{ width: "120px" }}
                    >
                        <label
                            style={{
                                position: "relative",
                                left: "10px",
                                width: "200px",
                            }}
                        >
                            Store Provider Code
                        </label>
                        <input
                            className="default-input"
                            placeholder="1235584"
                            style={{ width: "100%" }}
                        ></input>
                    </div>
                </div>
            </div>
            <div>
                <button className="default-button next-button">Next</button>
            </div>
        </div>
    );
}

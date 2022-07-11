
//import './custom.css'

import React, { Component } from "react";

// Routes
import Routes from "./components/Routes";

import { setAuthToken } from "./helpers/setAuthToken";

function App() {
    // Check JWT token
    const token = localStorage.getItem("token");
    if (token) {
        setAuthToken(token);
    }

    return (
        <div>
            <Routes />
        </div>
    );
}

export default App;

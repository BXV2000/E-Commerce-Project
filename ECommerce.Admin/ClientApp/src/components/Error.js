import React, { Component } from "react";


export class Error extends Component{
    backToLogin = () => {
        // Remove token
        localStorage.removeItem("token");

        // Redirect user to Login page
        window.location.href = "/login";
    };
    render() {
        return (
            <div className="container">
                <h2 className="text-center">Error</h2>
                <button className="btn btn-primary" onClick={this.backToLogin}>
                    Back to Login
                </button>
            </div>
        );
    }
}


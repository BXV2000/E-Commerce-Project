import React, { Component, useRef } from "react";
import axios from "axios";
import { setAuthToken } from "../helpers/setAuthToken";

let baseAddress = "https://localhost:7024/api/";

export class Login extends Component{
    // Base api URL


    handleSubmit = () => {
        let loginPayload = {
            Username: this.refs.Username.value,
            Password: this.refs.Password.value
        }
        // Login request
        console.log(loginPayload);
        axios
            .post(baseAddress + "user/authenticate", loginPayload)
            .then((response) => {
                // Get token from response
                const token = response.data.token;
                console.log(token);
                // Set JWT token to local
                localStorage.setItem("token", token);

                // Set token to axios common header
                setAuthToken(token);

                // Redirect user to Home page
                window.location.href = "/";
            })
            .catch((error) => console.log(error));
    };
    render() {
        return (
            <section className="vh-100" style={{ backgroundColor: "#508bfc" }}>
                <div className="container py-5 h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div className="card shadow-2-strong" style={{ borderRadius: 25 }}>
                                <div className="card-body p-5 text-center">
                                    <h2 className="mb-5">Log In</h2>
                                   
                                        <div className="form-group mb-4">
                                            <input
                                                type="text"
                                                className="form-control form-control-lg"
                                                id="username"
                                                name="username"
                                                placeholder="Username"
                                                ref="Username"
                                                required
                                            />
                                        </div>
                                        <div className="form-outline mb-4">
                                            <input
                                                type="password"
                                                className="form-control form-control-lg"
                                                id="password"
                                                name="password"
                                                placeholder="Password"
                                                ref="Password"
                                                required
                                            />
                                        </div>
                                        <button
                                        className="btn btn-primary btn-lg btn-block"
                                        type="submit"
                                        onClick={this.handleSubmit}
                                        >
                                            Login
                                        </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        );
    }
}


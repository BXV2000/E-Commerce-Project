import React, { Component, useRef } from "react";
import axios from "axios";
import { setAuthToken } from "../helpers/setAuthToken";
import '../css/Login.css';


let baseAddress = "https://localhost:7024/api/";
export class Login extends Component{
    // Base api URL


    handleSubmit = (e) => {
        e.preventDefault();
        let loginPayload = {
            Username: this.refs.Username.value,
            Password: this.refs.Password.value
        }
        // Login request
        if(loginPayload.Username==''||loginPayload.Password==''){
            alert("Do not leave fields empty!!!")
            return;
        }
        axios
            .post(baseAddress + "user/authenticate", loginPayload)
            .then((response) => {
                // Get token from response
                const token = response.data.token;
                
                // Set JWT token to local
                localStorage.setItem("token", token);

                // Set token to axios common header
                setAuthToken(token);

                // Redirect user to Home page
               
                // window.location.href="/"
                if(token){
                    alert("Login success. Redirecting to Dashboard")
                    window.location.href="/"
                }
                if(!token){
                    alert("Wrong Username or Password")
                }
                // if(!response.data.token)
                
            })
            .catch((error) => {
                alert("Something went wrong")
            });
    };
    render() {
        return (
            <div className="login-container">
                <form className="card-body p-5 text-center login-input-container">
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
                        className="button"
                        type="submit"
                        onClick={this.handleSubmit}
                        >
                            Login
                        </button>
                </form>
            </div>
          );
    }
}


import React, { Component, useState } from 'react';
import axios from 'axios';


let baseURL = "https://localhost:7024/api/"
export class VegetableCreate extends Component {
    

    constructor(props) {
        super(props);
        this.state = {
            message: "",

        };
    }

    onCreateVegetable = () => {
        let vegetableInfo = {
            Name: this.refs.Name.value,
            CategoryId: this.refs.CategoryId.value,
            Price: this.refs.Price.value,
            Stock: this.refs.Stock.value,
        };
        console.log("sent");
        axios.post(baseURL+"Vegetable", vegetableInfo)
            .then(res => {
                this.setState({ message: res.data })
                alert("Vegetable created Success!");
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            })     
    }

    

    render() {
        return (
            <div>
                <h2>Vegetables Create</h2>

                <table>
                    <thead>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Category Id</td>
                            <td><input type="text" ref="CategoryId" /></td>
                        </tr>
                        <tr>
                            <td>Name</td>
                            <td><input type="text" ref="Name"/></td>
                        </tr>
                        <tr>
                            <td>Price</td>
                            <td><input type="text" ref="Price"  /></td>
                        </tr>
                        <tr>
                            <td>Stock</td>
                            <td><input type="text" ref="Stock"  /></td>
                        </tr>
                        <tr>
                            <td><button onClick={this.onCreateVegetable}>Create</button></td>
                        </tr>
                    </tbody>
                </table>
                
            </div>
        );
    }

}

import React, { Component, useState } from 'react';
import axios from 'axios';


let baseURL = "https://localhost:7024/api/"
export class ImageCreate extends Component {
    

    constructor(props) {
        super(props);
        this.state = {
            message:"",
        };
    }

    onCreateImage = () => {
        let imageInfo = {
            VegetableId: this.refs.VegetableId.value,
            ImageURL: this.refs.ImageURL.value
        };
        //console.log(imageInfo)
        axios.post(baseURL+"Image", imageInfo)
            .then(res => {
                this.setState({ message: res.data })
                alert("Image created Success!");
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            })     
    }

    

    render() {
        return (
            <div>
                <h2>Images Create</h2>

                <table>
                    <thead>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Vegetable Id</td>
                            <td><input type="text" ref="VegetableId"  /></td>
                        </tr>
                        <tr>
                            <td>Image URL</td>
                            <td><input type="text" ref="ImageURL"/></td>
                        </tr>
                        <tr>
                            <td><button onClick={this.onCreateImage}>Create</button></td>
                        </tr>
                    </tbody>
                </table>
                
            </div>
        );
    }

}

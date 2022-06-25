import React, { Component, useState } from 'react';
import axios from 'axios';


let baseURL = "https://localhost:7024/api/Image"
export class ImageCreate extends Component {
    

    constructor(props) {
        super(props);
        this.state = {
        }
    }
    render() {
        return (
          
            <div>
                <h2>Images Create</h2>
                <form method="post">
                    <table>
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Vegetable Id</td>
                                <td><input type="text" name="VegetableId"  /></td>
                            </tr>
                            <tr>
                                <td>Image URL</td>
                                <td><input type="text" name="ImageURL"/></td>
                            </tr>
                            <tr>
                                <td><input type="submit" /></td>
                            </tr>
                        </tbody>
                    </table>
                </form>
                <button >Test</button>
            </div>
        );
    }

}

import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

let baseURL = "https://localhost:7024/api/Image"
export class Image extends Component {

    

    constructor(props) {
        super(props);
        this.state = {
            images: []
        };
    }

    refreshList() {
        axios.get(baseURL)
            .then(res => {
                this.setState({images:res.data})
            })
    }

    componentDidMount() {
       this.refreshList();
    }

    //componentDidUpdate() {
    //    this.refreshList();
    //}


    render() {
        const { images } = this.state;
        return (
            <div>
                <h2>Images List</h2>
                <Link to="/image-create" >Create Image</Link>
                <table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Vegetable Id</th>
                            <th>Image URL</th>
                        </tr>
                    </thead>
                    <tbody>
                        {images.map(img => (
                            <tr key={img.id}>
                                <td>{img.id}</td>
                                <td>{img.vegetableId}</td>
                                <td>{img.imageURL}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}

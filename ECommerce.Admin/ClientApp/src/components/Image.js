import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import './testStyles.css'

let baseURL = "https://localhost:7024/api/"
export class Image extends Component {
    constructor(props) {
        super(props);
        this.state = {
            images: [],
            message: "",
            isActive: false,
            getImage:[]
        };
    }

    refreshList() {
        axios.get(baseURL+"Image")
            .then(res => {
                this.setState({images:res.data})
            })
    }

    getImageInfo = (id) => {
        axios.get(baseURL + "Image/" + id)
            .then(res => {
                this.setState({ getImage: res.data });
                this.refs.Id.value = res.data.id
                this.refs.VegetableId.value = res.data.vegetableId
                this.refs.ImageURL.value = res.data.imageURL
            })

    }

    updateImage = () => {
        let imageInfo = {
            VegetableId: this.refs.VegetableId.value,
            ImageURL: this.refs.ImageURL.value
        };
        axios.put(baseURL + "Image/" + this.refs.Id.value, imageInfo)
            .then(res => {
                this.setState({ message: res.data })
                alert("Image added Success!");
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            })
    }

    deleteImage = (id) => {
        axios.delete(baseURL + "Image/" + id)
    }

    componentDidMount() {
       this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

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
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {images.map(img => (
                            <tr key={img.id}>
                                <td>{img.id}</td>
                                <td>{img.vegetableId}</td>
                                <td>{img.imageURL}</td>
                                <td>
                                    <button value={img.id} onClick={event => this.deleteImage(event.target.value)}>Delete</button>
                                    <button value={img.id} onClick={event => this.getImageInfo(event.target.value)}>Edit</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                    <div className="EditImageForm">
                        <h1> Edit Image </h1>
                        <table>
                            <tr>
                                <td>Id</td>
                                <input ref="Id" disabled />
                            </tr>
                            <tr>
                            <td>Vegetable Id</td>
                            <input ref="VegetableId"  />
                            </tr>
                            <tr>
                                <td>Image URL</td>
                            <input type="text" ref="ImageURL"  />
                            </tr>
                            <tr>
                            <button onClick={this.updateImage} >Update</button>
                            </tr>
                        </table>
                    </div>
            </div>
        );
    }

}

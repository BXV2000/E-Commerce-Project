import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import './testStyles.css'

let baseURL = "https://localhost:7024/api/"
export class Vegetable extends Component {
    constructor(props) {
        super(props);
        this.state = {
            vegetables: [],
            //message: "",
            //isActive: false,
            //getImage:[]
        };
    }

    refreshList() {
        axios.get(baseURL+"Vegetable")
            .then(res => {
                this.setState({ vegetables:res.data})
            })
    }

    //getImageInfo = (id) => {
    //    axios.get(baseURL + "Image/" + id)
    //        .then(res => {
    //            this.setState({ getImage: res.data });
    //            this.refs.Id.value = res.data.id
    //            this.refs.VegetableId.value = res.data.vegetableId
    //            this.refs.ImageURL.value = res.data.imageURL
    //        })

    //}

    //updateImage = () => {
    //    let imageInfo = {
    //        VegetableId: this.refs.VegetableId.value,
    //        ImageURL: this.refs.ImageURL.value
    //    };
    //    axios.put(baseURL + "Image/" + this.refs.Id.value, imageInfo)
    //        .then(res => {
    //            this.setState({ message: res.data })
    //            alert("Image update Success!");
    //        })
    //        .catch(error => {
    //            this.setState({ message: error.response.data });
    //            alert(this.state.message);
    //        })
    //}

    //deleteImage = (id) => {
    //    axios.delete(baseURL + "Image/" + id)
    //}

    componentDidMount() {
       this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { vegetables } = this.state;
        return (
            <div>
                <h2>Vegetable List</h2>
                <Link to="/vegetable-create" >Add new vegetable</Link>
                <table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Category Id</th>
                            <th>Price</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {vegetables.map(vegetable => (
                            <tr key={vegetable.id}>
                                <td>{vegetable.id}</td>
                                <td>{vegetable.categoryId}</td>
                                <td>{vegetable.price}</td>
                                <td>
                                    {/*<button value={vegetable.id} onClick={event => this.deleteImage(event.target.value)}>Delete</button>*/}
                                    {/*<button value={vegetable.id} onClick={event => this.getImageInfo(event.target.value)}>Edit</button>*/}
                                    <button value={vegetable.id} >Delete</button>
                                    <button value={vegetable.id} >Edit</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}

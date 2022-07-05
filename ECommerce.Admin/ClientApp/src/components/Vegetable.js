import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import './testStyles.css'
import '../css/Vegetable.css'


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

    deleteVegetable = (id) => {
        axios.delete(baseURL + "Vegetable/" + id)
    }

    componentDidMount() {
       this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { vegetables } = this.state;
        return (
            <div className="product-container">

                <h2>PRODUCTS</h2>
                <Link to="/vegetable-create" className="button"><i class="fa-solid fa-circle-plus"></i> CREATE</Link>
                <table >
                    <thead className="table-header">
                        <tr>
                            <th>Id</th>
                            <th>Category</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody className="table-body">
                        <tr>
                            <td>1</td>
                            <td>2</td>
                            <td>3</td>
                            <td>4</td>
                            <td>5</td>
                            <td className="button-container"><button className="button"><i class="fa-solid fa-pen"></i> Edit</button><button className="button delete-button"><i class="fa-solid fa-trash"></i> Delete</button></td>
                        </tr>
                        {vegetables.map(vegetable => (
                            <tr key={vegetable.id}>
                                <td>{vegetable.id}</td>
                                <td>{vegetable.categoryId}</td>
                                <td>{vegetable.name}</td>
                                <td>{vegetable.price}</td>
                                <td>{vegetable.stock}</td>
                                <td className="button-container">
                                    {/*<button className="button" value={vegetable.id} onClick={event => this.getVegetableInfo(event.target.value)}> <i class="fa-solid fa-pen"></i> Edit</button>*/}
                                    <button className="button delete-button" value={vegetable.id} onClick={event => this.deleteVegetable(event.target.value)}><i class="fa-solid fa-trash"></i> Delete</button>
                                    {/*<button value={vegetable.id} >Delete</button>*/}
                                    {/*<button value={vegetable.id} >Edit</button>*/}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}

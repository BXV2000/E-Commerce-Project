import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

let baseURL = "https://localhost:7024/api/"
export class Image extends Component {

    

    constructor(props) {
        super(props);
        this.state = {
            images: [],
            message:""
        };
    }

    refreshList() {
        axios.get(baseURL+"Image")
            .then(res => {
                this.setState({images:res.data})
            })
    }

    componentDidMount() {
       this.refreshList();
    }

    deleteImage = (id) => {
        console.log(id);
        axios.delete(baseURL +"Image/" + id)
            .then(res => window.location.assign("/Image"))
    }

    //editImage = (id) => {
    //    window.loacation.assign(baseURL + "Image/" + id)
    //}

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
                                    {/*<button value={img.id} onClick={event => this.deleteImage(event.target.value)}>Edit</button>*/}
                                    {/*<a href="/edit/{this.value}" value={img.id}>Delete</a>*/}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}

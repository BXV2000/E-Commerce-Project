
import React, { Component } from 'react';
import "../css/ProductList.css";
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import { ThirtyFpsRounded } from '@mui/icons-material';


let baseURL = "https://localhost:7024/api/"
export class Product extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id:this.props.match.params.productId,
            product:[],
            imageURL:"",
        };
    }
    
    getData = (id)=>{
        axios.get(baseURL+"vegetable/"+id)
            .then(res => {
                this.setState({product:res.data});
                console.log(this.state.product.images[0].imageURL)
                this.refs.Name.value = res.data.name
                this.refs.CategoryID.value = res.data.categoryId
                this.refs.Price.value = res.data.price
                this.refs.Stock.value = res.data.stock
                this.setState({imageURL:this.state.product.images[0].imageURL+"/"+this.state.product.images[0].id})
            })
    }

    updateData=(e)=>{
        e.preventDefault();
        var imagefile = document.querySelector('#file');
        if(!imagefile.files[0]){
            alert("Please choose image");
            return;
        }
        let data = {
            Name: this.refs.Name.value,
            CategoryId: this.refs.CategoryID.value,
            Price: this.refs.Price.value,
            Stock: this.refs.Stock.value
        };
        let img = new FormData();
        
        img.append('File', imagefile.files[0]);
        img.append('ImageName', "String");
        img.append('ImageURL', "URL");
        console.log(img.get('File'));
        axios.put(baseURL + "vegetable/" + this.state.product.id, data)
            .then(axios.put(baseURL + "image/" + this.state.product.images[0].id, img))
            .then(res => {
                this.setState({ message: res.data })
                alert("Product update Success!");
                window.location.href = "/product-list";
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            })
    }

    componentDidMount() {
        this.getData(this.state.id);
     }

   

    render() {
        const { product } = this.state;
        return (
            <div className="product-single">
                <div className="product-single-title-container">
                    <h1 className="product-single-title">Edit Product</h1>
                    <button className="button">Create</button>
                </div>
                <div className="product-single-container">
                    <div className="product-single-show">
                        <div className="product-single-show-top">
                            <img  src={(this.state.imageURL)?this.state.imageURL:"/ProductDummy.jpg"} alt="" className="product-single-img" />
                            <div className="product-single-show-top-title">
                                <span className="product-single-name">{product.name}</span>
                                <span className="product-single-id">{product.id}</span>
                            </div>
                        </div>
                        <div className="product-single-show-bottom">
                            <span className="product-single-show-bottom-title">Product Detail </span>
                            <div className="product-single-info">
                                <span className="product-single-tag">Category ID: </span>
                                <span className="product-single-data">{product.categoryId}</span>
                            </div>
                            <div className="product-single-info">
                                <span className="product-single-tag">Price: </span>
                                <span className="product-single-data">{product.price}</span>
                            </div>
                            <div className="product-single-info">
                                <span className="product-single-tag">Stock: </span>
                                <span className="product-single-data">{product.stock}</span>
                            </div>
                        </div>
                    </div>
                    <div className="product-single-update">
                        <span className="product-single-update-title">Edit Product</span>
                        <form className="product-single-update-form">
                            <div className="product-single-update-left">
                                <div className="product-single-update-item">
                                    <label >Product Name:</label>
                                    <input 
                                        type="text" 
                                        className="product-single-update-input" 
                                        placeholder={product.name}
                                        ref="Name"
                                    />
                                </div>
                                <div className="product-single-update-item">
                                    <label >Category ID:</label>
                                    <input 
                                        type="number" 
                                        className="product-single-update-input" 
                                        placeholder={product.categoryId}
                                        ref="CategoryID"
                                    />
                                </div>
                                <div className="product-single-update-item">
                                    <label >Price:</label>
                                    <input 
                                        type="number" 
                                        className="product-single-update-input" 
                                        placeholder={product.price}
                                        ref="Price"
                                    />
                                </div>
                                <div className="product-single-update-item">
                                    <label >Stock:</label>
                                    <input 
                                        type="number" 
                                        className="product-single-update-input" 
                                        placeholder={product.stock}
                                        ref="Stock"
                                    />
                                </div>
                            </div>
                            <div className="product-single-update-right">
                                <div>
                                <img src={(this.state.imageURL)?this.state.imageURL:"/ProductDummy.jpg"} alt=""  className="product-single-update-img" ></img>
                                <label htmlFor="file" className="product-single-upload-icon"><i class="fa fa-upload" aria-hidden="true"></i></label>
                                <input type="file" id='file' ref="ImageUpload" className="product-single-update-img-input"/>
                                </div>
                                <button className="button" onClick={this.updateData}>Update</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}
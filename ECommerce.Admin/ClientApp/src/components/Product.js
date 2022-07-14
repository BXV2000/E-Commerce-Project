
import React, { Component } from 'react';
import "../css/Product.css";
import axios from 'axios';
import { Link } from "react-router-dom";

let baseURL = "https://localhost:7024/api/"
export class Product extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id:this.props.match.params.productId,
            product:[],
            imageURL:"",
            categories:[]
        };
    }
    
    getData = (id)=>{
        axios.get(baseURL+"vegetable/"+id)
            .then(res => {
                this.setState({product:res.data});
                this.refs.Name.value = res.data.name
                this.refs.CategoryID.value = res.data.categoryId
                this.refs.Price.value = res.data.price
                this.refs.Stock.value = res.data.stock
                this.setState({imageURL:this.state.product.images[0].imageURL+"/"+this.state.product.images[0].id})
                axios.get(baseURL+"category")
                .then(res => {
                    this.setState({categories:res.data});
                    })
            })  
            axios.get(baseURL+"category") 
            .then(res => {
                this.setState({categories:res.data});
                axios.get(baseURL+"vegetable/"+id)
                .then(res => {
                    this.setState({product:res.data});
                    this.refs.Name.value = res.data.name
                    this.refs.Price.value = res.data.price
                    this.refs.Stock.value = res.data.stock
                    this.refs.CategoryId.value = res.data.categoryId
                    this.setState({imageURL:this.state.product.images[0].imageURL+"/"+this.state.product.images[0].id})
                })    
            })
    }

    updateData=(e)=>{
        e.preventDefault();
        var imagefile = document.querySelector('#file');
        let data = {
            Name: this.refs.Name.value,
            CategoryId: this.refs.CategoryId.value,
            Price: this.refs.Price.value,
            Stock: this.refs.Stock.value
        };
        let img = new FormData();
        img.append('File', imagefile.files[0]);
        img.append('ImageName', "String");
        img.append('ImageURL', "URL");
        img.append('VegetableId',this.state.product.id);
        axios.put(baseURL + "vegetable/" + this.state.product.id, data)
            .then(res => {
                if(imagefile.files[0])
                {
                    if(this.state.product.images.length!=0)
                    {
                    axios.put(baseURL + "image/" + this.state.product.images[0].id, img);
                    alert("Product update Success!");
                    window.location.href = "/product-list";
                    }
                    else
                    {
                    axios.post(baseURL + "image", img); 
                    alert("Product update Success!");
                    window.location.href = "/product-list";
                    }
                }
                else{
                    alert("Product update Success!");
                    window.location.href = "/product-list";
                }
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
        const { product,categories } = this.state;
        return (
            <div className="product-single">
                <div className="product-single-title-container">
                    <h1 className="product-single-title">Edit Product</h1>
                </div>
                <div className="product-single-container">
                    <div className="product-single-show">
                        <div className="product-single-show-top">
                            <img  src={(this.state.imageURL)?this.state.imageURL:"/ProductDummy.jpg"} alt="" className="product-single-img" />
                        </div>
                        <div className="product-single-show-bottom">
                            <span className="product-single-show-bottom-title">Product Detail </span>
                            <table className="product-single-data-table">
                                <tr className="">
                                    <th className="product-single-show-label">Product Name</th>
                                    <th className="product-single-show-data">{product.name}</th>
                                </tr>
                                <tr className="">
                                    <th className="product-single-show-label">Product ID</th>
                                    <th className="product-single-show-data">{product.id}</th>
                                </tr>
                                <tr className="">
                                    <th className="product-single-show-label">Category ID</th>
                                    <th className="product-single-show-data">{product.categoryId}</th>
                                </tr>
                                <tr className="">
                                    <th className="product-single-show-label">Price</th>
                                    <th className="product-single-show-data">{product.price}</th>
                                </tr>
                                <tr className="">
                                    <th className="product-single-show-label">Stock</th>
                                    <th className="product-single-show-data">{product.stock}</th>
                                </tr>
                            </table>
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
                                    <select className="product-single-update-input" name="active" id="active" ref="CategoryId"  >
                                        {categories.map((category,index)=>{
                                            return <option key={index} value={category.id} >{category.name}</option>
                                        })}
                                    </select>
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
                                <Link to={"/product-list"}>
                                    <button className="button">Cancel</button>
                                </Link>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

import React, { Component } from 'react';
import "../css/Category.css";
import axios from 'axios';
import { Link } from "react-router-dom";

let baseURL = "https://localhost:7024/api/"
export class Category extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id:this.props.match.params.categoryId,
            category:[]
        };
    }
    
    getData = (id)=>{
        axios.get(baseURL+"category/"+id) 
        .then(res => {
            this.setState({category:res.data});
                this.refs.Name.value = res.data.name
                this.refs.Description.value = res.data.description
                // this.refs.Stock.value = res.data.stock
                // this.setState({imageURL:this.state.product.images[0].imageURL+"/"+this.state.product.images[0].id})
        })
    }

    updateData=(e)=>{
        e.preventDefault();
        let data = {
            Name: this.refs.Name.value,
            Description: this.refs.Description.value,
        };
        axios.put(baseURL + "category/" + this.state.category.id, data)
            .then(res => {
                alert("Category update Success!");
                window.location.href = "/category-list";
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            })
        
    }

    componentDidMount() {
        this.getData(this.state.id);
        // console.log(this.state.id)
     }

   

    render() {
        const { category } = this.state;
        return (
            <div className="category-single">
                <div className="category-single-title-container">
                    <h1 className="category-single-title">Edit Category</h1>
                </div>
                <div className="category-single-container">
                    <div className="category-single-show">
                        <div className="category-single-show-bottom">
                            <span className="category-single-show-bottom-title">Category Detail </span>
                            <table className="category-single-data-table">
                                <tr className="">
                                    <th className="category-single-show-label">Category Name</th>
                                    <th className="category-single-show-data">{category.name}</th>
                                </tr>
                                <tr className="">
                                    <th className="category-single-show-label">Category ID</th>
                                    <th className="category-single-show-data">{category.id}</th>
                                </tr>
                                <tr className="">
                                    <th className="category-single-show-label">Description</th>
                                    <th className="category-single-show-data">{category.description}</th>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div className="category-single-update">
                        <span className="category-single-update-title">Edit Product</span>
                        <form className="category-single-update-form">
                            <div className="category-single-update-left">
                                <div className="category-single-update-item">
                                    <label >Product Name:</label>
                                    <input 
                                        type="text" 
                                        className="category-single-update-input" 
                                        placeholder={category.name}
                                        ref="Name"
                                    />
                                </div>
                                <div className="category-single-update-item">
                                    <label >Description:</label>
                                    <textarea
                                        type="number" 
                                        className="category-single-update-input" 
                                        placeholder
                                        ref="Description"
                                    />
                                </div>
                            </div>
                            <div className="category-single-update-right">
                                <button className="button" onClick={this.updateData}>Update</button>
                                <Link to={"/category-list"}>
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
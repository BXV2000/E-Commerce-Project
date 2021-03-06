import React, { Component } from 'react'
import "../css/Product.css"
import axios from 'axios';
import { Link } from "react-router-dom";


let baseURL = "https://localhost:7024/api/"
export  class ProductCreate extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories:[],
        };
    }

    getData=()=>{
        axios.get(baseURL+"category")
        .then(res => {
            this.setState({categories:res.data});
            })
    }

    createData=(e)=>{
        e.preventDefault();
        if(this.refs.Name.value==''||this.refs.Stock.value==''||this.refs.Price.value==''){
            alert("Please do not leave fields empty");
            return;
        }
        let info={
            CategoryId:this.refs.CategoryId.value,
            Name:this.refs.Name.value,
            Price:this.refs.Price.value,
            Stock:this.refs.Stock.value,
        }
        axios.post(baseURL+"vegetable", info)
            .then(res => {
                this.setState({ message: res.data })
                alert("Product create success!");
                window.location.href = "/product-list";
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            }) 
    }

    componentDidMount() {
        this.getData();
        
     }

    render(){
        const{categories} = this.state;
        return (
            <div className="new-product-">
                <h1 className="new-product-Title">New Product</h1>
                <form className="new-product-Form">
                    <div className="new-product-Item">
                    <label>Product Name</label>
                    <input type="text" placeholder="Apple" ref="Name"/>
                    </div>  
                    <div className="new-product-Item">
                    <label>Category ID</label>
                    <select className="new-product-Select" name="active" id="active" ref="CategoryId">
                        {categories.map((category,index)=>{
                            return <option key={index} value={category.id} >{category.name}</option>
                        })}
                    </select>
                    </div>
                    <div className="new-product-Item">
                    <label>Price</label>
                    <input type="number" placeholder="69000" ref="Price"/>
                    </div>  
                    <div className="new-product-Item">
                    <label>Stock</label>
                    <input type="number" placeholder="25" ref="Stock" />
                    </div> 
                    {/* <div className="new-product-Item">
                    <label>Product Image</label>
                    <input type="file" placeholder="john" id="newImg"/>
                    </div>    */}
                    <div className="new-product-buttons">
                        <button className="button new-product-button" onClick={this.createData}>Create</button>
                        <Link to={"/product-list"}>
                        <button className="button new-product-button" >Cancel</button>
                        </Link>
                    </div>
                </form>
            </div>
        )
    }
}

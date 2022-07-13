import React, { Component } from 'react'
import "../css/Product.css"
import axios from 'axios';
import { Link } from "react-router-dom";


let baseURL = "https://localhost:7024/api/"
export  class CategoryCreate extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories:[],
        };
    }

    createData=(e)=>{
        e.preventDefault();
        if(this.refs.Name.value==''||this.refs.Description.value==''){
            alert("Please do not leave fields empty");
            return;
        }
        let info={
            Name:this.refs.Name.value,
            Description:this.refs.Description.value,
        }
        axios.post(baseURL+"category", info)
            .then(res => {
                this.setState({ message: res.data })
                alert("Category create success!");
                window.location.href = "/category-list";
            })
            .catch(error => {
                this.setState({ message: error.response.data });
                alert(this.state.message);
            }) 
    }

    componentDidMount() {
        
     }

    render(){
        const{categories} = this.state;
        return (
            <div className="new-product-">
                <h1 className="new-product-Title">New Category</h1>
                <form className="new-product-Form">
                    <div className="new-product-Item">
                    <label>Product Name</label>
                    <input type="text" placeholder="Apple" ref="Name"/>
                    </div>  
                    <div className="new-product-Item">
                    <label>Category ID</label>
                    <textarea name="" id="" cols="30" rows="5" ref="Description"></textarea>
                    </div>
                    <div className="new-product-buttons">
                        <button className="button new-product-button" onClick={this.createData}>Create</button>
                        <Link to={"/category-list"}>
                        <button className="button new-product-button" >Cancel</button>
                        </Link>
                    </div>
                </form>
            </div>
        )
    }
}

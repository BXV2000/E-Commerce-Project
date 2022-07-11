import "../css/ProductList.css"
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import axios from 'axios';
import React, { Component } from 'react';
import { Link } from "react-router-dom";

const handleDelete = (id) => {
    axios.delete(baseURL + "Vegetable/" + id)
    console.log(id);
}

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'categoryId', headerName: 'Category ID', width: 130 },
    { field: 'name', headerName: 'Product Name', width: 130 },
    {
        field: 'price',
        headerName: 'Price',
        type: 'number',
        width: 90,
    },
    {
        field: 'stock',
        headerName: 'Stock',
        type: 'number',
        width: 90,
    },
    {
        field: 'action',
        headerName: 'Action',
        width: 400,
        renderCell: (params) => {
            return (
                <div className="button-list">
                    <Link to={"/product/" + params.row.id}>
                        <button className="button " >Edit</button>
                    </Link>
                    <button className="button delete-button" onClick={()=>handleDelete(params.row.id) }>Delete</button>
                </div>
                );
        }
    },
    //{
    //    field: 'fullName',
    //    headerName: 'Full name',
    //    description: 'This column has a value getter and is not sortable.',
    //    sortable: false,
    //    width: 160,
    //    valueGetter: (params: GridValueGetterParams) =>
    //        `${params.row.firstName || ''} ${params.row.lastName || ''}`,
    //},
];

let baseURL = "https://localhost:7024/api/"
export class ProductList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            vegetables: [],
        };
    }
    refreshList() {
        axios.get(baseURL + "Vegetable")
            .then(res => {
                this.setState({ vegetables: res.data })
            })

    }
    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { vegetables } = this.state;
        return (
            <div className="product-list">
                <DataGrid
                    rows={vegetables}
                    columns={columns}
                    pageSize={10}
                    rowsPerPageOptions={[10]}
                    checkboxSelection
                    disableSelectionOnClick
                />
            </div>
        )
    }
}
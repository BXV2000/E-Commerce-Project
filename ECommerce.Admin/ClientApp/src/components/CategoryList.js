import "../css/Category.css"
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import axios from 'axios';
import React, { Component } from 'react';
import { Link } from "react-router-dom";

const handleDelete = (id) => {
    axios.delete(baseURL + "category/" + id)
    .then(res => {
        alert("Category Deleted!");
    })
}

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 100 },
    { field: 'name', headerName: 'Category Name', width: 250 },
    { field: 'description', headerName: 'Description', width: 300 },
    {
        field: 'action',
        headerName: '',
        width: 200,
        renderCell: (params) => {
            return (
                <div className="button-list">
                    <Link to={"/category/" + params.row.id}>
                        <button className="button category-list-button" >Edit</button>
                    </Link>
                    <button className="button delete-button category-list-button" onClick={()=>handleDelete(params.row.id) }>Delete</button>
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
export class CategoryList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: [],
            sortModel:[{field: 'id',sort: 'desc',}],
        };
    }
    refreshList() {
        axios.get(baseURL + "category")
            .then(res => {
                this.setState({ categories: res.data })
            })

    }
    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { sortModel,categories } = this.state;
        return (
            <>     
                <div className="category-list-top">   
                    <h1>Category List</h1>            
                    <Link to={"/category-create"}>
                    <button className="button">Create</button>
                    </Link>
                </div>
                <div className="category-list">
                    <DataGrid
                        rows={categories}
                        columns={columns}
                        pageSize={10}
                        sortModel={sortModel}
                        rowsPerPageOptions={[10]}
                        disableSelectionOnClick
                    />
                </div>
            </>
        )
    }
}
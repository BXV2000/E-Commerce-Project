import "../css/User.css"
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import axios from 'axios';
import React, { Component } from 'react';
import { Link } from "react-router-dom";

const handleDelete = (id) => {
    axios.delete(baseURL + "Vegetable/" + id)
    .then(res => {
        alert("Product Deleted!");
    })
}

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 100 },
    { field: 'firstName', headerName: 'First Name', width: 150 },
    { field: 'lastName', headerName: 'Last Name', width: 150 },
    { field: 'role', headerName: 'Role', width: 150 },
    { field: 'username', headerName: 'Username', width: 150 },
    { field: 'phone', headerName: 'Phone', width: 200 },
    { field: 'email', headerName: 'Email', width: 200 },
    // {
    //     field: 'action',
    //     headerName: '',
    //     width: 200,
    //     renderCell: (params) => {
    //         return (
    //             <div className="button-list">
    //                 <Link to={"/product/" + params.row.id}>
    //                     <button className="button user-list-button" >Edit</button>
    //                 </Link>
    //                 <button className="button delete-button user-list-button" onClick={()=>handleDelete(params.row.id) }>Delete</button>
    //             </div>
    //             );
    //     }
    // },
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
export class UserList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            sortModel:[{field: 'id',sort: 'desc',}],
        };
    }
    refreshList() {
        axios.get(baseURL + "User")
            .then(res => {
                this.setState({ users: res.data })
            })

    }
    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { sortModel, users } = this.state;
        console.log(users)
        return (
            <>     
                <div className="user-list-top">   
                    <h1>User List</h1>            
                    {/* <Link to={"/product-create"}>
                    <button className="button">Create</button>
                    </Link> */}
                </div>
                <div className="user-list">
                    <DataGrid
                        rows={users}
                        columns={columns}
                        pageSize={10}
                        rowsPerPageOptions={[10]}
                        sortModel={sortModel}
                        disableSelectionOnClick
                    />
                </div>
            </>
        )
    }
}
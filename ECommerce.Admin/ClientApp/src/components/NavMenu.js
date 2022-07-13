import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import '../css/NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

  }

  handleLogOut=()=>{
    localStorage.removeItem("token");
    window.location.href ="/login";
  }


  render () {
    return (
      <>     
        <Navbar className="navbar" light>
            <NavbarBrand tag={Link} to="/"><img src="/NavbarLogo.png" alt="Logo" className="navbar-logo"/></NavbarBrand>
              <ul className="navbar-nav">
                <NavItem>
                        <NavLink tag={Link} className="navbar-link" to="/"><i class="fa-solid fa-house"></i> Home</NavLink>
                </NavItem>
                <NavItem>
                        <NavLink tag={Link} className="navbar-link" to="/category-list"><i class="fa fa-list-alt" aria-hidden="true"></i> Categories</NavLink>
                </NavItem>
                <NavItem>
                        <NavLink tag={Link} className="navbar-link" to="/product-list"><i class="fa-solid fa-apple-whole"></i> Products</NavLink>
                </NavItem>
                <NavItem>
                        <NavLink tag={Link} className="navbar-link" to="/user-list"><i class="fa fa-user" aria-hidden="true"></i> Users</NavLink>
                </NavItem>
                <button className="button logout-button" onClick={this.handleLogOut}>Logout</button>
              </ul>
            </Navbar>
      </>
    );
  }
}

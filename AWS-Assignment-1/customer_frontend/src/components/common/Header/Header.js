import { Route, NavLink } from "react-router-dom";
import { NavDropdown } from "react-bootstrap";
import imagename from "../../../images/logo.png"

//import classes from './Header.module.css';
import React, { useState, useEffect } from "react";

import "./Header.css";

const Header = () => {
  
  return (
    <>
    <nav className="navbar navbar-expand-lg navbar-light py-3 static-top">
      <NavLink to="/" className="navbar-brand ml-4" id="ac">
       <img src={imagename} height="50px" width="80px" />
      </NavLink>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#collapsibleNavbar"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div
        className="collapse navbar-collapse justify-content-end"
        id="collapsibleNavbar"
      >
        <ul className="navbar-nav d-flex align-items-center">
          <li className="nav-link nav-item">
            <NavLink
              to="/"
              className="Navlink"
              activeStyle={{
                color: "#fff",
              }}
              exact
              
            >
              Customers
            </NavLink>
          </li>
          
          <li className="nav-link nav-item">
            <NavLink
              to="/add"
              className="Navlink"
              activeStyle={{
                color: "#fff",
              }}
              exact
              
            >
              Add Customer
            </NavLink>
          </li>
          
          
        
          
          
        </ul>
      </div>
    </nav>
    </>
  );
};



export default Header;

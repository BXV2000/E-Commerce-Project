import React from "react";
import { Redirect, Switch, Route, Router } from "react-router-dom";
import RouteGuard from "../components/RouteGuard/RouteGuard";

//history
import { history } from "../helpers/history";

//pages
import { Layout } from './Layout';
import {Home} from "./Home";
import { Login } from "./Login";
import { Vegetable } from "./Vegetable";
import { VegetableCreate } from './VegetableCreate';
import { Image } from './Image';
import { ImageCreate } from './ImageCreate';
import { ProductList } from './ProductList';
import { Product } from './Product';
import { ProductCreate } from './ProductCreate';


function Routes() {
    return (
        <Router history={history}>
            <Switch>
                <Route path="/login" component={Login} />
                <Layout>
                    <RouteGuard exact path='/' component={Home} />
                    <RouteGuard path='/image' component={Image} />
                    <RouteGuard path='/image-create' component={ImageCreate} />
                    <RouteGuard path='/vegetable' component={Vegetable} />
                    <RouteGuard path='/vegetable-create' component={VegetableCreate} />
                    <RouteGuard path='/product-list' component={ProductList} />
                    <RouteGuard path='/product-create' component={ProductCreate} />
                    <RouteGuard path='/product/:productId' component={Product} />
                </Layout>
            </Switch>
        </Router>
    );
}

export default Routes;
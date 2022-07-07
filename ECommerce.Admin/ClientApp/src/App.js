import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Image } from './components/Image';
import { ImageCreate } from './components/ImageCreate';
import { Vegetable } from './components/Vegetable';
import { VegetableCreate } from './components/VegetableCreate';
import { Login } from './components/Login';
import { Error} from './components/Error';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/image' component={Image} />
        <Route path='/image-create' component={ImageCreate} />
        <Route path='/vegetable' component={Vegetable} />
        <Route path='/vegetable-create' component={VegetableCreate} />
        <Route path="/error" component={Error} />
        <Route path="/login" component={Login} />
      </Layout>
    );
  }
}

import React, { Component } from 'react';

export class Image extends Component {
    static displayName = Image.name;

    constructor() {
        super();
        this.state = {
            ImageData:[]
        }
    }
    render() {
        return (
            <div>
                <h1>Image</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
            </div>
        );
    }
}

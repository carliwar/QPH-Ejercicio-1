import React, { Component } from 'react';
import LibroTable from './components/LibroTable';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <LibroTable />
        );
    }
}
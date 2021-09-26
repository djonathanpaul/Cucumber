import React, { Component } from 'react';
import { CaptureDetails } from './components/CaptureDetails';
import { CapturedDetailsOutput } from './components/CapturedDetailsOutput';
import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { currency: '', personName: '', errorMsg: ''};
    }

    onSearchSubmit = async (personName, currency) => {           
        const baseURL = 'numbertoword/';
        const query = `?amount=${currency}`;
        const response = await fetch(baseURL + query);
        const data = await response.json();
        this.setState({ currency: data.amountLiteral, personName: personName, errorMsg: data.errorMsg });
    }

    hideOutput = async (errorMsg) => {   
        this.setState({ currency: '', personName: '', errorMsg: errorMsg});       
    }

    render() {       
        return (
            <div className="ui container" style={{ marginTop: '10px' }}>
                <h1 class="ui block violet inverted center aligned header">Cucumber</h1>
                < CaptureDetails whenSubmit={this.onSearchSubmit} toHide={this.hideOutput} />              
                {(this.state.currency  && this.state.personName) ? <CapturedDetailsOutput currency={this.state.currency} name={this.state.personName} /> : ''}
                {this.state.errorMsg  ? <div className="ui error message">{this.state.errorMsg}</div> : ''}                
            </div>           
  );
  }
}

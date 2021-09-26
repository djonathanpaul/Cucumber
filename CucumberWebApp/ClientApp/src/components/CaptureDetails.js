import React, { Component } from 'react';

export class CaptureDetails extends Component {

    constructor(props) {
        super(props);
        this.state = { personName: '', currency: '' };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.hideOutputCompnent = this.hideOutputCompnent.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.whenSubmit(this.state.personName, this.state.currency);
    }

    handleChange(event) {
        event.preventDefault();
        this.setState({ [event.target.name]: event.target.value })        
    }

    hideOutputCompnent(event) {
        
        event.preventDefault();

        let errorMsg =''
        if (event.target.value == '') 
            errorMsg = "Please enter a value for the " + event.target.id + " field."
        else
        {
            if (event.target.id == 'Name')
                errorMsg = "The Name field must contain alphabtets alone."
            else
                errorMsg = "The Number field must contain an integer or a decimal value upto two decimal places."       
        }
        this.props.toHide(errorMsg);
    }

    render() {
        
        return (

            <div className="ui segment" >
                <form className="ui form" onSubmit={this.handleSubmit} >
                    <h4 className="ui dividing header">Input</h4>
                    <div className="field">
                        <label>Name</label>
                        <input
                            id='Name'
                            name='personName'
                            type='text'
                            pattern="[a-zA-Z\s]*"
                            value={this.state.name}
                            onChange={this.handleChange}
                            onInvalid={this.hideOutputCompnent}
                            required
                        />
                    </div>

                    <div className="field">
                        <label>Number</label>
                        <input
                            id='Number'
                            name='currency'
                            pattern="^\d*(\.\d{0,2})?$"
                            value={this.state.currency}
                            onChange={this.handleChange}
                            onInvalid={this.hideOutputCompnent}
                            required
                        />
                    </div>
                    
                    <button className="ui button" type="submit" hidden="true" >Submit</button>
                    <div className="ui error message"></div>
                </form>
            </div>
           
        );
    }
}
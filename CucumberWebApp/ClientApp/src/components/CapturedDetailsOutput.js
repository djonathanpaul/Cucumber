import React, { Component } from 'react';

export class CapturedDetailsOutput extends Component {


    render() {
        return (

            <div className="ui segment">
                <form className="ui form">
                    <h4 className="ui dividing header">Output</h4>
                    <div className="field">
                        <label>Name</label>
                        <input
                            type="text"
                            value={this.props.name}
                            readOnly
                        />
                    </div>
                    <div className="field">
                        <label>Number in Words</label>
                        <textarea
                            type="text"
                            value={this.props.currency}
                            rows = "2"
                            readOnly
                        />
                     </div>
                 </form>
            </div>
        );
    }
}
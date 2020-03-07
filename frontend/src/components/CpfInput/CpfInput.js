import React, { Component } from 'react';
import './CpfInput.css';
import { cpfMask } from '../../service/CpfService';

class CpfInput extends Component {
    constructor(props) {
        super(props);

        this.state = { documentId: '' };
        this.handlechange = this.handlechange.bind(this);
        this.handleKeyDown = this.handleKeyDown.bind(this);
    }

    handlechange(e) {
        this.setState({ documentId: cpfMask(e.target.value) })
    }

    handleKeyDown(e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            document.querySelector("#submit-cpf").click();
        }
    }

    render() {
        const { documentId } = this.state;
        return (
        <div className="cpf-input">
            <label>CPF</label>
            <input
                maxLength='14'
                name='cpfValue'
                value={documentId}
                onChange={this.handlechange}
                onKeyDown={this.handleKeyDown}
            />
        </div>
        )
    }
}

export default CpfInput;
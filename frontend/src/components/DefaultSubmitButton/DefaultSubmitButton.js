import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Container from '../Container/Container';
import axios from 'axios';
import './DefaultSubmitButton.css';

const numberPattern = /\d+/g;

class DefaultSubmitButton extends Component {
    buttonText = "";

    constructor(props) {
        super(props);
        this.buttonText = props.buttonText;
        this.handleClick = this.handleClick.bind(this);
    }

    async loadCpf(cpf) {
        try {
            const data = await axios.get(`http://localhost:5000/v1/admin/devedores/${cpf}`);
            ReactDOM.render(
                <Container>
                    <h1>{JSON.stringify(data.data)}</h1>
                </Container>,
                document.getElementById("root")
            );
        } catch(err) {
            console.log(`Erro ao consultar o devedor: ${err}`);
        }
    }

    handleClick(event) {
        const cpf = document.querySelector(".cpf-input input").value.match(numberPattern).join('');
        this.loadCpf(1);
    }

    render() {
        return (
            <button id="submit-cpf" className="default-submit-button" onClick={this.handleClick}>{this.buttonText}</button>
        );
    }
}

export default DefaultSubmitButton;
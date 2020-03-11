import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Container from '../Container/Container';
import DividaList from '../DividaList/DividaList';
import api from '../../service/api';
import './CpfConsultaSubmitButton.css';

const numberPattern = /\d+/g;

class CpfConsultaSubmitButton extends Component {
    buttonText = "";

    constructor(props) {
        super(props);
        this.buttonText = props.buttonText;
        this.handleClick = this.handleClick.bind(this);
    }

    showError(msg) {
        document.querySelector("#msg-erro").textContent = msg;
    }

    async loadCpf(cpf) {
        try {

            const responseToken = await api.get(`v1/token/${cpf}`);
            const token = responseToken.data.token;

            const data = await api.get(`/v1/admin/devedores/cpf/${cpf}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            
            if (data.status === 200) {
                ReactDOM.render(
                    <Container>
                        <DividaList data={data.data} token={token} />
                    </Container>,
                    document.getElementById("root")
                );
            } else {
                this.showError(`Erro ao consultar o devedor. Status ${data.status}`);
            }
        } catch(err) {
            if (err.message.indexOf("404") > -1){
                this.showError(`Devedor não encontrado`);
            }
            else {
                this.showError(`Erro ao consultar o devedor: ${err}`);
            }
        }
    }

    handleClick(event) {
        const cpf = document.querySelector(".cpf-input input").value
        if (!cpf) {
            this.showError('Digite o CPF');
            return;
        }

        const cpfNumber = cpf.match(numberPattern).join('');
        this.loadCpf(cpfNumber);
    }

    render() {
        return (
            <button id="submit-cpf" className="cpf-submit-button" onClick={this.handleClick}>
                <i className="fas fa-search-dollar"></i>
                {this.buttonText}
            </button>
        );
    }
}

export default CpfConsultaSubmitButton;
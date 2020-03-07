import React, { Component } from 'react';
import './DividaList.css';
import { cpfMask } from '../../service/CpfService';

class DividaList extends Component {
    data = {};

    constructor(props) {
        super(props);

        this.data = props.data;
    }

    renderDividas() {
        let result = [];

        for (let index = 0; index < this.props.data.dividas.length; index++) {

            const vencimento = new Date(this.props.data.dividas[index].vencimento);

            result.push(
                <div key={index} className="row">
                    <div>{this.props.data.dividas[index].id}</div>
                    <div>{this.props.data.dividas[index].numeroDivida}</div>
                    <div>{vencimento.toLocaleDateString()}</div>
                    <div>R$ {this.props.data.dividas[index].valorOriginal.toFixed(2)}</div>
                    <div>{this.props.data.dividas[index].carteira.nome}</div>
                </div>
            );
        }

        return result;
    }

    render() {
        return (
            <>
                <div className="title header-font">{this.data.nome} - {cpfMask(this.data.cpf.toString())}</div>
                <div className="dividas-list">
                    <div className="row header-font">
                        <div>ID</div>
                        <div>Número Dívida</div>
                        <div>Vencimento</div>
                        <div>Valor Original</div>
                        <div>Carteira</div>
                    </div>

                    <div>{this.renderDividas()}</div>
                </div>
            </>
        );
    }
}

export default DividaList;
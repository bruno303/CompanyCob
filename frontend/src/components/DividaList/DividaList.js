import React, { Component } from 'react';
import './DividaList.css';
import { cpfMask } from '../../service/CpfService';
import api from '../../service/api';

class DividaList extends Component {
    dataDevedor = {};

    state = { parcelas: [] };

    constructor(props) {
        super(props);

        this.dataDevedor = props.data;
        this.calcDividasHandler = this.calcDividasHandler.bind(this);
    }

    showModal() {
        const modal = document.getElementById('modal-result');
        const span = document.querySelector("span.close");

        modal.style.display = "block";

        span.onclick = function () {
            modal.style.display = "none";
        }

        window.onclick = function (event) {
            if (event.target === modal) {
                modal.style.display = "none";
            }
        }
    }

    showError(msg) {
        alert(msg);
    }

    async getDividaCalculada(idDevedor, idDivida) {
        try {
            const data = await api.get(`/v1/calculo/${idDevedor}/${idDivida}`)
            if (data.status === 200) {
                this.setState({ parcelas: data.data.parcelas });
            } else {
                this.showError(`Erro ao consultar as parcelas calculadas. Status ${data.status}`);
            }
        } catch (err) {
            this.showError(`Erro ao consultar as parcelas calculadas: ${err}`);
        }
    }

    async calcDividasHandler(e) {
        const idDevedor = this.dataDevedor.id;
        const idDivida = e.target.getAttribute("data-divida-id");

        await this.getDividaCalculada(idDevedor, idDivida);
        this.renderDividaCalculada();

        this.showModal();
    }

    renderDividaCalculada() {
        let result = [];

        for (let index = 0; index < this.state.parcelas.length; index++) {

            const parcela = this.state.parcelas[index];
            const vencimento = new Date(parcela.vencimento);

            result.push(
                <div key={index} className="row">
                    <div>{parcela.numero}</div>
                    <div>R$ {parcela.valor.toFixed(2)}</div>
                    <div>{vencimento.toLocaleDateString()}</div>
                </div>
            );
        }

        return result;
    }

    renderDividas() {
        let result = [];

        for (let index = 0; index < this.props.data.dividas.length; index++) {

            const idDivida = this.dataDevedor.dividas[index].id;
            const vencimento = new Date(this.dataDevedor.dividas[index].vencimento);

            result.push(
                <div key={index}>
                    <div className="row">
                        <button data-divida-id={idDivida} className="btn-calcular" onClick={this.calcDividasHandler}>
                            <i className="fas fa-calculator"></i>
                            Calcular
                        </button>
                        <div>{idDivida}</div>
                        <div>{this.dataDevedor.dividas[index].numeroDivida}</div>
                        <div>{vencimento.toLocaleDateString()}</div>
                        <div>R$ {this.dataDevedor.dividas[index].valorOriginal.toFixed(2)}</div>
                        <div>{this.dataDevedor.dividas[index].carteira.nome}</div>
                    </div>
                    <div className="row show-results" data-divida-id={idDivida}>

                    </div>
                </div>
            );
        }

        return result;
    }

    render() {
        return (
            <>
                <div id="modal-result" className="modal">
                    <div className="modal-content">
                        <span className="close">&times;</span>
                        <div id="results-div" className="results-div">
                            <div className="row header-font">
                                <div>Parcela</div>
                                <div>Valor</div>
                                <div>Vencimento</div>
                            </div>
                            {this.renderDividaCalculada()}
                        </div>

                    </div>
                </div>

                <div className="title header-font">{this.dataDevedor.nome} - {cpfMask(this.dataDevedor.cpf.toString())}</div>
                <div className="dividas-list">
                    <div className="row header-font">
                        <div></div>
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
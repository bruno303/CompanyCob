import React, { Component } from 'react';
import './CpfConsultaForm.css';
import CpfInput from '../CpfInput/CpfInput';
import CpfConsultaSubmitButton from '../CpfConsultaSubmitButton/CpfConsultaSubmitButton';

class CpfConsultaForm extends Component {
    render() {
        return (
            <div className="cpf-form">
                <div className="cpf-form-column">
                    <div className="cpf-form-row">
                        <CpfInput />
                        <CpfConsultaSubmitButton buttonText="Consultar dívidas" />
                    </div>
                    <div className="cpf-form-column">
                        <span id="msg-erro"></span>
                    </div>
                </div>
            </div>
        );
    }
}

export default CpfConsultaForm;
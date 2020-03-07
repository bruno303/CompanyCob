import React, { Component } from 'react';
import './CpfConsultaForm.css';
import CpfInput from '../CpfInput/CpfInput';
import DefaultSubmitButton from '../DefaultSubmitButton/DefaultSubmitButton';

class CpfConsultaForm extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="cpf-form">
                <CpfInput />
                <DefaultSubmitButton buttonText="Consultar dívidas" />
            </div>
        );
    }
}

export default CpfConsultaForm;
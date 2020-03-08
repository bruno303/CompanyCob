import React, { Component } from 'react';
import './PresentationDiv.css';

class PresentationDiv extends Component {
    render() {
        return (
            <div className="presentation-div">
                <p>Bem vindo à Company Cob!</p>
                <p>Somos o que há de melhor quando o assunto é ajudar pessoas a quitar suas dívdas e melhorar sua saúde financeira.</p>
                <p>Para consultar suas dívidas, informe seu cpf abaixo.</p>
            </div>
        );
    }
}

export default PresentationDiv;
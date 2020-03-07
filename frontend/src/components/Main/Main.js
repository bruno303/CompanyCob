import React, { Component } from 'react';
import Container from '../Container/Container';
import CpfInput from '../CpfInput/CpfInput';
import PresentationDiv from '../PresentationDiv/PresentationDiv';
import DefaultSubmitButton from '../DefaultSubmitButton/DefaultSubmitButton';
import CpfConsultaForm from '../CpfConsultaForm/CpfConsultaForm';

class Main extends Component {
    render() {
        return (
            <Container>
                <PresentationDiv />
                <CpfConsultaForm />
            </Container>
        )
    }
}

export default Main;
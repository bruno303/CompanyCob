import React from 'react';
import NavBar from '../NavBar/NavBar';
import './Container.css';

function Container(props) {
    return (
        <>
            <NavBar />
            <div className="container">{props.children}</div>
        </>
    )
}

export default Container;
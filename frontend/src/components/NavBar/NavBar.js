import React, { Component } from 'react';
import './NavBar.css';

class NavBar extends Component {
    backHome(event) {
        window.location = "/";
    }

    render() {
        return (
            <div className="nav">
                <input type="checkbox" id="nav-check" />
                <div className="nav-header">
                    <a className="cursor-pointer">
                        <div className="nav-title" onClick={this.backHome}>Company Cob App</div>
                    </a>
                </div>
                <div className="nav-btn">
                    <label htmlFor="nav-check">
                        <span></span>
                        <span></span>
                        <span></span>
                    </label>
                </div>

                <div className="nav-links">
                    <a href="//github.com/bruno303" target="_blank">Github</a>
                </div>
            </div>
        )
    }
}

export default NavBar;
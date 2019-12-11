import React, { Component } from 'react';
import './App.css';
import SideBar from "./SideBar/SideBar";

class App extends Component {

    render() {
        return (
            <div className="App">
                <div className="NavBar">
                    <div className="TextGorgeousFood">
                        Gorgeous Food
                    </div>
                </div>
                <div>
                    <SideBar/>
                </div>
            </div>
        );
    }
}

export default App;

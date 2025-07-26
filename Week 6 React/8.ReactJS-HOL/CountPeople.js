import React, { Component } from 'react';
import './CountPeople.css';

class CountPeople extends Component {
  constructor(props) {
    super(props);
    this.state = {
      entryCount: 0,
      exitCount: 0,
    };
  }

  updateEntry = () => {
    this.setState((prevState) => ({
      entryCount: prevState.entryCount + 1
    }));
  };

  updateExit = () => {
    this.setState((prevState) => ({
      exitCount: prevState.exitCount + 1
    }));
  };

  render() {
    return (
      <div className="counter-container">
        <h2>Mall People Counter</h2>
        <p>Number of People Entered: <span className="entry">{this.state.entryCount}</span></p>
        <p>Number of People Exited: <span className="exit">{this.state.exitCount}</span></p>
        <div className="buttons">
          <button className="green-button" onClick={this.updateEntry}>Login</button>
          <button className="green-button" onClick={this.updateExit}>Exit</button>
        </div>
      </div>
    );
  }
}

export default CountPeople;


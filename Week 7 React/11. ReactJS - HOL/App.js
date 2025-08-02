// src/App.js
import React, { Component } from 'react';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      counter: 0,
      message: '',
      rupees: '',
      euros: ''
    };
  }

  // 1.a - Increment method
  handleIncrement = () => {
    this.setState({ counter: this.state.counter + 1 });
    this.sayHello(); // call another method
  };

  // 1.b - Hello message
  sayHello = () => {
    console.log("Hello! This is a static message.");
    this.setState({ message: "Hello! This is a static message." });
  };

  // Decrement method
  handleDecrement = () => {
    this.setState({ counter: this.state.counter - 1 });
  };

  // 2. Say welcome with argument
  sayWelcome = (msg) => {
    alert(msg);
  };

  // 3. Synthetic event example
  handlePress = (e) => {
    e.preventDefault(); // synthetic event
    alert("I was clicked");
  };

  // Currency converter logic
  handleCurrencyChange = (e) => {
    this.setState({ rupees: e.target.value });
  };

  convertCurrency = () => {
    const rupees = parseFloat(this.state.rupees);
    const euros = (rupees / 90).toFixed(2); // Approx 1 Euro = 90 INR
    this.setState({ euros });
  };

  render() {
    return (
      <div className="app">
        <h1>React Event Handling Examples</h1>

        {/* Counter Section */}
        <h2>Counter: {this.state.counter}</h2>
        <button onClick={this.handleIncrement}>Increment</button>
        <button onClick={this.handleDecrement}>Decrement</button>
        <p>{this.state.message}</p>

        {/* Welcome Button with argument */}
        <button onClick={() => this.sayWelcome("Welcome to the eventexamplesapp!")}>
          Say Welcome
        </button>

        {/* Synthetic Event */}
        <button onClick={this.handlePress}>Click Me (Synthetic Event)</button>

        {/* Currency Converter */}
        <h2>Currency Converter (INR to Euro)</h2>
        <input
          type="number"
          placeholder="Enter amount in INR"
          value={this.state.rupees}
          onChange={this.handleCurrencyChange}
        />
        <button onClick={this.convertCurrency}>Convert</button>
        {this.state.euros && (
          <p>Converted Amount: €{this.state.euros}</p>
        )}
      </div>
    );
  }
}

export default App;

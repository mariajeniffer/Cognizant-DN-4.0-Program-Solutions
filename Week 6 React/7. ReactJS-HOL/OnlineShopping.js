import React, { Component } from 'react';
import Cart from './Cart';
import './OnlineShopping.css';

class OnlineShopping extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cartItems: [
        new Cart('Laptop', 75000),
        new Cart('Smartphone', 30000),
        new Cart('Headphones', 2500),
        new Cart('Shoes', 4000),
        new Cart('Backpack', 2000)
      ]
    };
  }

  render() {
    return (
      <div className="shopping-container">
        <h2 className="shopping-title">Items Ordered:</h2>
        <table className="shopping-table">
          <thead>
            <tr>
              <th>Item Name</th>
              <th>Price (₹)</th>
            </tr>
          </thead>
          <tbody>
            {this.state.cartItems.map((item, index) => (
              <tr key={index}>
                <td>{item.itemname}</td>
                <td>{item.price}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default OnlineShopping;

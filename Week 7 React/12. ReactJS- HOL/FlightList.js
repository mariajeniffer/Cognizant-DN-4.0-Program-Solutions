// src/FlightList.js
import React from 'react';

const FlightList = () => {
  const flights = [
    { id: 1, from: "Chennai", to: "Delhi", price: "₹4500" },
    { id: 2, from: "Mumbai", to: "Bangalore", price: "₹3200" },
    { id: 3, from: "Kolkata", to: "Hyderabad", price: "₹4000" },
  ];

  return (
    <div>
      <h2>Available Flights</h2>
      <ul>
        {flights.map((flight) => (
          <li key={flight.id}>
            {flight.from} to {flight.to} - {flight.price}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default FlightList;

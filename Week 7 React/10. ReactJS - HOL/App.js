// src/App.js
import React from 'react';
import './App.css';

// Office data object
const office1 = {
  name: "Elite Office Space",
  rent: "₹35,000/month",
  address: "MG Road, Bengaluru"
};

// List of office objects
const officeList = [
  {
    name: "Skyline Offices",
    rent: "₹40,000/month",
    address: "Koramangala, Bengaluru"
  },
  {
    name: "Tech Hub",
    rent: "₹30,000/month",
    address: "Hi-Tech City, Hyderabad"
  },
  {
    name: "BizNest",
    rent: "₹25,000/month",
    address: "DLF Cyber City, Gurgaon"
  }
];

function App() {
  return (
    <div className="app">
      {/* Heading */}
      <h1 className="heading">Office Space Rental App</h1>

      {/* Image */}
      <img
        src="https://images.unsplash.com/photo-1580587771525-78b9dba3b914"
        alt="Office Space"
        className="office-img"
      />

      {/* Single Object */}
      <h2>Featured Office</h2>
      <p><strong>Name:</strong> {office1.name}</p>
      <p><strong>Rent:</strong> {office1.rent}</p>
      <p><strong>Address:</strong> {office1.address}</p>

      {/* List of Offices */}
      <h2>Available Offices</h2>
      {officeList.map((office, index) => (
        <div key={index} className="office-card">
          <p><strong>Name:</strong> {office.name}</p>
          <p><strong>Rent:</strong> {office.rent}</p>
          <p><strong>Address:</strong> {office.address}</p>
        </div>
      ))}
    </div>
  );
}

export default App;


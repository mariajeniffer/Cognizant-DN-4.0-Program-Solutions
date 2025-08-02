// src/EmployeeCard.js
import React, { useContext } from 'react';
import ThemeContext from './ThemeContext';

const EmployeeCard = ({ name, role }) => {
  const theme = useContext(ThemeContext); // Using context here

  return (
    <div className={`employee-card ${theme}`}>
      <h3>{name}</h3>
      <p>{role}</p>
      <button className={`btn ${theme}`}>View Profile</button>
    </div>
  );
};

export default EmployeeCard;


// src/LoginPage.js
import React from 'react';

const LoginPage = ({ onLogin }) => {
  return (
    <div>
      <h2>Welcome Guest</h2>
      <p>Please login to book tickets.</p>
      <button onClick={onLogin}>Login</button>
    </div>
  );
};

export default LoginPage;

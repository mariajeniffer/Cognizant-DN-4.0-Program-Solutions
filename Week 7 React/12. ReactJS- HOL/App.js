// src/App.js
import React, { useState } from 'react';
import FlightList from './FlightList';
import LoginPage from './LoginPage';
import UserPage from './UserPage';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    setIsLoggedIn(true);
  }

  const handleLogout = () => {
    setIsLoggedIn(false);
  }

  return (
    <div className="App">
      <h1>Ticket Booking App</h1>

      <FlightList />

      {isLoggedIn ? (
        <UserPage onLogout={handleLogout} />
      ) : (
        <LoginPage onLogin={handleLogin} />
      )}
    </div>
  );
}

export default App;


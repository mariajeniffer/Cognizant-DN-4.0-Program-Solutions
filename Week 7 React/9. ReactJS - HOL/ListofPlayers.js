// src/ListofPlayers.js
import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: 'Virat', score: 85 },
    { name: 'Rohit', score: 40 },
    { name: 'Dhoni', score: 95 },
    { name: 'Jadeja', score: 30 },
    { name: 'Pant', score: 70 },
    { name: 'Bumrah', score: 60 },
    { name: 'Kohli', score: 100 },
    { name: 'Gill', score: 50 },
    { name: 'Hardik', score: 75 },
    { name: 'Ashwin', score: 20 },
    { name: 'KL Rahul', score: 90 },
  ];

  // Filter scores below 70 using arrow function
  const lowScorers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>All Players</h2>
      {players.map((player, index) => (
        <p key={index}>{player.name} - {player.score}</p>
      ))}

      <h2>Players with Score below 70</h2>
      {lowScorers.map((player, index) => (
        <p key={index}>{player.name} - {player.score}</p>
      ))}
    </div>
  );
};

export default ListofPlayers;

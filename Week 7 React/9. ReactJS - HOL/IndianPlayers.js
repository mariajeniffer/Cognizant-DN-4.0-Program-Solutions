// src/IndianPlayers.js
import React from 'react';

const IndianPlayers = () => {
  const T20players = ['Virat', 'Rohit', 'Dhoni', 'Jadeja'];
  const RanjiTrophy = ['Shaw', 'Pujara', 'Saha', 'Ashwin'];

  // Merge arrays using spread operator
  const mergedPlayers = [...T20players, ...RanjiTrophy];

  // Destructure odd and even indexed players
  const oddPlayers = mergedPlayers.filter((_, i) => i % 2 !== 0);
  const evenPlayers = mergedPlayers.filter((_, i) => i % 2 === 0);

  return (
    <div>
      <h2>Even Team Players</h2>
      {evenPlayers.map((player, index) => (
        <p key={index}>{player}</p>
      ))}

      <h2>Odd Team Players</h2>
      {oddPlayers.map((player, index) => (
        <p key={index}>{player}</p>
      ))}
    </div>
  );
};

export default IndianPlayers;

import React from 'react';
import ListofPlayers from './ListofPlayers';
import IndianPlayers from './IndianPlayers';

function App() {
  const flag = true; // Change this to false to see other component

  return (
    <div className="App">
      <h1>Cricket App</h1>
      {flag ? <IndianPlayers /> : <ListofPlayers />}
    </div>
  );
}

export default App;

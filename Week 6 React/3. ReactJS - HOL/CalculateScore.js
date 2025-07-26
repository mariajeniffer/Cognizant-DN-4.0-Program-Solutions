import React from 'react';
import '../Stylesheets/mystyle.css';

function CalculateScore() {
  const name = "Maria Jeniffer";
  const school = "Sathyabama University";
  const total = 450;
  const goal = 5;

  const average = total / goal;

  return (
    <div className="score-container">
      <h2>Student Score Calculator</h2>
      <p><strong>Name:</strong> {name}</p>
      <p><strong>School:</strong> {school}</p>
      <p><strong>Total Marks:</strong> {total}</p>
      <p><strong>Goal Subjects:</strong> {goal}</p>
      <p className="highlight"><strong>Average Score:</strong> {average}</p>
    </div>
  );
}

export default CalculateScore;

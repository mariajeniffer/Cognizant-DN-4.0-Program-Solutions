// src/ComplaintRegister.js
import React, { useState } from 'react';

const ComplaintRegister = () => {
  const [employeeName, setEmployeeName] = useState('');
  const [complaint, setComplaint] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!employeeName || !complaint) {
      alert("Please fill in both fields.");
      return;
    }

    const referenceNumber = 'REF' + Math.floor(Math.random() * 1000000);

    alert(`Complaint submitted successfully!\nReference Number: ${referenceNumber}`);

    // Reset the form
    setEmployeeName('');
    setComplaint('');
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Raise a Complaint</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Employee Name:</label><br />
          <input
            type="text"
            value={employeeName}
            onChange={(e) => setEmployeeName(e.target.value)}
            required
          />
        </div>
        <div style={{ marginTop: '10px' }}>
          <label>Complaint:</label><br />
          <textarea
            value={complaint}
            onChange={(e) => setComplaint(e.target.value)}
            rows="4"
            cols="40"
            required
          />
        </div>
        <button type="submit" style={{ marginTop: '15px' }}>
          Submit Complaint
        </button>
      </form>
    </div>
  );
};

export default ComplaintRegister;

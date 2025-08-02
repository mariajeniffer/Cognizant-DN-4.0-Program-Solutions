// src/EmployeesList.js
import React from 'react';
import EmployeeCard from './EmployeeCard';

const EmployeesList = () => {
  const employees = [
    { id: 1, name: 'Alice', role: 'Frontend Developer' },
    { id: 2, name: 'Bob', role: 'Backend Developer' },
    { id: 3, name: 'Charlie', role: 'Full Stack Developer' }
  ];

  return (
    <div>
      <h2>Employees</h2>
      {employees.map(emp => (
        <EmployeeCard key={emp.id} name={emp.name} role={emp.role} />
      ))}
    </div>
  );
};

export default EmployeesList;

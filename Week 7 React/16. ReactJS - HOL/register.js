// src/register.js
import React, { useState } from 'react';

const Register = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: ''
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setFormData(prev => ({
      ...prev,
      [e.target.name]: e.target.value
    }));
  };

  const validate = () => {
    const newErrors = {};

    if (formData.name.length < 5) {
      newErrors.name = "Name must be at least 5 characters long.";
    }

    if (!formData.email.includes('@') || !formData.email.includes('.')) {
      newErrors.email = "Email must include '@' and '.'.";
    }

    if (formData.password.length < 8) {
      newErrors.password = "Password must be at least 8 characters long.";
    }

    return newErrors;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const validationErrors = validate();

    if (Object.keys(validationErrors).length === 0) {
      alert("Form submitted successfully!");
      // Reset form
      setFormData({ name: '', email: '', password: '' });
      setErrors({});
    } else {
      setErrors(validationErrors);
    }
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Mail Registration</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label><br />
          <input
            type="text"
            name="name"
            value={formData.name}
            onChange={handleChange}
          />
          {errors.name && <p style={{ color: 'red' }}>{errors.name}</p>}
        </div>

        <div>
          <label>Email:</label><br />
          <input
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
          />
          {errors.email && <p style={{ color: 'red' }}>{errors.email}</p>}
        </div>

        <div>
          <label>Password:</label><br />
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
          />
          {errors.password && <p style={{ color: 'red' }}>{errors.password}</p>}
        </div>

        <button type="submit" style={{ marginTop: '15px' }}>Register</button>
      </form>
    </div>
  );
};

export default Register;

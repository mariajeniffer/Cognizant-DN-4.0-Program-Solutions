// src/Getuser.js
import React, { Component } from 'react';

class Getuser extends Component {
  constructor() {
    super();
    this.state = {
      user: null,
      loading: true,
    };
  }

  async componentDidMount() {
    try {
      const response = await fetch('https://api.randomuser.me/');
      const data = await response.json();
      this.setState({
        user: data.results[0],
        loading: false,
      });
    } catch (error) {
      console.error('Error fetching user:', error);
    }
  }

  render() {
    const { user, loading } = this.state;

    if (loading) {
      return <p>Loading user...</p>;
    }

    return (
      <div style={{ padding: '20px', textAlign: 'center' }}>
        <h2>User Info</h2>
        <p><strong>Title:</strong> {user.name.title}</p>
        <p><strong>First Name:</strong> {user.name.first}</p>
        <img src={user.picture.large} alt="User" style={{ borderRadius: '50%' }} />
      </div>
    );
  }
}

export default Getuser;

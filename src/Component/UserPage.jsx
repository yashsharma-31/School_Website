import React, { useEffect, useState } from 'react';
import axios from 'axios';

const UserPage = () => {
  const [message, setMessage] = useState('');

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const token = localStorage.getItem('token');
        const res = await axios.get('http://localhost:6001/user', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
        setMessage(res.data);
      } catch (err) {
        setMessage('Unauthorized or Error fetching data.');
      }
    };

    fetchUserData();
  }, []);

  return (
    <div className="container mt-5">
      <h2>User Dashboard</h2>
      <p>{message}</p>
    </div>
  );
};

export default UserPage;

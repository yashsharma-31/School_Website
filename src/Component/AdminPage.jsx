import React, { useEffect, useState } from 'react';
import axios from 'axios';

const AdminPage = () => {
  const [message, setMessage] = useState('');

  useEffect(() => {
    const fetchAdminData = async () => {
      try {
        const token = localStorage.getItem('token');
        const res = await axios.get('http://localhost:6001/admin', {
          headers: {
            Authorization: `Bearer ${token}`
          }
        });
        setMessage(res.data);
      } catch (err) {
        setMessage('Unauthorized or Error fetching data.');
      }
    };

    fetchAdminData();
  }, []);

  return (
    <div className="container mt-5">
      <h2>Admin Panel</h2>
      <p>{message}</p>
    </div>
  );
};

export default AdminPage;

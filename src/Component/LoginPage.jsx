// LoginPage.js
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { gsap } from 'gsap';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";

function LoginPage() {
  const [name, setName] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  // GSAP animation to run when the component mounts
  useEffect(() => {
    gsap.to('.login-container', { y: 100, duration: 0.5, yoyo: true, repeat: 2 , opacity:100 });
  }, []);

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      
      const res = await axios.post('http://localhost:6001/api/User/login', {
        name,
        password
      });

      if (res.data) {
        // Save JWT token (optional)
        localStorage.setItem('token', res.data);
        alert('Login successful!');
        const decodedToken = jwtDecode(res.data);
        const role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

        // Redirect based on role
        if (role === "admin") {
          navigate("/admin");
        } else if (role === "user") {
          navigate("/user");
        } else {
          navigate("/");
        }
      } else {
        setError('Invalid username or password');
      }
    } catch (err) {
      console.error(err);
      setError('Failed to connect to backend');
    }
  };

  return (
    <div className="container mt-5">
      <div className="login-container">
        <h2>Login</h2>
        {error && <div className="alert alert-danger">{error}</div>}
        <form onSubmit={handleLogin}>
          <div className="mb-3">
            <label>Name</label>
            <input
              type="text"
              className="form-control"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </div>
          <div className="mb-3">
            <label>Password</label>
            <input
              type="password"
              className="form-control"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          <button className="btn btn-primary">Login</button>
        </form>
      </div>
    </div>
  );
}

export default LoginPage;

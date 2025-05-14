// HomePage.js
import React, { useEffect } from 'react';
import { gsap } from 'gsap';
import { useNavigate } from 'react-router-dom';  // Import useNavigate for page navigation

function HomePage() {
  const navigate = useNavigate();
  // Function to navigate to the login page when the button is clicked
  const handleLoginClick = () => {
    navigate('/login'); // Navigate to the Login page
  };

  return (
    <div className="container mt-5">
      <h1 className="home-heading">🏫 Welcome to School Portal</h1>
      <p className="home-paragraph">This is the homepage. Secure areas will go here.</p>
      
      {/* The Login button with GSAP animation */}
      <button className="btn btn-primary login-btn" onClick={handleLoginClick}>
        Go to Login
      </button>
    </div>
  );
}

export default HomePage;

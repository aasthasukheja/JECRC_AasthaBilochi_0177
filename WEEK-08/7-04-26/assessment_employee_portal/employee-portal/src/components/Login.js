import React, { useState } from "react";
import { useAuth } from "../context/AuthContext";

function Login() {
  const [username, setUsername] = useState("");
  const [error, setError] = useState("");

  const { login } = useAuth();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!username.trim()) {
      setError("Please enter your name");
      return;
    }

    const success = login(username);

    if (!success) {
      setError("Login failed. Try again.");
      return;
    }

    setError("");
    setUsername("");
  };

  return (
    <div className="card login-card">
      <h2>Welcome Back 👋</h2>

      <p style={{ marginBottom: "20px", color: "#64748b" }}>
        Sign in to access your employee dashboard
      </p>

      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Employee Name</label>
          <input
            type="text"
            placeholder="Enter your name..."
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>

        {error && (
          <p className="error-text" style={{ marginBottom: "10px" }}>
            {error}
          </p>
        )}

        <button
          type="submit"
          className="btn primary-btn"
          style={{ width: "100%" }}
        >
          Login
        </button>
      </form>
    </div>
  );
}

export default Login;
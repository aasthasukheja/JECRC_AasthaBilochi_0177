import React from "react";
import { useAuth } from "../context/AuthContext";
import { useTheme } from "../context/ThemeContext";

function Header() {
  const { user, isAuthenticated, logout } = useAuth();
  const { theme, toggleTheme } = useTheme();

  return (
    <header className="header">
      <div>
        <h1>Internal Employee Portal</h1>
        <p className="sub-text">Advanced Context API Enterprise React App</p>
      </div>

      <div className="header-actions">
        <button onClick={toggleTheme} className="btn secondary-btn">
          Switch to {theme === "light" ? "Dark" : "Light"} Mode
        </button>

        {isAuthenticated && (
          <>
            <span className="welcome-text">Welcome, {user.name}</span>
            <button onClick={logout} className="btn danger-btn">
              Logout
            </button>
          </>
        )}
      </div>
    </header>
  );
}

export default Header;
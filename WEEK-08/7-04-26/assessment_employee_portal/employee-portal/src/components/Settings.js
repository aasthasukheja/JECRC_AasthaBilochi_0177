import React from "react";
import { useTheme } from "../context/ThemeContext";
import { useAuth } from "../context/AuthContext";

function Settings() {
  const { theme, toggleTheme } = useTheme();
  const { user } = useAuth();

  return (
    <div className="card">
      <h2>Settings</h2>

      <div className="settings-box">
        <p><strong>Logged in user:</strong> {user?.name}</p>
        <p><strong>Current theme:</strong> {theme}</p>

        <button className="btn primary-btn" onClick={toggleTheme}>
          Toggle Theme
        </button>
      </div>
    </div>
  );
}

export default Settings;
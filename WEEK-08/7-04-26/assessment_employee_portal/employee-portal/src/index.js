import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { AuthProvider } from "./context/AuthContext";
import { ThemeProvider } from "./context/ThemeContext";
import { EmployeeProvider } from "./context/EmployeeContext";
import "./styles/main.css";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <React.StrictMode>
    <ThemeProvider>
      <AuthProvider>
        <EmployeeProvider>
          <App />
        </EmployeeProvider>
      </AuthProvider>
    </ThemeProvider>
  </React.StrictMode>
);
import React from "react";
import { useAuth } from "./context/AuthContext";
import Header from "./components/Header";
import Login from "./components/Login";
import Dashboard from "./components/Dashboard";

function App() {
  const { isAuthenticated } = useAuth();

  return (
    <div className="app-container">
      <Header />
      <main className="main-content">
        {isAuthenticated ? <Dashboard /> : <Login />}
      </main>
    </div>
  );
}

export default App;